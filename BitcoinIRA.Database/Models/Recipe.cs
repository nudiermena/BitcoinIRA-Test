namespace BitcoinIRA.Database.Models
{
    public class Recipe
    {
        public int Id { get; set; }
        public string Name { get; set; } = string.Empty;
        public ICollection<RecipeIngredient> RecipeIngredients { get; set; }
    }
}
