using MyRecipes.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyRecipes.Database.EntityModels
{
    public sealed class Recipe
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public DateTime StartDate { get; set; }
        public string Description { get; set; }
        public string Nationality { get; set; }
        public int RecipesUserId { get; set; }
        public RecipesUser RecipesUser { get; set; }
        public List<Ingredient> Ingredients { get; set; }
        public List<CookingStep> CookingSteps { get; set; }

        public RecipeModel ToRecipeModel()
        {
            var modelRet =  new RecipeModel
            {
                Id = Id,
                Name = Name,
                StartDate = StartDate,
                Description = Description,
                Nationnality = Nationality
            };
            if (Ingredients is not null)
            {
                modelRet.Ingredients = new List<IngredientModel>();
                foreach (var ingredient in Ingredients)
                    modelRet.Ingredients.Add(ingredient.ToIngredientModel());
            }
            if (CookingSteps is not null)
            {
                modelRet.CookingSteps = new List<CookingStepModel>();
                foreach (var cs in CookingSteps)
                    modelRet.CookingSteps.Add(cs.ToCookingStepModel());
            }
            return modelRet;
        }
    }
}
