using MyRecipes.Domain.Models;
using MyRecipes.Domain.Models.Request;
using MyRecipes.Domain.Models.Request.Auth;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyRecipes.Domain.Interfaces.Business
{
    public interface IUserBusiness
    {
        Task<List<UserModel>> GetAllUsers();
        Task<UserModel> AddUser(UserRequest userRequest);
        Task<UserModel> GetUserById(int id);
        Task<bool> DeleteUser(int userId);
        Task<UserModel> ChangeUserInformation(UserRequest userRequest, int Id);
        Task<bool> EditUserAccess(int userId, string newAccess);
        Task<bool> ChangePassword(int userId, ChangePasswordRequest newPassordRequest);
        Task<UserModel> AuthenticateUser(ConnectUserRequest userRequest);
    }
}
