using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyRecipes.Domain.Models
{
    public sealed class TokenModel
    {
        public string UserName { get; set; }

        public string Token { get; set; }
    }
}
