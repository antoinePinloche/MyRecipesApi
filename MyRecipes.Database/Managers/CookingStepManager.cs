using MyRecipes.Database.EntityModels;
using MyRecipes.Domain.Interfaces.Managers;
using MyRecipes.Domain.Models;
using MyRecipes.Domain.Models.Request;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyRecipes.Database.Managers
{
    public class CookingStepManager : ICookingStepsManager
    {
        private readonly DatabaseContext _databaseContext;

        public CookingStepManager(DatabaseContext databaseContext)
        {
            _databaseContext = databaseContext;
        }
        public async Task<List<CookingStepModel>> CreateCookingSteps(List<CookingStepRequest> models)
        {

            try
            {
                var cookingStepToAdd = new List<CookingStep>();
                var cookingStepToAddModel = new List<CookingStepModel>();
                foreach (var model in models)
                {
                    var cookingStep = new CookingStep
                    {
                        Instruction = model.Instruction,
                        RecipeId = model.RecipeId,
                        StepNumber = model.StepNumber,

                    };
                    cookingStepToAdd.Add(cookingStep);
                }
                await _databaseContext.CookingSteps.AddRangeAsync(cookingStepToAdd);
                await _databaseContext.SaveChangesAsync();
                foreach (var model in cookingStepToAdd)
                {
                    cookingStepToAddModel.Add(model.ToCookingStepModel());
                }
                return cookingStepToAddModel;
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

        public Task<List<CookingStepModel>> GetAllCookingSteps()
        {
            try
            {
                return _databaseContext.CookingSteps.Select(cs =>
                    cs.ToCookingStepModel()
                    ).ToListAsync();
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

        public async Task<CookingStepModel> GetCookingStepsById(int id)
        {
            try
            {
                CookingStep cookingStepFound = await _databaseContext.CookingSteps.FirstOrDefaultAsync(cs => cs.Id == id);
                return cookingStepFound.ToCookingStepModel();
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

        public async Task<List<CookingStepModel>> GetCookingStepsByRecipeId(int recipeId)
        {
            try
            {
                List<CookingStep> cookingStepFound = await _databaseContext.CookingSteps.Where(cs => cs.RecipeId == recipeId).ToListAsync();
                List<CookingStepModel> cookingStepModelReturn;
                if (cookingStepFound.Count > 0)
                {
                    cookingStepModelReturn = new List<CookingStepModel>();
                    foreach (var cs in cookingStepFound)
                    {
                        cookingStepModelReturn.Add(cs.ToCookingStepModel());
                    }
                    return cookingStepModelReturn;
                }
                
            }
            catch (DbUpdateException dbEx)
            {
                throw new DbUpdateException(dbEx.Message);
            }
            catch (NullReferenceException)
            {
                throw new NullReferenceException();
            }
            throw new NullReferenceException();
        }

        public async Task<bool> RemoveAllCookingStepByRecipeId(int recipeId)
        {

            try
            {
                var cookingStepsToRemove = await _databaseContext.CookingSteps.Where(cs => cs.RecipeId == recipeId).ToListAsync();
                if (cookingStepsToRemove is not null && cookingStepsToRemove.Count > 0)
                {
                    _databaseContext.CookingSteps.RemoveRange(cookingStepsToRemove);
                    await _databaseContext.SaveChangesAsync();
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

        public async Task<bool> RemoveCookingStep(int id)
        {
            try
            {
                var cookingStepToRemove = await _databaseContext.CookingSteps.FirstOrDefaultAsync(cs => cs.Id == id);
                if (cookingStepToRemove is not null)
                {
                    _databaseContext.CookingSteps.Remove(cookingStepToRemove);
                    await _databaseContext.SaveChangesAsync();
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
    }
}
