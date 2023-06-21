using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyRecipes.Domain.Models.Request
{
    public sealed class RecipesUserRequest
    {
        [Required]
        public int UserId { get; set; }
    }
}
