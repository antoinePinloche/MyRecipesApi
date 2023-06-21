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
    public sealed class RecipesBusiness : IRecipesBusiness
    {
        public IRecipesManager _recipesManager;

        public RecipesBusiness(IRecipesManager recipesManager)
        {
            _recipesManager = recipesManager;
        }
        public async Task<RecipeModel> CreateRecipe(RecipeRequest recipeRequest)
        {
            return await _recipesManager.CreateRecipe(recipeRequest);
        }

        public async Task<bool> DeleteRecipe(int recipeId)
        {
            try
            {
                return await _recipesManager.DeleteRecipe(recipeId);
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

        public async Task<List<RecipeModel>> FoundRecetteByIngredientName(string ingredient)
        {
            try
            {
                return await _recipesManager.FoundRecetteByIngredientName(ingredient);
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

        public async Task<List<RecipeModel>> FoundRecetteByNationality(string nationality)
        {
            try
            {
                return await _recipesManager.FoundRecetteByNationality(nationality);
            }
            catch (NullReferenceException)
            {
                throw new NullReferenceException();
            }
            catch(Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public async Task<List<RecipeModel>> GetAllRecipes()
        {
            try
            {
                return await _recipesManager.GetAllRecipes();
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

        public async Task<RecipeModel> GetRecipeById(int id)
        {
            try { 
                return await _recipesManager.GetRecipeById(id);
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

        public async Task<RecipeModel> ModifyRecipe(RecipeRequest recipeRequest, int id)
        {
            try
            {
                return await _recipesManager.ModifyRecipe(recipeRequest, id);
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
