using BitcoinIRA.Database.Context;
using BitcoinIRA.Database.Models;

namespace BitcoinIRA.Application
{
    public interface IIngredientRepository
    {
        public IList<Ingredient> GetIngredients();
    }
}