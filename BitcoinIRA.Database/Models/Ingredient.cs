using BitcoinIRA.Database.Enum;
using Microsoft.EntityFrameworkCore;
namespace BitcoinIRA.Database.Models
{    
    public class Ingredient
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public decimal? Price { get; set; }
        public double Quantity { get; set; }
        public bool IsOrganic { get; set; }
        public IngredientCategoryEnum IngredientCategory { get; set; }
    }
}