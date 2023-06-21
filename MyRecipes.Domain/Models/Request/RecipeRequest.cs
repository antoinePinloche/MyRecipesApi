using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyRecipes.Domain.Models.Request
{
    public sealed class RecipeRequest
    {
        [Required]
        public string Name { get; set; }
        [Required]
        public string Description { get; set; }
        [Required]
        public string Nationality { get; set; }
        [Required]
        public int RecipesUserId { get; set; }
    }
}
