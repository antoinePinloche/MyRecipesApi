using Microsoft.EntityFrameworkCore;
using MyRecipes.Database.Managers;
using MyRecipes.Database;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MyRecipes.Domain.Models.Request;
using MyRecipes.Domain.Models;

namespace Unit_Testing
{
    [TestFixture]
    public class RecipesManagerTest
    {
        private RecipesManager _manager;
        private RecipeModel _recipeModel;

        [SetUp]
        public void SetUp()
        {
            DbContextOptionsBuilder t = new DbContextOptionsBuilder();
            var tmp = t.UseSqlServer(@"Server=DESKTOP-SJ6V15C;Initial Catalog=MyRecipes;Integrated Security=true;MultipleActiveResultSets=True").Options;
            var context = new DatabaseContext(tmp);
            _manager = new RecipesManager(context);
        }

        [Test, Order(1)]
        public void GetAllRecipes()
        {
            try
            {
                var allRecipesFound = _manager.GetAllRecipes().Result;
                Assert.AreEqual(3, allRecipesFound.Count);
            }
            catch (Exception ex)
            {
                Assert.Fail(ex.Message);
            }
        }

        [Test, Order(2)]
        public void GetRecipeById()
        {
            try
            {
                var recipeFound = _manager.GetRecipeById(3).Result;
                Assert.IsTrue(recipeFound.Name == "Semoule Marocain");
            }
            catch (Exception ex)
            {
                Assert.Fail(ex.Message);
            }
        }

        [Test, Order(3)]
        public void GetRecetteByIngredientName()
        {
            try
            {
                var recipesFound = _manager.FoundRecetteByIngredientName("Oeuf").Result;
                Assert.AreEqual(2, recipesFound.Count);
            }
            catch (Exception ex)
            {
                Assert.Fail(ex.Message);
            }
        }

        [Test, Order(4)]
        public void GetRecipeByNationality()
        {
            try
            {
                var recipesFound = _manager.FoundRecetteByNationality("ASIAN").Result;
                Assert.AreEqual("Riz Frit", recipesFound[0].Name);

            }
            catch (Exception ex)
            {
                Assert.Fail(ex.Message);
            }

        }

        [Test, Order(5)]
        public void CreateRecipe()
        {
            try
            {
                _recipeModel = _manager.CreateRecipe(new RecipeRequest
                {
                    Name = "test",
                    Description = "test",
                    Nationality = "test",
                    RecipesUserId = 3
                }).Result;
                Assert.IsTrue(_recipeModel.Name.Equals("test"));
            }
            catch (Exception ex)
            {
                Assert.Fail(ex.Message);
            }
        }

        [Test, Order(6)]
        public void CreateRecipeWithBadRecipeUserId()
        {
            
            try
            {
                var recipeModel = _manager.CreateRecipe(new RecipeRequest
                {
                    Name = "test",
                    Description = "test",
                    Nationality = "test",
                    RecipesUserId = 4
                }).Result;
            }
            catch (Exception)
            {
                Assert.IsTrue(true);
            }
        }

        [Test, Order(7)]
        public void DeleteReciped()
        {
            try
            {
                var recipeModelIsDelete = _manager.DeleteRecipe(_recipeModel.Id).Result;
                Assert.IsTrue(recipeModelIsDelete);
            }
            catch (Exception ex)
            {
                Assert.Fail(ex.Message);
            }

        }

    }
}
