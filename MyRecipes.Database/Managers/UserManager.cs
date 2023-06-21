using System;
using MyRecipes.Domain.Interfaces.Managers;
using MyRecipes.Domain.Models;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MyRecipes.Database.EntityModels;
using Microsoft.EntityFrameworkCore;
using MyRecipes.Domain.Models.Request;

namespace MyRecipes.Database.Managers
{
    public sealed class UserManager : IUserManager
    {
        private readonly DatabaseContext _databaseContext;

        public UserManager(DatabaseContext databaseContext)
        {
            _databaseContext = databaseContext;
        }

        public async Task<UserModel> AddUser(UserModel user, string password)
        {
            try
            {
                if (await _databaseContext.Users.FirstOrDefaultAsync(u => u.UserName == user.UserName) is null) 
                {
                    var UserBeAdd = new User
                    {
                        FirstName = user.FirstName,
                        LastName = user.LastName,
                        StartDate = DateTime.Now,
                        Mail = user.Mail,
                        UserName = user.UserName,
                        Role = user.Role.ToUpper(),
                        Password = password
                    };

                    await _databaseContext.Users.AddAsync(UserBeAdd);
                    await _databaseContext.SaveChangesAsync();
                    user.Id = UserBeAdd.Id;
                    return user;
                }
                throw new NullReferenceException();
            }
            catch (DbUpdateException dbEx)
            {
                throw new DbUpdateException(dbEx.Message);
            }
            catch (NullReferenceException)
            {
                throw new NullReferenceException();
            }
        }

        public async Task<List<UserModel>> GetAllUsers()
        {
            try
            {
                return await _databaseContext.Users.Select(u => u.ToUserModel()).ToListAsync();
            }
            catch (DbUpdateException dbEx)
            {
                throw new DbUpdateException(dbEx.Message);
            }
            catch (NullReferenceException)
            {
                throw new NullReferenceException();
            }

        }

        public async Task<UserModel> AuthenticateUser(string username, string password)
        {
            try
            {
                var user = await _databaseContext.Users.FirstOrDefaultAsync(t => t.UserName == username && t.Password == password);
                return user.ToUserModel();
            }
            catch (DbUpdateException dbEx)
            {
                throw new DbUpdateException(dbEx.Message);
            }
            catch (NullReferenceException)
            {
                throw new NullReferenceException();
            }
        }

        public async Task<UserModel> GetUserById(int id)
        {
            try
            {
                var user = await _databaseContext.Users.SingleOrDefaultAsync(t => t.Id == id);
                return user.ToUserModel();
            }
            catch (DbUpdateException dbEx)
            {
                throw new DbUpdateException(dbEx.Message);
            }
            catch (NullReferenceException)
            {
                throw new NullReferenceException();
            }
        }

        public async Task<bool> DeleteUser(int userId)
        {
            try
            {
                var userFound = await _databaseContext.Users.FirstOrDefaultAsync(u => u.Id == userId);
                if (userFound is not null)
                {
                    var recipeUser = await _databaseContext.RecipesUsers.FirstOrDefaultAsync(ru => ru.UserId == userId);
               

                    if (recipeUser is not null)
                    {
                        var recipes = await _databaseContext.Recipes.Where(r => r.RecipesUserId == recipeUser.Id).ToListAsync();
                        if (recipes is not null)
                        {
                            foreach (var recipe in recipes)
                            {
                                var ingredients = await _databaseContext.Ingredients.Where(i => i.RecipeId == recipe.Id).ToListAsync();
                                var cookingSteps = await _databaseContext.CookingSteps.Where(cs => cs.RecipeId == recipe.Id).ToListAsync();
                                if (cookingSteps is not null)
                                    _databaseContext.CookingSteps.RemoveRange(cookingSteps);
                                if (ingredients is not null)
                                    _databaseContext.Ingredients.RemoveRange(ingredients);
                            }
                            _databaseContext.Recipes.RemoveRange(recipes);
                        }
                        _databaseContext.RecipesUsers.Remove(recipeUser);
                    }
                    _databaseContext.Users.Remove(userFound);
                    _databaseContext.SaveChanges();
                    return true;
                }
                return false;
            }
            catch (DbUpdateException dbEx)
            {
                throw new DbUpdateException(dbEx.Message);
            }
            catch (NullReferenceException)
            {
                throw new NullReferenceException();
            }
        }

        public async Task<UserModel> ChangeUserInformation(UserModel user, int Id)
        {
            try
            {
                var userFound = await _databaseContext.Users.SingleOrDefaultAsync(u => u.Id == Id);
                userFound.FirstName = user.FirstName;
                userFound.LastName = user.LastName;
                userFound.Role = user.Role.ToUpper();
                userFound.UserName = user.UserName;
                userFound.Mail = user.Mail;
                user.Id = Id;
                _databaseContext.Users.Update(userFound);
                await _databaseContext.SaveChangesAsync();
                return userFound.ToUserModel();
            }
            catch (DbUpdateException dbEx)
            {
                throw new DbUpdateException(dbEx.Message);
            }
            catch (NullReferenceException)
            {
                throw new NullReferenceException();
            }
        }

        public async Task<bool> EditUserAccess(int userId, string newAccess)
        {
            try
            {
                var userFound = await _databaseContext.Users.SingleOrDefaultAsync(u => u.Id == userId);
                if (userFound is not null)
                {
                    userFound.Role = newAccess;
                    _databaseContext.Users.Update(userFound);
                    await _databaseContext.SaveChangesAsync();
                    return true;
                }
                return false;
            }
            catch (DbUpdateException dbEx)
            {
                throw new DbUpdateException(dbEx.Message);
            }
            throw new NullReferenceException();
        }

        public async Task<bool> ChangePassword(int userId, ChangePasswordRequest newPassword)
        {
            try
            {
                var userFound = await _databaseContext.Users.SingleOrDefaultAsync(u =>u.Id == userId);
                if (userFound is not null && userFound.UserName == newPassword.UserName)
                {
                    userFound.Password = newPassword.NewPassword;
                    _databaseContext.Users.Update(userFound);
                    await _databaseContext.SaveChangesAsync();
                    return true;
                }
                return false;
            }
            catch (DbUpdateException dbEx)
            {
                throw new DbUpdateException(dbEx.Message);
            }
            throw new NullReferenceException();
        }
    }
}
