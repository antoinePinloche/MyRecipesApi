using MyRecipes.Domain.Models;
using MyRecipes.Domain.Models.Request;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyRecipes.Domain.Interfaces.Business
{
    public interface IRecipesUserBusiness
    {
        Task<RecipesUserModel> GetRecipesUserById(int Id);
        Task<List<RecipesUserModel>> GetAllRecipesUser();
        Task<RecipesUserModel> CreateRecipesUser(RecipesUserRequest recipesUserRequest);
        Task<bool> DeleteRecipesUser(int recipesUserId);
    }
}
