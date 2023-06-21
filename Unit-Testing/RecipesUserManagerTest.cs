using Microsoft.EntityFrameworkCore;
using MyRecipes.Database;
using MyRecipes.Database.Managers;
using MyRecipes.Domain.Models.Request;
using MyRecipes.Domain.Models;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MyRecipes.Database.EntityModels;

namespace Unit_Testing
{
    [TestFixture]
    public class RecipesUserManagerTest
    {
        private RecipesUserManager _manager;
        private RecipesUserModel _recipesUser;

        [SetUp]
        public void SetUp()
        {
            DbContextOptionsBuilder t = new DbContextOptionsBuilder();
            var tmp = t.UseSqlServer(@"Server=(localdb)\\mssqllocaldb;Initial Catalog=MyRecipes;Integrated Security=true;MultipleActiveResultSets=True").Options;
            var context = new DatabaseContext(tmp);
            _manager = new RecipesUserManager(context);
        }

        [Test, Order(1)]
        public void GetallRU()
        {
            var rU = _manager.GetAllRecipesUser().Result;
            if (rU is not null)
                Assert.AreEqual(3, rU.Count);
        }
        [Test, Order(2)]
        public void GetRUById()
        {
            try
            {
                var rU = _manager.GetRecipesUserById(2).Result;
                Assert.AreEqual(2, rU.Recipes.Count);
            }
            catch (Exception ex)
            {
                Assert.Fail(ex.Message);
            }
        }
        [Test, Order(3)]
        public void GetRUByIdDoesntExist()
        {
            try
            {
                var rU = _manager.GetRecipesUserById(280).Result;
            }
            catch (Exception ex)
            {
                Assert.AreEqual(ex.Message.Contains("not set to"), true);
            }
        }
        [Test, Order(4)]
        public void CreateRU()
        {
            try
            {
                _recipesUser = _manager.CreateRecipesUser(new RecipesUserRequest { UserId = 3}).Result;
                Assert.IsTrue(_recipesUser.User.Id == 3);
            }
            catch (Exception ex)
            {
                Assert.Fail(ex.Message);
            }

        }

        [Test, Order(5)]
        public void CreateRUAllReadyExist()
        {
            try
            {
                var recipesUser = _manager.CreateRecipesUser(new RecipesUserRequest { UserId = 3 }).Result;
            }
            catch(Exception ex)
            {
                Assert.AreEqual(ex.Message.Contains("set to"), true);
            }
        }

        [Test, Order(6)]
        public void DeleteRu()
        {
            try
            {
                var uRDisDelete = _manager.DeleteRecipesUser(_recipesUser.Id).Result;
                Assert.IsTrue(uRDisDelete);
            }
            catch (Exception ex)
            {
                Assert.Fail(ex.Message);
            }

        }

        [Test, Order(7)]
        public void DeleteRuDoentexist()
        {
            try
            {
                var uRDisDelete = _manager.DeleteRecipesUser(_recipesUser.Id).Result;
                Assert.IsFalse(uRDisDelete);
            }
            catch (Exception ex)
            {
                Assert.Fail(ex.Message);
            }


        }
    }
}
