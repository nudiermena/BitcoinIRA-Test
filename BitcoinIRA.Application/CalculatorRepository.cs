using BitcoinIRA.Database.Context;
using BitcoinIRA.Database.Enum;
using BitcoinIRA.Database.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Net.Mime.MediaTypeNames;

namespace BitcoinIRA.Application
{
    public class CalculatorRepository : ICalculatorRepository
    {
        private const decimal SALES_TAX_RATE = 0.086m;
        private const decimal WELLNESS_DISCOUNT_RATE = 0.05m;
        private const decimal NEAREST_7CENTS = 0.07m;

        private readonly IRecipeRepository _iRecipeRepository;
        private readonly IIngredientRepository _ingredientRepository;
        private List<Ingredient>? _ingredientList;
        public CalculatorRepository(IRecipeRepository recipeRepository, IIngredientRepository ingredientRepository)
        {
            _iRecipeRepository = recipeRepository;
            _ingredientRepository = ingredientRepository;
        }

        public IList<RecipeResponse> CalculateAllRecipes()
        {
            var recipesResponse = new List<RecipeResponse>();
            var recipes = _iRecipeRepository.GetRecipes();
            _ingredientList = (List<Ingredient>)_ingredientRepository.GetIngredients();

            foreach (var recipe in recipes)
            {
                var ComputedRecipedata = ComputeTotalCost(recipe);
                recipesResponse.Add(ComputedRecipedata);
            }

            return recipesResponse;
        }

        private RecipeResponse ComputeTotalCost(Recipe recipe)
        {
            decimal totalCost = 0;
            decimal discount = 0;
            foreach (var ingredient in recipe.RecipeIngredients)
            {
                decimal ingredientUnitCost = ingredient.Ingredient.UnitCost;
                var item2 = _ingredientList.FirstOrDefault(x => x.Id == ingredient.IngredientId);
                if (item2 != default)
                {

                    ingredientUnitCost = Convert.ToDecimal(ingredient.Quantity) * item2.UnitCost;
                }

                if (!ingredient.Ingredient.IngredientCategory.Equals(IngredientCategoryEnum.Produce))
                {
                    // Apply sales tax
                    decimal salesTax = ingredientUnitCost * (decimal)SALES_TAX_RATE;
                    ingredientUnitCost += RoundToNearestSevenCents(salesTax);
                }

                /*- Wellness Discount (-%5 of the total price rounded up to the nearest cent, applies only to organic items)*/
                if (ingredient.Ingredient.IsOrganic)
                {
                    // Apply wellness discount
                    discount = ingredientUnitCost * (decimal)WELLNESS_DISCOUNT_RATE;
                    ingredientUnitCost -= RoundToNearestCent(discount);
                }

                totalCost += ingredientUnitCost;
            }

            // Apply sales tax to the total cost
            decimal totalSalesTax = Math.Ceiling(totalCost * SALES_TAX_RATE * 100) / 100;
            totalCost += RoundToNearestSevenCents(totalSalesTax);
            totalCost = RoundToNearestCent(totalCost);
            discount = RoundToNearestCent(discount);
            totalSalesTax = RoundToNearestCent(totalSalesTax);

            return new RecipeResponse { RecipeName = recipe.Name, SalesTax = totalSalesTax, WellnessDiscount = discount, TotalCost = totalCost };
        }

        private static decimal RoundToNearestSevenCents(decimal amount)
        {
            decimal roundedAmount = Math.Ceiling(amount / NEAREST_7CENTS) * NEAREST_7CENTS;
            return roundedAmount;
        }

        private static decimal RoundToNearestCent(decimal amount)
        {
            decimal roundedAmount = Math.Round(amount, 2);
            return roundedAmount;
        }
    }
}
