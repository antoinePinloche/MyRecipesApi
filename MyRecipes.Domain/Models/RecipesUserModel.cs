using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyRecipes.Domain.Models
{
    public sealed class RecipesUserModel
    {
        public int Id { get; set; }
        public UserModel User { get; set; }
        public List<RecipeModel> Recipes { get; set; }
    }
}
