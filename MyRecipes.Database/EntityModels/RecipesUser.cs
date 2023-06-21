using MyRecipes.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyRecipes.Database.EntityModels
{
    public sealed class RecipesUser
    {
        public int Id { get; set; }
        public int UserId { get; set; }
        public User User { get; set; }
        public List<Recipe> Recipes { get; set; }

        public RecipesUserModel ToRecipesUserModel()
        {
            var modelRet = new RecipesUserModel
            {
                Id = Id,
                User = User.ToUserModel()
            };
            if (Recipes is not null )
            {
                modelRet.Recipes = new List<RecipeModel>();
                foreach( var recipe in Recipes )
                    modelRet.Recipes.Add(recipe.ToRecipeModel());
            }
            return modelRet;
        }
    }
}
