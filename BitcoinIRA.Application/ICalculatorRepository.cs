using BitcoinIRA.Database.Models;
using Microsoft.VisualBasic;

namespace BitcoinIRA.Application
{
    public interface ICalculatorRepository
    {
        public IList<RecipeResponse> CalculateAllRecipes();
    }
}
