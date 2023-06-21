using MyRecipes.Domain.Models;
using MyRecipes.Domain.Models.Request;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyRecipes.Domain.Interfaces.Managers
{
    public interface IRecipesManager
    {
        Task<RecipeModel> GetRecipeById(int id);
        Task<List<RecipeModel>> GetAllRecipes();
        Task<RecipeModel> CreateRecipe(RecipeRequest repiceRequest);
        Task<List<RecipeModel>> FoundRecetteByIngredientName(string ingredient);
        Task<List<RecipeModel>> FoundRecetteByNationality(string nationality);
        Task<bool> DeleteRecipe(int recipesId);
        Task<RecipeModel> ModifyRecipe(RecipeRequest ingredientRequest, int id);
        Task<UserModel> FoundUserByRecipe(int recipeId);
    }
}
