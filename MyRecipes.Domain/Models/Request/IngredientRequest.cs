using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyRecipes.Domain.Models.Request
{
    public sealed class IngredientRequest
    {
        [Required]
        public string Name { get; set; }

        [Required]
        public string Quantity { get; set; }

        [Required]
        public int RecipeId { get; set; } 
    }
}
