using MyRecipes.Database.EntityModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Unit_Testing.MockData
{
    public static class DataUsersHelper
    {
        public static List<User> GetFakeUserList()
        {
            return new List<User>()
            {
                new User
                {
                    Id = 1,
                    StartDate = DateTime.Now,
                    FirstName = "john",
                    LastName = "Doe",
                    Mail = "antoine.pinloche@admin.com",
                    Password = "password",
                    UserName = "admin",
                    Role = "ADMIN"
                },
                new User
                {
                    Id = 2,
                    StartDate = DateTime.Now,
                    FirstName = "john",
                    LastName = "Doe",
                    Mail = "antoine.pinloche@user.com",
                    Password = "password",
                    UserName = "user",
                    Role = "USER"
                }
        };
}
    }
}
