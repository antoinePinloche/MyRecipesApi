using MyRecipes.Domain.Models;
using MyRecipes.Domain.Models.Request;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;

namespace MyRecipes.Domain.Interfaces.Managers
{
    public interface IRecipesUserManager
    {
        Task<RecipesUserModel> GetRecipesUserById(int Id);
        Task<List<RecipesUserModel>> GetAllRecipesUser();
        Task<RecipesUserModel> CreateRecipesUser(RecipesUserRequest user);
        Task<bool> DeleteRecipesUser(int recipesUserId);
        Task<UserModel> GetUserByRecipesUserId(int recipeUserId);
    }
}
