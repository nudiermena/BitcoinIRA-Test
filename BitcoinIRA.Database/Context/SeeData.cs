using BitcoinIRA.Database.Enum;
using BitcoinIRA.Database.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BitcoinIRA.Database.Context
{
    public static class SeedData
    {
        public static void EnsurePopulated(IServiceProvider serviceProvider)
        {
            using var context = new ApiDataContext(
           serviceProvider.GetRequiredService<DbContextOptions<ApiDataContext>>());

            if (!context.Ingredients.Any())
            {
                var ingredients = new List<Ingredient>
                {
                    new Ingredient{ Id= 1, Name ="organic garlic",  UnitCost = 0.67m, IsOrganic= true, IngredientCategory = IngredientCategoryEnum.Produce.ToString() },
                    new Ingredient{ Id=2,  Name ="lemon", UnitCost = 2.03m, IsOrganic= false, IngredientCategory = IngredientCategoryEnum.Produce.ToString() },
                    new Ingredient{ Id= 3, Name ="corn",  UnitCost=0.87m, IsOrganic= false, IngredientCategory = IngredientCategoryEnum.Produce.ToString() },
                    new Ingredient{ Id=4, Name ="chicken breast", UnitCost=2.19m, IsOrganic= false, IngredientCategory = IngredientCategoryEnum.Pantry.ToString() },
                    new Ingredient{ Id=5, Name ="bacon", UnitCost=0.24m, IsOrganic= false, IngredientCategory = IngredientCategoryEnum.Pantry.ToString()},
                    new Ingredient{ Id=6, Name ="pasta", UnitCost=0.31m,  IsOrganic= false ,IngredientCategory = IngredientCategoryEnum.Pantry.ToString()},
                    new Ingredient{ Id=7, Name ="organic olive oil", UnitCost=1.92m, IsOrganic= true, IngredientCategory = IngredientCategoryEnum.Pantry.ToString() },
                    new Ingredient{ Id=8, Name ="vinegar", UnitCost=1.26m, IsOrganic= true,IngredientCategory = IngredientCategoryEnum.Pantry.ToString() },
                    new Ingredient{ Id=9, Name ="salt", UnitCost=0.16m, IsOrganic= false,IngredientCategory = IngredientCategoryEnum.Pantry.ToString() },
                    new Ingredient{ Id=10, Name ="pepper", UnitCost=0.17m, IsOrganic= false,IngredientCategory = IngredientCategoryEnum.Pantry.ToString() }};

                context.Ingredients.AddRange(ingredients);
                context.SaveChanges();
            };

            if (!context.Recipes.Any())
            {
                var recipes = new List<Recipe>()
                {
                   new Recipe { Id=1, Name ="Recipe 1" },
                   new Recipe { Id=2, Name ="Recipe 2"},
                   new Recipe { Id=3, Name ="Recipe 3" }
                };

                context.Recipes.AddRange(recipes);
                context.SaveChanges();
            }

            if (!context.RecipeIngredients.Any())
            {
                var recipeIngredient = new List<RecipeIngredient>()
                {
                    new RecipeIngredient{ RecipeId = 1, IngredientId =1, Quantity=1 },
                    new RecipeIngredient{ RecipeId = 1, IngredientId =2 , Quantity=1 },
                    new RecipeIngredient{ RecipeId = 1, IngredientId =7 , Quantity=0.75 },
                    new RecipeIngredient{ RecipeId = 1,IngredientId =9 , Quantity=0.75 },
                    new RecipeIngredient{ RecipeId = 1,IngredientId =10 ,  Quantity=0.5 },
                    new RecipeIngredient{ RecipeId = 2,IngredientId =1 ,  Quantity=1 },
                    new RecipeIngredient{ RecipeId = 2,IngredientId =4 , Quantity=4 },
                    new RecipeIngredient{ RecipeId = 2, IngredientId =7 ,  Quantity=0.5 },
                    new RecipeIngredient{ RecipeId = 2, IngredientId =8 ,  Quantity=0.5 },
                    new RecipeIngredient{ RecipeId = 3, IngredientId =1 ,  Quantity=1 },
                    new RecipeIngredient{ RecipeId = 3,IngredientId =3 ,  Quantity=4 },
                    new RecipeIngredient{ RecipeId = 3,IngredientId =5 ,  Quantity=4 },
                    new RecipeIngredient{ RecipeId = 3,IngredientId =6 ,  Quantity=8 },
                    new RecipeIngredient{ RecipeId = 3,IngredientId =7 ,  Quantity=0.33 },
                    new RecipeIngredient{ RecipeId = 3,IngredientId =9 ,  Quantity=1.25 },
                    new RecipeIngredient{ RecipeId = 3,IngredientId =10 ,  Quantity=0.75 },
                };

                context.RecipeIngredients.AddRange(recipeIngredient);
                context.SaveChanges();
            }
        }
    }
}




