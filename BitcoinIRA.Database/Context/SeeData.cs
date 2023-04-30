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

            if (!context.Recipes.Any())
            {
                var recipes = new List<Recipe>()
                {
                   new Recipe { Name ="Recipe 1", Ingredients = new List<Ingredient>
                       { new Ingredient{ Name ="organic garlic", Price=0.67m, Quantity = 1, IsOrganic= true },
                         new Ingredient{ Name ="lemon", Quantity = 1,Price=0.67m, IsOrganic= false },
                         new Ingredient{ Name ="organic olive oil",Price=0.67m, Quantity=0.75 , IsOrganic= true },
                         new Ingredient{ Name ="salt", Price=0.67m, Quantity=0.75, IsOrganic= false },
                         new Ingredient{ Name ="pepper", Price=0.67m, Quantity=0.5, IsOrganic= false },
                       }
                    },
                   new Recipe { Name ="Recipe 2", Ingredients = new List<Ingredient>
                       { new Ingredient{ Name ="organic garlic",Price=0.67m, Quantity= 1, IsOrganic= true },
                         new Ingredient{ Name ="chicken breast",Price=0.67m, Quantity= 4, IsOrganic= false },
                         new Ingredient{ Name ="organic olive oil",Price=0.67m, Quantity= 0.5, IsOrganic= true },
                         new Ingredient{ Name ="vinegar",Price=0.67m, Quantity=0.5, IsOrganic= true },
                       }
                    },
                   new Recipe { Name ="Recipe 3", Ingredients = new List<Ingredient>
                       { new Ingredient{ Name ="organic garlic", Quantity=1, Price= 0.31m, IsOrganic= true },
                         new Ingredient{ Name ="corn", Price=0.67m,Quantity=4, IsOrganic= false },
                         new Ingredient{ Name ="bacon", Price=0.67m,Quantity=4, IsOrganic= false },
                         new Ingredient{ Name ="pasta", Price=0.67m,Quantity=8,  IsOrganic= false },
                         new Ingredient{ Name ="organic olive oil",Price=0.67m, Quantity=0.33, IsOrganic= true },
                         new Ingredient{ Name ="salt",Price=0.67m, Quantity=1.25, IsOrganic= true },
                         new Ingredient{ Name ="pepper", Price=0.67m,Quantity=0.75, IsOrganic= true },
                       }
                    }
                };

                context.Recipes.AddRange(recipes);
                context.SaveChanges();
            }

            if (!context.Ingredients.Any())
            {

                var ingredients = new List<Ingredient>{
            new Ingredient{ Name ="organic garlic", Quantity = 1, IsOrganic= true, IngredientCategory = IngredientCategoryEnum.Produce  },
            new Ingredient{ Name ="lemon", Quantity = 1, IsOrganic= false, IngredientCategory = IngredientCategoryEnum.Produce },
            new Ingredient{ Name ="corn", Quantity=4, IsOrganic= false, IngredientCategory = IngredientCategoryEnum.Produce },

            new Ingredient{ Name ="chicken breast", Quantity= 4, IsOrganic= false, IngredientCategory = IngredientCategoryEnum.Pantry },
            new Ingredient{ Name ="bacon", Quantity=4, IsOrganic= false, IngredientCategory = IngredientCategoryEnum.Pantry },

            new Ingredient{ Name ="pasta", Quantity=8,  IsOrganic= false ,IngredientCategory = IngredientCategoryEnum.Pantry},
            new Ingredient{ Name ="organic olive oil", Quantity=0.75 , IsOrganic= true, IngredientCategory = IngredientCategoryEnum.Pantry },
            new Ingredient{ Name ="vinegar", Quantity=0.5, IsOrganic= true,IngredientCategory = IngredientCategoryEnum.Pantry },
            new Ingredient{ Name ="salt", Quantity=0.75, IsOrganic= false,IngredientCategory = IngredientCategoryEnum.Pantry },
            new Ingredient{ Name ="pepper", Quantity=0.5, IsOrganic= false,IngredientCategory = IngredientCategoryEnum.Pantry }};

                context.Ingredients.AddRange(ingredients);
                context.SaveChanges();
            }
        }
    }
}




