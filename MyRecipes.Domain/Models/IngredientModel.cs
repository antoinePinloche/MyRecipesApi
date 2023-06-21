using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyRecipes.Domain.Models
{
    public sealed class IngredientModel
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Quantity { get; set; }
    }
}
