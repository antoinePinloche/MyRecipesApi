using MyRecipes.Domain.Models.Request;
using MyRecipes.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyRecipes.Domain.Interfaces.Business
{
    public interface IRecipesBusiness
    {
        Task<RecipeModel> GetRecipeById(int id);
        Task<List<RecipeModel>> GetAllRecipes();
        Task<RecipeModel> CreateRecipe(RecipeRequest recipeRequest);
        Task<List<RecipeModel>> FoundRecetteByIngredientName(string ingredient);
        Task<List<RecipeModel>> FoundRecetteByNationality(string nationality);
        Task<bool> DeleteRecipe(int recipeId);
        Task<RecipeModel> ModifyRecipe(RecipeRequest recipeRequest, int id);
    }
}
