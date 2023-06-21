using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyRecipes.Domain.Models
{
    public sealed class CookingStepModel
    {
        public int Id { get; set; }
        public int StepNumber { get; set; }
        public string? Instruction { get; set; }
    }
}
