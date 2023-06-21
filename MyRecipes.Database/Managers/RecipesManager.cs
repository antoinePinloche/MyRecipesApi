using MyRecipes.Domain.Interfaces.Managers;
using MyRecipes.Domain.Models;
using MyRecipes.Database.EntityModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MyRecipes.Domain.Models.Request;
using Microsoft.EntityFrameworkCore;

namespace MyRecipes.Database.Managers
{

    public sealed class RecipesManager : IRecipesManager
    {
        private readonly DatabaseContext _databaseContext;

        public RecipesManager(DatabaseContext databaseContext)
        {
            _databaseContext = databaseContext;
        }


        private RecipeModel CreateRecipeModel(Recipe recipeParam)
        {
            if (recipeParam is null)
                throw new NullReferenceException("recipeParam");
            var recipeRet = recipeParam.ToRecipeModel();
            var ingredients = _databaseContext.Ingredients.Where(i => i.RecipeId == recipeParam.Id).ToList();
            if (ingredients.Any())
            {
                recipeRet.Ingredients = ingredients
                            .Select(i => i.ToIngredientModel()).ToList();
            }
            var cookingSteps = _databaseContext.CookingSteps.Where(i => i.RecipeId == recipeParam.Id).ToList();
            if (cookingSteps.Any())
            {
                recipeRet.CookingSteps = cookingSteps
                            .Select(i => i.ToCookingStepModel()).ToList();
            }
            return recipeRet;
        }
        private List<RecipeModel> CreateRecipeModelList(List<Recipe> recipes)
        {
            List<RecipeModel> recipesRet = new();
            foreach (var recipe in recipes)
            {
                recipesRet.Add(CreateRecipeModel(recipe));
            }
            return recipesRet;
        }

        public async Task<RecipeModel> CreateRecipe(RecipeRequest repiceRequest)
        {
            try
            {
                Recipe recipe;
                var recipeUserCheck = await _databaseContext.RecipesUsers.FirstOrDefaultAsync(ru => ru.Id == repiceRequest.RecipesUserId);
                if (recipeUserCheck is not null)
                {
                    recipe = new Recipe
                    {
                        Name = repiceRequest.Name,
                        Description = repiceRequest.Description,
                        Nationality = repiceRequest.Nationality,
                        RecipesUserId = repiceRequest.RecipesUserId,
                        StartDate = DateTime.Now
                    };

                    await _databaseContext.Recipes.AddAsync(recipe);
                    await _databaseContext.SaveChangesAsync();
                    return recipe.ToRecipeModel();
                }
            }
            catch (DbUpdateException dbEx)
            {
                throw new DbUpdateException(dbEx.Message);
            }
            throw new NullReferenceException();
        }

        public async Task<bool> DeleteRecipe(int recipesId)
        {
            try
            {
                var recipeFound = await _databaseContext.Recipes.FirstOrDefaultAsync(r => r.Id == recipesId);
                if (recipeFound is not null)
                {
                    var checkSteps = await _databaseContext.CookingSteps.Where(r => r.RecipeId == recipesId).ToListAsync();
                    var checkIngredients = await _databaseContext.Ingredients.Where(r => r.RecipeId == recipesId).ToListAsync();
                    if (checkSteps is not null)
                        _databaseContext.CookingSteps.RemoveRange(checkSteps);
                    if (checkIngredients is not null)
                        _databaseContext.Ingredients.RemoveRange(checkIngredients);
                    _databaseContext.Recipes.Remove(recipeFound);
                    await _databaseContext.SaveChangesAsync();
                    return true;
                }
            }
            catch (DbUpdateException dbEx)
            {
                throw new DbUpdateException(dbEx.Message);
            }
            throw new NullReferenceException();

        }

        public async Task<List<RecipeModel>> FoundRecetteByIngredientName(string ingredient)
        {
            try
            {
                List<Ingredient> allIngredients;
                allIngredients = await _databaseContext.Ingredients.Where(i => i.Name == ingredient).ToListAsync();
                if (allIngredients is not null && allIngredients.Count > 0)
                {
                    List<RecipeModel> ret = new();
                    foreach (var ingredients in allIngredients)
                    {
                        var recipe = await _databaseContext.Recipes.FirstOrDefaultAsync(r => r.Id == ingredients.RecipeId);
                        if (recipe is not null)
                        {
                            ret.Add(CreateRecipeModel(recipe));
                        }
                    }
                    return ret;
                }
            }
            catch (DbUpdateException dbEx)
            {
                throw new DbUpdateException(dbEx.Message);
            }
            throw new NullReferenceException();
        }


        public async Task<List<RecipeModel>> FoundRecetteByNationality(string nationality)
        {
            try
            {
                var recipesFound = await _databaseContext.Recipes.Where(r => r.Nationality == nationality.ToUpper()).ToListAsync();

                List<RecipeModel> recipeRet = null;
                if (recipesFound is not null && recipesFound.Count > 0)
                {
                    recipeRet = CreateRecipeModelList(recipesFound);
                }
                return recipeRet;
            }
            catch (DbUpdateException dbEx)
            {
                throw new DbUpdateException(dbEx.Message);
            }
            throw new NullReferenceException();

        }

        public async Task<List<RecipeModel>> GetAllRecipes()
        {
            try
            {
                List<Recipe> allRecipes = await _databaseContext.Recipes.Select(recipe => recipe).ToListAsync();

                if (allRecipes is not null)
                    return CreateRecipeModelList(allRecipes);
            }
            catch (DbUpdateConcurrencyException dbEx)
            {
                throw new DbUpdateConcurrencyException(dbEx.Message);
            }   
            throw new NullReferenceException();
        }

        public async Task<RecipeModel> GetRecipeById(int id)
        {
            RecipeModel recipeRet = null;
            try
            {
                var recipeFound = await _databaseContext.Recipes.FirstOrDefaultAsync(r => r.Id == id);
                if (recipeFound is not null)
                    return CreateRecipeModel(recipeFound);
            }
            catch (DbUpdateConcurrencyException dbEx)
            {
                throw new DbUpdateConcurrencyException(dbEx.Message);
            }    
            throw new NullReferenceException();
        }

        public async Task<RecipeModel> ModifyRecipe(RecipeRequest recipeRequest, int id)
        {
            
            try
            {
                var recipeFound = await _databaseContext.Recipes.FirstOrDefaultAsync(r => r.Id == id);
                recipeFound.Nationality = recipeRequest.Nationality;
                recipeFound.Name = recipeRequest.Name;
                recipeFound.Description = recipeRequest.Description;
                _databaseContext.Recipes.Update(recipeFound);
                await _databaseContext.SaveChangesAsync();
                return CreateRecipeModel(recipeFound);
            }
            catch (DbUpdateConcurrencyException dbEx)
            {
                throw new DbUpdateConcurrencyException(dbEx.Message);
            }
            catch 
            { 
                throw new NullReferenceException(); 
            }
            throw new NullReferenceException();
        }
    }
}
