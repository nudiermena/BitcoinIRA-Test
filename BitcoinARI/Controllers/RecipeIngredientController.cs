using BitcoinIRA.Application;
using Microsoft.AspNetCore.Mvc;

namespace BitcoinARI.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class RecipeIngredientController : ControllerBase
    {
        readonly ICalculatorRepository _calculatorRepository;

        public RecipeIngredientController(ICalculatorRepository calculatorRepository)
        {
            _calculatorRepository = calculatorRepository;
        }

        [HttpGet("CalculateAllRecipes")]
        public async Task<IActionResult> Get()
        {
            return Ok(_calculatorRepository.CalculateAllRecipes());
        }
    }
}