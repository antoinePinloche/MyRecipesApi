using MyRecipes.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyRecipes.Database.EntityModels
{
    public sealed class Ingredient
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Quantity { get; set; }
        public int RecipeId { get; set; }
        public Recipe Recipe { get; set; }

        public IngredientModel ToIngredientModel()
        {
            return new IngredientModel {
                Id = Id,
                Name = Name,
                Quantity = Quantity
            };
        }
    }
}
