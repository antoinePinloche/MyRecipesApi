using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyRecipes.Domain.Models.Request
{
    public sealed class CookingStepRequest
    {
        [Required]
        public string? Instruction { get; set; }
        [Required]
        public int StepNumber { get; set; }
        [Required]
        public int RecipeId { get; set; }
    }
}
