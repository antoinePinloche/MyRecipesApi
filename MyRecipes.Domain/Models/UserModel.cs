using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyRecipes.Domain.Models
{
    public sealed class UserModel
    {
            public int Id { get; set; }
            public string FirstName { get; set; }
            public string LastName { get; set; }
            public string UserName { get; set; }
            public string Mail { get; set; }
            public string Role { get; set; }
            public DateTime StartDate { get; set; }

    }
}
