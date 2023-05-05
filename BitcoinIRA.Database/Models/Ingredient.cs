using BitcoinIRA.Database.Enum;
using Microsoft.EntityFrameworkCore;
namespace BitcoinIRA.Database.Models
{
    public class Ingredient
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public decimal UnitCost { get; set; }
        public bool IsOrganic { get; set; }
        public string IngredientCategory { get; set; }
        public ICollection<RecipeIngredient> RecipeIngredients { get; set; }
    }
}