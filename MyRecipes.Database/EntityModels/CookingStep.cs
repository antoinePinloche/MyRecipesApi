using MyRecipes.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyRecipes.Database.EntityModels
{
    public sealed class CookingStep
    {
        public int Id { get; set; }
        public int StepNumber { get; set; }
        public string? Instruction { get; set; }
        public int RecipeId { get; set; }

        public CookingStepModel ToCookingStepModel()
        {
            return new CookingStepModel
            {
                Id = Id,
                StepNumber = StepNumber,
                Instruction = Instruction
            };
        }
    }
}
