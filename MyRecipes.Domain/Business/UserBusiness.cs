using MyRecipes.Domain.Interfaces.Business;
using MyRecipes.Domain.Interfaces.Managers;
using MyRecipes.Domain.Models;
using MyRecipes.Domain.Models.Request;
using MyRecipes.Domain.Models.Request.Auth;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyRecipes.Domain.Business
{
    public sealed class UserBusiness : IUserBusiness
    {
        public IUserManager _userManager;

        public UserBusiness(IUserManager userManager)
        {
            _userManager = userManager;
        }

        public async Task<UserModel> AddUser(UserRequest userRequest)
        {
            var userToAdd = new UserModel
            {
                FirstName = userRequest.FirstName,
                LastName = userRequest.LastName,
                Mail = userRequest.Mail,
                UserName = userRequest.UserName,
                Role = "USER"
            };
            try
            {
                return await _userManager.AddUser(userToAdd, userRequest.Password);
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

        public async Task<UserModel> AuthenticateUser(ConnectUserRequest userRequest)
        {
            try
            {
                return await _userManager.AuthenticateUser(userRequest.UserName, userRequest.Password);
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

        public async Task<bool> ChangePassword(int userId, ChangePasswordRequest newPassordRequest)
        {
            try
            {
                return await _userManager.ChangePassword(userId, newPassordRequest);
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

        public async Task<UserModel> ChangeUserInformation(UserRequest userRequest, int Id)
        {
            var userToModify = new UserModel
            {
                FirstName = userRequest.FirstName,
                LastName = userRequest.LastName,
                Mail = userRequest.Mail,
                UserName = userRequest.UserName,
            };
            try
            {
                return await _userManager.ChangeUserInformation(userToModify, Id);
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

        public async Task<bool> DeleteUser(int userId)
        {
            try
            {
                return await _userManager.DeleteUser(userId);
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

        public async Task<bool> EditUserAccess(int userId, string newAccess)
        {
            try
            {
                return await _userManager.EditUserAccess(userId, newAccess);
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

        public Task<List<UserModel>> GetAllUsers()
        {
            try
            {
                return _userManager.GetAllUsers();
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

        public Task<UserModel> GetUserById(int id)
        {
            try
            {
                return  _userManager.GetUserById(id);
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
