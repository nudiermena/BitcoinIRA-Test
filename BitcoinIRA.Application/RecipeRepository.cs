using BitcoinIRA.Database;
using BitcoinIRA.Database.Context;
using BitcoinIRA.Database.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BitcoinIRA.Application
{
    public class RecipeRepository : IRecipeRepository
    {
        private static ApiDataContext _ApiDataContext;
        public RecipeRepository(ApiDataContext apiDataContext)
        {
            _ApiDataContext = apiDataContext;
        }

        public IList<Recipe> GetRecipes()
        {
            return _ApiDataContext.Recipes.Include(i => i.Ingredients).ToList();
        }


        private void GetIngredientsPrice(List<Recipe> recipeIngredients)
        {
            if (recipeIngredients == null)
            {
                throw new ArgumentNullException(nameof(recipeIngredients));
            }

            var ingredients = _ApiDataContext.Ingredients.ToList();



            //.ToList();
            //foreach (var recipe in recipeIngredients)
            //{
            //    foreach (var ingredient in recipe.Ingredients
            //    {

            //    }
            //}



            //ingredients.ForEach(i =>
            //{
            //    i.Price *
            //});

        }
    }
}
