using MyRecipes.Domain.Models.Request;
using MyRecipes.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyRecipes.Domain.Interfaces.Managers
{
    public interface IIngredientManager
    {
        Task<IngredientModel> GetIngredientById(int id);
        Task<List<IngredientModel>> GetAllIngredients();
        Task<List<IngredientModel>> CreateIngredients(List<IngredientRequest> ingredientsRequest);
        Task<List<IngredientModel>> FoundIngredientByRecetteId(int recetteId);
        Task<bool> DeleteIngredient(int ingredientId);
        Task<bool> DeleteIngredientByRecipeId(int recipeId);
    }
}
