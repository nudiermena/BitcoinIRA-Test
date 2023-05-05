using BitcoinIRA.Application;
using BitcoinIRA.Database.Models;
using Moq;
using Xunit;

namespace BitcoinIRA.Testing
{
    public class RecipeIngredientTests
    {
        private static CalculatorRepository _calculatorRepository;

        private readonly Mock<IRecipeRepository> _mockRecipeRepository = new Mock<IRecipeRepository>();
        private readonly Mock<IIngredientRepository> _mockIngredientRepository = new Mock<IIngredientRepository>();
        public RecipeIngredientTests()
        {
            _calculatorRepository = new CalculatorRepository(_mockRecipeRepository.Object, _mockIngredientRepository.Object);
        }

        [Fact]
        public void Calculate_ValidArguments_Succeeds()
        {
            //var recipesDummy = new List<Recipe>()
            //    {
            //       new Recipe { Name ="Recipe 1", Ingredients = new List<Ingredient>
            //           { new Ingredient{ Name ="organic garlic", Quantity = 1, IsOrganic= true },
            //             new Ingredient{ Name ="lemon", Quantity = 1, IsOrganic= false },
            //             new Ingredient{ Name ="organic olive oil", Quantity=0.75 , IsOrganic= true },
            //             new Ingredient{ Name ="salt", Quantity=0.75, IsOrganic= false },
            //             new Ingredient{ Name ="pepper", Quantity=0.5, IsOrganic= false },
            //           }
            //        },
            //       new Recipe { Name ="Recipe 2", Ingredients = new List<Ingredient>
            //           { new Ingredient{ Name ="organic garlic", Quantity= 1, IsOrganic= true },
            //             new Ingredient{ Name ="chicken breast", Quantity= 4, IsOrganic= false },
            //             new Ingredient{ Name ="organic olive oil", Quantity= 0.5, IsOrganic= true },
            //             new Ingredient{ Name ="vinegar", Quantity=0.5, IsOrganic= true },
            //           }
            //        },
            //    };

            //_mockRecipeRepository.Setup(x => x.GetRecipes()).Returns(recipesDummy);

            //List<RecipeResponse> recipeResponse = (List<RecipeResponse>)_calculatorRepository.CalculateAllRecipes();


            //Assert.NotNull(recipeResponse);
        }
    }
}