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
    public class IngredientRepository : IIngredientRepository
    {
        private readonly ApiDataContext _apiDataContext;

        public IngredientRepository(ApiDataContext apiDataContext)
        {
            _apiDataContext = apiDataContext;
        }
        public IList<Ingredient> GetIngredients()
        {
            return _apiDataContext.Ingredients.ToList();
        }
    }
}
