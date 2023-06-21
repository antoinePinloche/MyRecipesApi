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
    public sealed class IngredientBusiness : IIngredientBusiness
    {
        public IIngredientManager _ingredientManager;

        public IngredientBusiness(IIngredientManager ingredientManager)
        {
            _ingredientManager = ingredientManager;
        }

        public async Task<List<IngredientModel>> CreateIngredients(List<IngredientRequest> ingredientsRequest)
        {
            
            try
            {
                return await _ingredientManager.CreateIngredients(ingredientsRequest);
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

        public async Task<bool> DeleteIngredient(int ingredientId)
        {
            
            try
            {
                return await _ingredientManager.DeleteIngredient(ingredientId);
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

        public async Task<bool> DeleteIngredientByRecipeId(int recipeId)
        {
            
            try
            {
                return await _ingredientManager.DeleteIngredientByRecipeId(recipeId);
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

        public async Task<List<IngredientModel>> FoundIngredientByRecetteId(int recetteId)
        {
            
            try
            {
                return await _ingredientManager.FoundIngredientByRecetteId(recetteId);
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

        public async Task<List<IngredientModel>> GetAllIngredients()
        {
            
            try
            {
                return await _ingredientManager.GetAllIngredients();
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

        public async Task<IngredientModel> GetIngredientById(int id)
        {
            
            try
            {
                return await _ingredientManager.GetIngredientById(id);
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

        public async Task<UserModel> GetUserByIngredient(int ingredientId)
        {
            try
            {
                return await _ingredientManager.GetUserByIngredient(ingredientId);
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

        public async Task<UserModel> GetUserByRecipeId(int recipeId)
        {
            try
            {
                return await _ingredientManager.GetUserByRecipeId(recipeId);
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
