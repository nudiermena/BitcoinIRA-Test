using BitcoinIRA.Database.Models;
using Microsoft.EntityFrameworkCore;
using System.Reflection.Metadata;

namespace BitcoinIRA.Database.Context
{
    public class ApiDataContext : DbContext
    {
        public ApiDataContext(DbContextOptions<ApiDataContext> options) : base(options) { }
        public DbSet<Ingredient> Ingredients { get; set; }
        public DbSet<Recipe> Recipes { get; set; }
        public DbSet<RecipeIngredient> RecipeIngredients { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            //base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<RecipeIngredient>()
            .HasKey(e => new { e.IngredientId, e.RecipeId });

            modelBuilder.Entity<RecipeIngredient>()
            .HasOne(e => e.Ingredient)
            .WithMany(ri => ri.RecipeIngredients)
            .HasForeignKey(e => e.IngredientId);


            modelBuilder.Entity<RecipeIngredient>()
            .HasOne(e => e.Recipe)
            .WithMany(ri => ri.RecipeIngredients)
            .HasForeignKey(e => e.RecipeId);
        }
    }
}