using MyRecipes.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyRecipes.Database.EntityModels
{
    public sealed class User
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Mail { get; set; }
        public string Password { get; set; }
        public string UserName { get; set; }
        public string Role { get; set; }
        public DateTime StartDate { get; set; }
        public RecipesUser? RecipesUser { get; set; }

        public UserModel ToUserModel()
        {
            return new UserModel
            {
                Id = Id,
                FirstName = FirstName,
                LastName = LastName,
                Mail = Mail,
                StartDate = StartDate,
                Role = Role,
                UserName = UserName
            };
        }
    }
}
