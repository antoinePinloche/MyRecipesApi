using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using MyRecipes.Database.EntityModels;
using MyRecipes.Domain.Interfaces.Managers;
using MyRecipes.Domain.Models;
using MyRecipes.Domain.Models.Request;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyRecipes.Database.Managers
{
    public sealed class RecipesUserManager : IRecipesUserManager
    {
        private readonly DatabaseContext _databaseContext;

        public RecipesUserManager(DatabaseContext databaseContext)
        {
            _databaseContext = databaseContext;
        }

        public async Task<RecipesUserModel> CreateRecipesUser(RecipesUserRequest user)
        {
            try
            {
                RecipesUserModel modelRet;
                var recipesUserFound = await _databaseContext.RecipesUsers.FirstOrDefaultAsync(rU => rU.UserId == user.UserId);
                var userExist = await _databaseContext.Users.FirstOrDefaultAsync(u => u.Id == user.UserId);
                if (recipesUserFound is null && userExist is not null)
                {
                    var recipesUserToAdd = new RecipesUser()
                    {
                        UserId = user.UserId
                    };
                    await _databaseContext.RecipesUsers.AddAsync(recipesUserToAdd);
                    await _databaseContext.SaveChangesAsync();
                    var userToAdd = _databaseContext.Users.FirstOrDefault(u => u.Id == user.UserId);
                    modelRet = new RecipesUserModel
                    {
                        Id = recipesUserToAdd.Id,
                        User = userToAdd.ToUserModel()
                    };
                    return modelRet;
                }
                
            }
            catch (NullReferenceException ex)
            {
                throw new NullReferenceException(ex.Message);
            }
            catch (DbUpdateException ex)
            {
                throw new DbUpdateException(ex.Message);
            }
            throw new NullReferenceException();
        }

        public async Task<bool> DeleteRecipesUser(int recipesUserId)
        {
            try
            {
                var userFound = await _databaseContext.RecipesUsers.FirstOrDefaultAsync(u => u.Id == recipesUserId);
                if (userFound is not null)
                {
                    var recipes = await _databaseContext.Recipes.Where(r => r.RecipesUserId == recipesUserId).ToListAsync();
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
                    _databaseContext.RecipesUsers.Remove(userFound);
                    await _databaseContext.SaveChangesAsync();
                    return true;
                }
                return false;
            }
            catch (NullReferenceException)
            {
                throw new NullReferenceException();
            }
            catch (DbUpdateException ex)
            {
                throw new DbUpdateException(ex.Message);
            }
        }

        public async Task<List<RecipesUserModel>> GetAllRecipesUser()
        {
            try
            {
                var recipesUserFound = await _databaseContext.RecipesUsers.Select(r =>

                 new RecipesUserModel()
                 {
                     Id = r.Id,
                     User = r.User.ToUserModel(),
                     Recipes = _databaseContext.Recipes.Where(rs => rs.RecipesUserId == r.Id)
                        .Select(p => new RecipeModel
                        {
                            Id = p.Id,
                            Name = p.Name,
                            Description = p.Description,
                            StartDate = p.StartDate,
                            CookingSteps = p.CookingSteps.Select(c => c.ToCookingStepModel()).ToList(),
                            Ingredients = p.Ingredients.Select(c =>c.ToIngredientModel()).ToList()
                        }).ToList()
                     }).ToListAsync();
                return recipesUserFound;
            }
            catch (NullReferenceException)
            {
                throw new NullReferenceException();
            }
            catch (DbUpdateException ex)
            {
                throw new DbUpdateException(ex.Message);
            }
        }

        public async Task<RecipesUserModel> GetRecipesUserById(int Id)
        {

            try
            {
                RecipesUserModel model;
                var recipesUserFound = await _databaseContext.RecipesUsers.FirstOrDefaultAsync(r => r.UserId == Id);

                if (recipesUserFound is not null)
                {
                    var user = await _databaseContext.Users.FirstOrDefaultAsync(u => u.Id == recipesUserFound.UserId);
                    model = new RecipesUserModel()
                    {
                        User = user.ToUserModel(),
                        Recipes = new List<RecipeModel>()
                    };
                    model.Recipes = await _databaseContext.Recipes.Where(r => r.RecipesUserId == recipesUserFound.Id)
                        .Select(p => p.ToRecipeModel()).ToListAsync();
                    return model;
                }
                
            }
            catch (DbUpdateException ex)
            {
                throw new DbUpdateException(ex.Message);
            }
            catch (NullReferenceException ex)
            {
                throw new NullReferenceException(ex.Message);
            }
            throw new NullReferenceException();
        }
    }
}
