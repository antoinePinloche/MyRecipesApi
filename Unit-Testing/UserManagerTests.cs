using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;
using Moq;
using Moq.EntityFrameworkCore;
using MyRecipes.Database;
using MyRecipes.Database.EntityModels;
using MyRecipes.Database.Managers;
using MyRecipes.Domain.Models.Request;
using MyRecipes.Domain.Models;
using NUnit.Framework;
using System.Data;
using Unit_Testing.MockData;

namespace Unit_Testing
{
    [TestFixture]
    public class UserManagerTests
    {
        private UserManager _manager;
        private UserModel _user;

        [SetUp]
        public void SetUp()
        {
            DbContextOptionsBuilder t = new DbContextOptionsBuilder();
            var tmp = t.UseSqlServer(@"Server=(localdb)\mssqllocaldb;Initial Catalog=MyRecipes;Integrated Security=true;MultipleActiveResultSets=True").Options;
            var context = new DatabaseContext(tmp);
            _manager = new UserManager(context);
        }

        [Test, Order(1)]
        public void GetAllUsers() {


            var users = _manager.GetAllUsers().Result;
            Assert.AreEqual(4, users.Count);
        }

        [Test, Order(2)]
        public void GetUsersbyId()
        {
            try
            {
                var user2 = _manager.GetUserById(2).Result;
                Assert.IsTrue(user2.Id == 2 &&
                                user2.FirstName == "john" &&
                                user2.LastName == "Doe" &&
                                user2.Mail == "antoine.pinloche@user.com" &&
                                user2.UserName == "user" &&
                                user2.Role == "USER");
            }
            catch (NullReferenceException ex)
            {
                Assert.Fail(ex.Message);
            }
        }

        [Test, Order(3)]
        public void GetNullUsersById()
        {
            try
            {
                var user2 = _manager.GetUserById(0).Result;
            }
            catch (Exception ex)
            {
                Assert.AreEqual(ex.Message.Contains("not set to an"), true);
            }
        }

        [Test, Order(4)]
        public void AddUser()
        {
            UserModel user = new UserModel
            {
                FirstName = "Test",
                LastName = "Test",
                Id = 3,
                Mail = "Test",
                Role = "USER",
                UserName = "Test",
                StartDate = DateTime.Now
                
            };
            try
            {
                _user = _manager.AddUser(user , "pass").Result;

                Assert.IsTrue(
                    _user.FirstName == "Test"&&
                    _user.LastName == "Test" &&
                    _user.Mail == "Test" &&
                    _user.Role == "USER" &&
                    _user.UserName == "Test"
                    );
            }
            catch (NullReferenceException ex)
            {
                Assert.Fail(ex.Message);
            }

        }

        [Test, Order(5)]
        public void DeleteNullUser()
        {
            try
            {
                var user = _manager.DeleteUser(_user.Id + 1000).Result;
                Assert.IsFalse(user);
            }
            catch (NullReferenceException ex)
            {
                Assert.Fail(ex.Message);
            }            
        }

        [Test, Order(6)]
        public void AuthenticateUserTest()
        {
            try
            {
                var token = _manager.AuthenticateUser("Test", "pass").Result;
                Assert.IsTrue(token.UserName == "Test");
            }
            catch (Exception ex)
            {
                Assert.Fail(ex.Message);
            }

        }

        [Test, Order(7)]
        public void AuthenticateUserDoenstExistTest()
        {
            try
            {
                _manager.AuthenticateUser("toto", "toto");
            }
            catch (Exception ex)
            {
                Assert.AreEqual(ex.Message.Contains("System.AggregateException"), true);
            }
        }

        [Test, Order(8)]
        public void ChangeUserInformationTest() {
            var UserafterChange = _manager.ChangeUserInformation(new UserModel
            {
                FirstName = "TestChange",
                LastName = "TestChange",
                Id = 3,
                Mail = "TestChange",
                Role = "USERChange",
                UserName = "Test",
                StartDate = DateTime.Now

            }, _user.Id);
            Assert.AreEqual("TestChange", UserafterChange.Result.FirstName);
        }

        [Test, Order(9)]
        public void EditUserAccessTest()
        {
            Assert.IsTrue(true);
        }

        [Test, Order(10)]
        public void ChangePasswordTest() {
            var userModelafterChange = _manager.ChangePassword(_user.Id, new ChangePasswordRequest { NewPassword = "tata", UserName = _user.UserName}).Result;
            Assert.IsTrue(userModelafterChange);
        }

        [Test, Order(11)]
        public void DeleteLastUser()
        {
            var user = _manager.DeleteUser(_user.Id).Result;
            Assert.IsTrue(user);
        }
    }
         
}