using MyRecipes.Domain.Models;
using MyRecipes.Domain.Models.Request;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyRecipes.Domain.Interfaces.Managers
{
    public interface ICookingStepsManager
    {
        public Task<List<CookingStepModel>> GetAllCookingSteps();
        public Task<CookingStepModel> GetCookingStepsById(int id);
        public Task<List<CookingStepModel>> GetCookingStepsByRecipeId(int recipeId);
        public Task<bool> RemoveCookingStep(int id);
        public Task<bool> RemoveAllCookingStepByRecipeId(int recipeId);
        public Task<List<CookingStepModel>> CreateCookingSteps(List<CookingStepRequest> models);
        Task<UserModel> FoundUserByCookingStepId(int recipeId);
        Task<UserModel> FoundUserByRecipeId(int recipeId);
    }
}
