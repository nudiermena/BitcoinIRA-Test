using BitcoinIRA.Database.Models;

namespace BitcoinIRA.Application
{
    public interface IRecipeRepository
    {
        public IList<Recipe> GetRecipes();
    }
}