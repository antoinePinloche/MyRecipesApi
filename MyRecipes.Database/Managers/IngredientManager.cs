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
    public sealed class IngredientManager : IIngredientManager
    {
        private readonly DatabaseContext _databaseContext;

        public IngredientManager(DatabaseContext databaseContext)
        {
            _databaseContext = databaseContext;
        }

        public async Task<List<IngredientModel>> CreateIngredients(List<IngredientRequest> ingredientsRequest)
        {
            try
            {
                var ingredientsToAdd = new List<Ingredient>();
                var ingredientsToReturn = new List<IngredientModel>();
                foreach (var ingredient in ingredientsRequest)
                {
                    ingredientsToAdd.Add(new Ingredient
                    {
                        RecipeId = ingredient.RecipeId,
                        Name = ingredient.Name,
                        Quantity = ingredient.Quantity,
                    });
                }
                await _databaseContext.Ingredients.AddRangeAsync(ingredientsToAdd);
                await _databaseContext.SaveChangesAsync();
                foreach (var ingredient in ingredientsToAdd)
                    ingredientsToReturn.Add(ingredient.ToIngredientModel());
                return ingredientsToReturn;
            }
            catch (DbUpdateException ex)
            {
                throw new DbUpdateException(ex.Message);
            }
            catch (NullReferenceException )
            {
                throw new NullReferenceException();
            }

        }

        public async Task<bool> DeleteIngredient(int ingredientId)
        {
            try
            {
                var ingredientFound = await _databaseContext.Ingredients.FirstOrDefaultAsync(i => i.Id == ingredientId);
                if (ingredientFound is not null)
                {
                    _databaseContext.Ingredients.Remove(ingredientFound);
                    await _databaseContext.SaveChangesAsync();
                    return true;
                }
                return false;
            }
            catch (DbUpdateException ex)
            {
                throw new DbUpdateException(ex.Message);
            }
            catch (NullReferenceException)
            {
                throw new NullReferenceException();
            }
        }

        public async Task<bool> DeleteIngredientByRecipeId(int recipeId)
        {
            try
            {
                var ingredientFound = await _databaseContext.Ingredients.Where(i => i.RecipeId == recipeId).ToListAsync();
                if (ingredientFound is not null)
                {
                
                    _databaseContext.Ingredients.RemoveRange(ingredientFound);
                    await _databaseContext.SaveChangesAsync();
                    return true;
                }
                return false;
            }
            catch (DbUpdateException ex)
            {
                throw new DbUpdateException(ex.Message);
            }
            catch (NullReferenceException)
            {
                throw new NullReferenceException();
            }

        }

        public async Task<List<IngredientModel>> FoundIngredientByRecetteId(int recetteId)
        {
            try
            {
                return await _databaseContext.Ingredients
                                            .Where( i => i.RecipeId == recetteId )
                                            .Select( i => i.ToIngredientModel())
                                            .ToListAsync();
                
            }
            catch (DbUpdateException ex)
            {
                throw new DbUpdateException(ex.Message);
            }
            catch (NullReferenceException)
            {
                throw new NullReferenceException();
            }

        }

        public async Task<List<IngredientModel>> GetAllIngredients()
        {
            try
            {
                return await _databaseContext.Ingredients.Select(i => new IngredientModel
                {
                    Id = i.Id,
                    Quantity = i.Quantity,
                    Name = i.Name
                }).ToListAsync();
            }
            catch (DbUpdateException ex)
            {
                throw new DbUpdateException(ex.Message);
            }
            catch (NullReferenceException)
            {
                throw new NullReferenceException();
            }
        }

        public async Task<IngredientModel> GetIngredientById(int id)
        {
            try
            {
                var ingredientFound = await _databaseContext.Ingredients.FirstOrDefaultAsync(i => i.Id == id);
                if (ingredientFound is not null)
                {
                    return ingredientFound.ToIngredientModel();
                }
            }
            catch (DbUpdateException ex)
            {
                throw new DbUpdateException(ex.Message);
            }
            throw new NullReferenceException();
        }
    }
}
