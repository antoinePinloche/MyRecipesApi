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

namespace Unit_Testing
{
    [TestFixture]
    public class CookingStepManagerTests
    {
        private CookingStepManager _manager;
        private int _lastCSCreate;

        [SetUp]
        public void SetUp()
        {
            DbContextOptionsBuilder t = new DbContextOptionsBuilder();
            var tmp = t.UseSqlServer(@"Server=DESKTOP-SJ6V15C;Initial Catalog=MyRecipes;Integrated Security=true;MultipleActiveResultSets=True").Options;
            var context = new DatabaseContext(tmp);
            _manager = new CookingStepManager(context);
        }

        [Test, Order(1)]
        public void GetAllCookingStep()
        {
            try
            {
            var allCookingStep = _manager.GetAllCookingSteps().Result;
                Assert.AreEqual(8, allCookingStep.Count);
            }
            catch (Exception ex)
            {
                Assert.Fail(ex.Message);
            }
        }
        [Test, Order(2)]
        public void GetCookingStepById()
        {
            try
            {
                var allCookingStep = _manager.GetCookingStepsById(2).Result;
                Assert.AreEqual(allCookingStep.Id, 2);
            }
            catch (Exception ex)
            {
                Assert.Fail(ex.Message);
            }
        }
        [Test, Order(3)]
        public void GetCookingStepByIdDoesntExist()
        {
            try
            {
                var allCookingStep = _manager.GetCookingStepsById(0).Result;
            }
            catch (Exception ex)
            {
                Assert.AreEqual(ex.Message.Contains("Object reference not set to an"), true);
            }
        }
        [Test, Order(4)]
        public void CreateCookingStep()
        {
            try
            {
                var cookingsStepCreate = _manager.CreateCookingSteps(new List<CookingStepRequest>
                {
                    new CookingStepRequest
                    {
                        Instruction = "Test1",
                        StepNumber = 1,
                        RecipeId = 3,
                    },
                    new CookingStepRequest
                    {
                        Instruction = "Test2",
                        StepNumber = 2,
                        RecipeId = 3,
                    },
                    new CookingStepRequest
                    {
                        Instruction = "Test3",
                        StepNumber = 3,
                        RecipeId = 3,
                    }
                }).Result;
                _lastCSCreate = cookingsStepCreate[2].Id;
                Assert.AreEqual(3, cookingsStepCreate.Count);
            }
            catch (Exception e)
            {
                Assert.Fail(e.Message);
            }
        }
        [Test, Order(5)]
        public void GetAllCookingStepByRepiceId()
        {
            try
            {
                var cSByRecipeId = _manager.GetCookingStepsByRecipeId(3).Result;
                Assert.AreEqual(3, cSByRecipeId.Count);
            }
            catch (Exception ex)
            {
                Assert.Fail(ex.Message);
            }
        }
        [Test, Order(6)]
        public void DeleteCookingStep()
        {
            try
            {
                var cookingsStepCreate = _manager.RemoveCookingStep(_lastCSCreate).Result;
                Assert.IsTrue(cookingsStepCreate);
            }
            catch (Exception ex)
            {
                Assert.Fail(ex.Message);
            }

        }

        [Test, Order(7)]
        public void DeleteAllCookingStepByRecipeId()
        {
            try
            {
                var cookingsStepIsDelete = _manager.RemoveAllCookingStepByRecipeId(3).Result;
                Assert.IsTrue(cookingsStepIsDelete);
            }
            catch (Exception ex)
            {
                Assert.Fail(ex.Message);
            }

        }
    }
}
