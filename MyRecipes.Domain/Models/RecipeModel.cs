using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyRecipes.Domain.Models
{
    public sealed class RecipeModel
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public DateTime StartDate { get; set; }
        public string Description { get; set; }
        public string Nationnality { get; set; }
        public List<IngredientModel> Ingredients { get; set; }
        public List<CookingStepModel> CookingSteps { get; set; }
    }
}
