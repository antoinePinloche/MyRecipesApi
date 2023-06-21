using MyRecipes.Domain.Models;
using MyRecipes.Domain.Models.Request;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyRecipes.Domain.Interfaces.Managers
{
    public interface IUserManager
    {
        Task<List<UserModel>> GetAllUsers();
        Task<UserModel> GetUserById(int id);
        Task<UserModel> AddUser(UserModel user, string password);
        Task<UserModel> AuthenticateUser(string mail, string password);
        Task<bool> DeleteUser(int usertId);
        Task<UserModel> ChangeUserInformation(UserModel user, int Id);
        Task<bool> EditUserAccess(int userId, string newAccess);
        Task<bool> ChangePassword(int userId, ChangePasswordRequest newPassword);
    }
}
