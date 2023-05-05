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
            var recipes = _ApiDataContext.Recipes
                .Include(i => i.RecipeIngredients)
                .ThenInclude(i => i.Ingredient).OrderBy(x => x.Id).ToList();

            return recipes;
        }
    }
}








