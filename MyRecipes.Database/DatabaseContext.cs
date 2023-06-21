using Microsoft.EntityFrameworkCore;
using MyRecipes.Database.EntityModels;
using MyRecipes.Database.Tools;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Emit;
using System.Text;
using System.Threading.Tasks;

namespace MyRecipes.Database
{
    public sealed class DatabaseContext : DbContext
    {
        public DatabaseContext(DbContextOptions options) : base(options) { }

        public DbSet<User> Users { get; set; }
        public DbSet<Recipe> Recipes { get; set; }
        public DbSet<RecipesUser> RecipesUsers { get; set; }
        public DbSet<CookingStep> CookingSteps { get; set; }
        public DbSet<Ingredient> Ingredients { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            var admin = new User
            {
                Id = 1,
                StartDate = DateTime.Now,
                FirstName = "john",
                LastName = "Doe",
                Mail = "john.Doe@noOne.com",
                Password = PasswordTool.HashPassword("password"),
                UserName = "JoDo",
                Role = "ADMIN"
            };
            var user = new User
            {
                Id = 2,
                StartDate = DateTime.Now,
                FirstName = "Peter",
                LastName = "Parker",
                Mail = "peter.parker@gmail.com",
                Password = PasswordTool.HashPassword("spiderPassword"),
                UserName = "spiderman",
                Role = "USER"
            };
            var adminBis = new User
            {
                Id = 3,
                StartDate = DateTime.Now,
                FirstName = "Clark",
                LastName = "Kent",
                Mail = "clark.kent@gmail.com",
                Password = PasswordTool.HashPassword("SuperPassword"),
                UserName = "Superman",
                Role = "ADMIN"
            };
            var userBis = new User
            {
                Id = 4,
                StartDate = DateTime.Now,
                FirstName = "Bruce",
                LastName = "Wayne",
                Mail = "Bruce.Wayne@gmail.com",
                Password = PasswordTool.HashPassword("BatPassword"),
                UserName = "Batman",
                Role = "USER"
            };


            var newRecipeUser1 = new RecipesUser { Id = 1, UserId = user.Id };
            var newRecipeUser2 = new RecipesUser { Id = 2, UserId = admin.Id };
            var newRecipeUser3 = new RecipesUser { Id = 3, UserId = userBis.Id };


            var RizCantonnais = new Recipe
            {
                Id = 1,
                Name = "Riz Frit",
                Description = "Riz avec légumes viande si envie!",
                StartDate = DateTime.Now,
                Nationality = "ASIAN",
                RecipesUserId = newRecipeUser1.Id
            };
            var PateCarbo = new Recipe
            {
                Id = 2,
                Name = "Pate Carbo",
                Description = "faire cuire des pate en parallele des lardons",
                StartDate = DateTime.Now,
                Nationality = "ITALIAN",
                RecipesUserId = newRecipeUser1.Id
            };
            var SemouleMarocain = new Recipe
            {
                Id = 3,
                Name = "Semoule Marocain",
                Description = "Semoule Carrote a la marocaine",
                StartDate = DateTime.Now,
                Nationality = "MAROCAIN",
                RecipesUserId = newRecipeUser2.Id
            };


            var ingredient = new Ingredient { Id = 1, Name ="Pate", Quantity="150g", RecipeId= PateCarbo.Id };
            var ingredient1 = new Ingredient { Id = 2, Name = "Oeuf", Quantity = "3", RecipeId = PateCarbo.Id };
            var ingredient2 = new Ingredient { Id = 3, Name = "Pancetta", Quantity = "100g", RecipeId = PateCarbo.Id };
            var ingredient3 = new Ingredient { Id = 4, Name = "Parmessan", Quantity = "100g", RecipeId = PateCarbo.Id };

            var ingredient4 = new Ingredient { Id = 5, Name = "Riz", Quantity = "150g", RecipeId = RizCantonnais.Id };
            var ingredient5 = new Ingredient { Id = 6, Name = "Oeuf", Quantity = "2", RecipeId = RizCantonnais.Id };
            var ingredient6 = new Ingredient { Id = 7, Name = "viande", Quantity = "100g", RecipeId = RizCantonnais.Id };
            var ingredient7 = new Ingredient { Id = 8, Name = "legume", Quantity = "100g", RecipeId = RizCantonnais.Id };
            var ingredient8 = new Ingredient { Id = 9, Name = "soja", Quantity = "2 cas", RecipeId = RizCantonnais.Id };


            var step = new CookingStep { Id = 1,  StepNumber = 1, Instruction = "Rapé le Parmessant et y ajouté 2 jaune d'oeuf et un oeuf entier et mélanger dans un saladier ajouter du poivre et réserver", RecipeId = PateCarbo.Id };
            var step2 = new CookingStep { Id = 2, StepNumber = 2, Instruction = "Faire cuire la pancetta en petit morceau dans un poile a feu vif et en parallère mettre l'eau a bouillir", RecipeId = PateCarbo.Id };
            var step3 = new CookingStep { Id = 3, StepNumber = 3, Instruction = "Mettre les pate dans l'eau bouillante et laisser cuire le temps indiqué.", RecipeId = PateCarbo.Id };
            var step4 = new CookingStep { Id = 4, StepNumber = 4, Instruction = "une fois les pate cuite égouter et les mettre dans les \"lardon de pancetta\" ajouter la préparation de parmessan et oeuf avec un verre de cuisson des pates et mélancer pendant 1 a 2min. Il ne vous reste plus qu'a servir", RecipeId= PateCarbo.Id };

            var step5 = new CookingStep { Id = 5, StepNumber = 1, Instruction = "Faire bouillir l'eau et mette le riz a cuire quand ébulition pendant 11minutes", RecipeId = RizCantonnais.Id };
            var step6 = new CookingStep { Id = 6, StepNumber = 2, Instruction = "mettre les oeuf dans un bol et batter les.", RecipeId = RizCantonnais.Id };
            var step7 = new CookingStep { Id = 7, StepNumber = 3, Instruction = "une fois le rie cuit mettre dans la poils avec un peux d'huile de soja", RecipeId = RizCantonnais.Id };
            var step8 = new CookingStep { Id = 8, StepNumber = 4, Instruction = "ajouter les ingredient un par en en faissant cuire chaque élément dans la poil avec les ancien ingredients", RecipeId = RizCantonnais.Id };


            modelBuilder.Entity<User>().HasData(admin, user, userBis, adminBis);
            modelBuilder.Entity<Recipe>().HasData(RizCantonnais, PateCarbo, SemouleMarocain);
            modelBuilder.Entity<RecipesUser>().HasData(newRecipeUser1, newRecipeUser2, newRecipeUser3);
            modelBuilder.Entity<Ingredient>().HasData(ingredient, ingredient1, ingredient2, ingredient3, ingredient4, ingredient5, ingredient6, ingredient7, ingredient8);
            modelBuilder.Entity<CookingStep>().HasData(step, step2, step3, step4, step5, step6, step7, step8);
        }
    }
}
