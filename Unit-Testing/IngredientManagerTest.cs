using Microsoft.EntityFrameworkCore;
using MyRecipes.Database.Managers;
using MyRecipes.Database;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MyRecipes.Domain.Interfaces.Managers;
using MyRecipes.Domain.Models.Request;
using MyRecipes.Domain.Models;

namespace Unit_Testing
{
    [TestFixture]
    public sealed class IngredientManagerTest
    {
        private IngredientManager? _manager;
        private IngredientModel? _model;

        [SetUp]
        public void SetUp()
        {
            DbContextOptionsBuilder t = new DbContextOptionsBuilder();
            var tmp = t.UseSqlServer(@"Server=(localdb)\\mssqllocaldb;Initial Catalog=MyRecipes;Integrated Security=true;MultipleActiveResultSets=True").Options;
            var context = new DatabaseContext(tmp);
            _manager = new IngredientManager(context);
        }

        [Test, Order(1)]
        public void CreateIngredientsTest()
        {
            try
            {
                var iCreated = _manager.CreateIngredients(new List<IngredientRequest> { 
                    new IngredientRequest{
                    Name = "Test1",
                    Quantity = "2CC",
                    RecipeId = 3
                    },
                    new IngredientRequest{
                    Name = "Test2",
                    Quantity = "2CC",
                    RecipeId = 3
                    },
                    new IngredientRequest{
                    Name = "Test3",
                    Quantity = "2CC",
                    RecipeId = 3
                    },
                }).Result;
                _model = iCreated[2];
                Assert.AreEqual(3, iCreated.Count);
            }
            catch (Exception ex)
            {
                Assert.Fail(ex.Message);
            }
        }

        //List<IngredientModel> CreateIngredients(List<AddIngredientRequest> ingredientsRequest)

        [Test, Order(2)]
        public void GetAllIngredientsTest()
        {
            try
            {
                var iFound = _manager.GetAllIngredients().Result;
                Assert.AreEqual(12, iFound.Count);
            }
            catch (Exception ex)
            {
                Assert.Fail(ex.Message);
            }
        }
        //bool DeleteIngredient(int ingredientId)

        [Test, Order(3)]
        public void GetIngredientByIdTest()
        {
            try
            {
                var iFound = _manager.GetIngredientById(_model.Id).Result;
                Assert.IsTrue(_model.Id == iFound.Id && _model.Name == iFound.Name && _model.Quantity == iFound.Quantity);
            }
            catch (Exception ex)
            {
                Assert.Fail(ex.Message);
            }
        }
        //bool DeleteIngredientByRecipeId(int RecipeId)

        [Test, Order(4)]
        public void FoundIngredientByRecetteIdTest()
        {
            try
            {
                var iFound = _manager.FoundIngredientByRecetteId(3).Result;
                Assert.AreEqual(3, iFound.Count);
            }
            catch (Exception ex)
            {
                Assert.Fail(ex.Message);
            }
        }
        //List<IngredientModel> FoundIngredientByRecetteId(int recetteId)
        [Test, Order(5)]
        public void DeleteIngredientTest()
        {
            try
            {
                var isDelete = _manager.DeleteIngredient(_model.Id).Result;
                Assert.IsTrue(isDelete);
            }
            catch (Exception ex)
            {
                Assert.Fail(ex.Message);
            }
        }
        //List<IngredientModel> GetAllIngredients()
        [Test, Order(6)]
        public void DeleteIngredientByRecipeIdTest()
        {
            try
            {
                var isDelete = _manager.DeleteIngredientByRecipeId(3).Result;
                Assert.IsTrue(isDelete);
            }
            catch (Exception ex)
            {
                Assert.Fail(ex.Message);
            }
        }
       
        //IngredientModel GetIngredientById(int id)


    }
}
