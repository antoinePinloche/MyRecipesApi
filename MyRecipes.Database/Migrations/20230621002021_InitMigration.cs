using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MyRecipes.Database.Migrations
{
    public partial class InitMigration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Users",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    FirstName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    LastName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Mail = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Password = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    UserName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Role = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    StartDate = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Users", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "RecipesUsers",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RecipesUsers", x => x.Id);
                    table.ForeignKey(
                        name: "FK_RecipesUsers_Users_UserId",
                        column: x => x.UserId,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Recipes",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    StartDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Nationality = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    RecipesUserId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Recipes", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Recipes_RecipesUsers_RecipesUserId",
                        column: x => x.RecipesUserId,
                        principalTable: "RecipesUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "CookingSteps",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    StepNumber = table.Column<int>(type: "int", nullable: false),
                    Instruction = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    RecipeId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CookingSteps", x => x.Id);
                    table.ForeignKey(
                        name: "FK_CookingSteps_Recipes_RecipeId",
                        column: x => x.RecipeId,
                        principalTable: "Recipes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Ingredients",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Quantity = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    RecipeId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Ingredients", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Ingredients_Recipes_RecipeId",
                        column: x => x.RecipeId,
                        principalTable: "Recipes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "Id", "FirstName", "LastName", "Mail", "Password", "Role", "StartDate", "UserName" },
                values: new object[,]
                {
                    { 1, "john", "Doe", "antoine.pinloche@admin.com", "password", "ADMIN", new DateTime(2023, 6, 21, 2, 20, 20, 881, DateTimeKind.Local).AddTicks(2548), "admin" },
                    { 2, "john", "Doe", "antoine.pinloche@user.com", "password", "USER", new DateTime(2023, 6, 21, 2, 20, 20, 881, DateTimeKind.Local).AddTicks(2610), "user" },
                    { 3, "Clark", "Kent", "clark.kent@gmail.com", "string", "ADMIN", new DateTime(2023, 6, 21, 2, 20, 20, 881, DateTimeKind.Local).AddTicks(2612), "string" },
                    { 4, "Bruce", "Wayne", "Bruce.Wayne@gmail.com", "string", "USER", new DateTime(2023, 6, 21, 2, 20, 20, 881, DateTimeKind.Local).AddTicks(2614), "Batman" }
                });

            migrationBuilder.InsertData(
                table: "RecipesUsers",
                columns: new[] { "Id", "UserId" },
                values: new object[] { 1, 2 });

            migrationBuilder.InsertData(
                table: "RecipesUsers",
                columns: new[] { "Id", "UserId" },
                values: new object[] { 2, 1 });

            migrationBuilder.InsertData(
                table: "Recipes",
                columns: new[] { "Id", "Description", "Name", "Nationality", "RecipesUserId", "StartDate" },
                values: new object[] { 1, "Riz avec légumes viande si envie!", "Riz Frit", "ASIA", 1, new DateTime(2023, 6, 21, 2, 20, 20, 881, DateTimeKind.Local).AddTicks(2618) });

            migrationBuilder.InsertData(
                table: "Recipes",
                columns: new[] { "Id", "Description", "Name", "Nationality", "RecipesUserId", "StartDate" },
                values: new object[] { 2, "faire cuire des pate en parallele des lardons", "PateCarbo", "ITALIA", 1, new DateTime(2023, 6, 21, 2, 20, 20, 881, DateTimeKind.Local).AddTicks(2620) });

            migrationBuilder.InsertData(
                table: "Recipes",
                columns: new[] { "Id", "Description", "Name", "Nationality", "RecipesUserId", "StartDate" },
                values: new object[] { 3, "Semoule Carrote a la maraaine", "SemouleMarocain", "Marocain", 2, new DateTime(2023, 6, 21, 2, 20, 20, 881, DateTimeKind.Local).AddTicks(2621) });

            migrationBuilder.InsertData(
                table: "CookingSteps",
                columns: new[] { "Id", "Instruction", "RecipeId", "StepNumber" },
                values: new object[,]
                {
                    { 1, "Rapé le Parmessant et y ajouté 2 jaune d'oeuf et un oeuf entier et mélanger dans un saladier ajouter du poivre et réserver", 2, 1 },
                    { 2, "Faire cuire la pancetta en petit morceau dans un poile a feu vif et en parallère mettre l'eau a bouillir", 2, 2 },
                    { 3, "Mettre les pate dans l'eau bouillante et laisser cuire le temps indiqué.", 2, 3 },
                    { 4, "une fois les pate cuite égouter et les mettre dans les \"lardon de pancetta\" ajouter la préparation de parmessan et oeuf avec un verre de cuisson des pates et mélancer pendant 1 a 2min. Il ne vous reste plus qu'a servir", 2, 4 },
                    { 5, "Faire bouillir l'eau et mette le riz a cuire quand ébulition pendant 11minutes", 1, 1 },
                    { 6, "mettre les oeuf dans un bol et batter les.", 1, 2 },
                    { 7, "une fois le rie cuit mettre dans la poils avec un peux d'huile de soja", 1, 3 },
                    { 8, "ajouter les ingredient un par en en faissant cuire chaque élément dans la poil avec les ancien ingredients", 1, 4 }
                });

            migrationBuilder.InsertData(
                table: "Ingredients",
                columns: new[] { "Id", "Name", "Quantity", "RecipeId" },
                values: new object[,]
                {
                    { 1, "Pate", "150g", 2 },
                    { 2, "Oeuf", "3", 2 },
                    { 3, "Pancetta", "100g", 2 },
                    { 4, "Parmessan", "100g", 2 },
                    { 5, "Riz", "150g", 1 },
                    { 6, "Oeuf", "2", 1 },
                    { 7, "viande", "100g", 1 },
                    { 8, "legume", "100g", 1 },
                    { 9, "soja", "2 cas", 1 }
                });

            migrationBuilder.CreateIndex(
                name: "IX_CookingSteps_RecipeId",
                table: "CookingSteps",
                column: "RecipeId");

            migrationBuilder.CreateIndex(
                name: "IX_Ingredients_RecipeId",
                table: "Ingredients",
                column: "RecipeId");

            migrationBuilder.CreateIndex(
                name: "IX_Recipes_RecipesUserId",
                table: "Recipes",
                column: "RecipesUserId");

            migrationBuilder.CreateIndex(
                name: "IX_RecipesUsers_UserId",
                table: "RecipesUsers",
                column: "UserId",
                unique: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "CookingSteps");

            migrationBuilder.DropTable(
                name: "Ingredients");

            migrationBuilder.DropTable(
                name: "Recipes");

            migrationBuilder.DropTable(
                name: "RecipesUsers");

            migrationBuilder.DropTable(
                name: "Users");
        }
    }
}
