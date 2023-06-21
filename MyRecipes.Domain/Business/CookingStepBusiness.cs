using MyRecipes.Domain.Interfaces.Business;
using MyRecipes.Domain.Interfaces.Managers;
using MyRecipes.Domain.Models;
using MyRecipes.Domain.Models.Request;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyRecipes.Domain.Business
{
    public class CookingStepBusiness : ICookingStepsBusiness
    {
        public ICookingStepsManager _cookingManager;

        public CookingStepBusiness(ICookingStepsManager cookingManager)
        {
            _cookingManager = cookingManager;
        }

        public async Task<List<CookingStepModel>> CreateCookingStep(List<CookingStepRequest> cookingStepRequest)
        {
            try
            {
                return await _cookingManager.CreateCookingSteps(cookingStepRequest);
            }
            catch (NullReferenceException )
            {
                throw new NullReferenceException();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public async Task<List<CookingStepModel>> GetAllCookingSteps()
        {
            try
            {
                return await _cookingManager.GetAllCookingSteps();
            }
            catch (NullReferenceException)
            {
                throw new NullReferenceException();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public async Task<CookingStepModel> GetCookingStepsById(int id)
        {
            try
            {
                return await _cookingManager.GetCookingStepsById(id);
            }
            catch (NullReferenceException)
            {
                throw new NullReferenceException();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public async Task<List<CookingStepModel>> GetCookingStepsByRecipeId(int recipeId)
        {           
            try
            {
                return await _cookingManager.GetCookingStepsByRecipeId(recipeId);
            }
            catch (NullReferenceException)
            {
                throw new NullReferenceException();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public async Task<bool> RemoveAllCookingStepByRecipeId(int recipeId)
        {
            try
            {
                return await _cookingManager.RemoveAllCookingStepByRecipeId(recipeId);
            }
            catch (NullReferenceException)
            {
                throw new NullReferenceException();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public async Task<bool> RemoveCookingStep(int id)
        {
            try
            {
                return await _cookingManager.RemoveCookingStep(id);
            }
            catch (NullReferenceException)
            {
                throw new NullReferenceException();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
    }
}
