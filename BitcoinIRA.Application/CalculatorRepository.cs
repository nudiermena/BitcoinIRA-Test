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
        public CalculatorRepository(IRecipeRepository recipeRepository)
        {
            _iRecipeRepository = recipeRepository;
        }

        public IList<RecipeResponse> CalculateAllRecipes()
        {
            var recipesResponse = new List<RecipeResponse>();
            var recipes = _iRecipeRepository.GetRecipes();

            foreach (var recipe in recipes)
            {
                var recipedata = ComputeTotalCost(recipe);
                recipesResponse.Add(recipedata);
            }

            return recipesResponse;
        }

        private RecipeResponse ComputeTotalCost(Recipe recipe)
        {
            decimal totalCost = 0;
            decimal discount = 0;
            foreach (var ingredient in recipe.Ingredients)
            {
                decimal ingredientCost = ingredient.Price == null ? 2 : 10;

                if (!ingredient.IngredientCategory.Equals(IngredientCategoryEnum.Produce))
                {
                    // Apply sales tax
                    decimal salesTax = ingredientCost * (decimal)SALES_TAX_RATE;
                    ingredientCost += RoundToNearestSevenCents(salesTax);
                }

                if (ingredient.IsOrganic)
                {
                    // Apply wellness discount
                    discount = ingredientCost * (decimal)WELLNESS_DISCOUNT_RATE;
                    ingredientCost -= RoundToNearestCent(discount);
                }

                totalCost += ingredientCost;
            }

            // Apply sales tax to the total cost
            decimal totalSalesTax = totalCost * SALES_TAX_RATE;
            totalCost += RoundToNearestSevenCents(0);

            return new RecipeResponse { RecipeName = recipe.Name, SalesTax = 0, WellnessDiscount = discount, TotalCost = totalCost };
        }

        private decimal RoundToNearestSevenCents(decimal amount)
        {
            decimal roundedAmount = Math.Ceiling(amount * 100 / NEAREST_7CENTS) * NEAREST_7CENTS / 100;
            return roundedAmount;
        }

        private decimal RoundToNearestCent(decimal amount)
        {
            decimal roundedAmount = Math.Round(amount, 2);
            return roundedAmount;
        }
    }
}
