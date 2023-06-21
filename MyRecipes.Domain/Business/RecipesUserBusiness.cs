using MyRecipes.Domain.Interfaces.Managers;
using MyRecipes.Domain.Models.Request;
using MyRecipes.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MyRecipes.Domain.Interfaces.Business;

namespace MyRecipes.Domain.Business
{
    public sealed class RecipesUserBusiness : IRecipesUserBusiness
    {
        public IRecipesUserManager _recipesUserManager ;

        public RecipesUserBusiness(IRecipesUserManager recipesUserManager)
        {
            _recipesUserManager = recipesUserManager;
        }

        public async Task<RecipesUserModel> CreateRecipesUser(RecipesUserRequest recipesUserRequest)
        {
            
            try
            {
                return await _recipesUserManager.CreateRecipesUser(recipesUserRequest);
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

        public async Task<bool> DeleteRecipesUser(int recipesUserId)
        {
            
            try
            {
                return await _recipesUserManager.DeleteRecipesUser(recipesUserId);
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

        public async Task<List<RecipesUserModel>> GetAllRecipesUser()
        {
            try
            {
                return await _recipesUserManager.GetAllRecipesUser();
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

        public async Task<RecipesUserModel> GetRecipesUserById(int Id)
        {
            try
            {
                return await _recipesUserManager.GetRecipesUserById(Id);
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

        public async Task<UserModel> GetUserByRecipesUserId(int recipeUserId)
        {
            try
            {
                return await _recipesUserManager.GetUserByRecipesUserId(recipeUserId);
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
