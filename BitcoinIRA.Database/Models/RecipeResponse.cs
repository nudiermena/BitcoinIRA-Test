using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BitcoinIRA.Database.Models
{
    public class RecipeResponse
    {
        public string RecipeName { get; set; }
        public decimal TotalCost { get; set; }
        public decimal SalesTax { get; set; }
        public decimal WellnessDiscount { get; set; }
    }
}
