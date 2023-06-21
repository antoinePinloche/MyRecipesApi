﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using MyRecipes.Database;

#nullable disable

namespace MyRecipes.Database.Migrations
{
    [DbContext(typeof(DatabaseContext))]
    [Migration("20230621113354_PasswordHashMigration")]
    partial class PasswordHashMigration
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "6.0.16")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder, 1L, 1);

            modelBuilder.Entity("MyRecipes.Database.EntityModels.CookingStep", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<string>("Instruction")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("RecipeId")
                        .HasColumnType("int");

                    b.Property<int>("StepNumber")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("RecipeId");

                    b.ToTable("CookingSteps");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Instruction = "Rapé le Parmessant et y ajouté 2 jaune d'oeuf et un oeuf entier et mélanger dans un saladier ajouter du poivre et réserver",
                            RecipeId = 2,
                            StepNumber = 1
                        },
                        new
                        {
                            Id = 2,
                            Instruction = "Faire cuire la pancetta en petit morceau dans un poile a feu vif et en parallère mettre l'eau a bouillir",
                            RecipeId = 2,
                            StepNumber = 2
                        },
                        new
                        {
                            Id = 3,
                            Instruction = "Mettre les pate dans l'eau bouillante et laisser cuire le temps indiqué.",
                            RecipeId = 2,
                            StepNumber = 3
                        },
                        new
                        {
                            Id = 4,
                            Instruction = "une fois les pate cuite égouter et les mettre dans les \"lardon de pancetta\" ajouter la préparation de parmessan et oeuf avec un verre de cuisson des pates et mélancer pendant 1 a 2min. Il ne vous reste plus qu'a servir",
                            RecipeId = 2,
                            StepNumber = 4
                        },
                        new
                        {
                            Id = 5,
                            Instruction = "Faire bouillir l'eau et mette le riz a cuire quand ébulition pendant 11minutes",
                            RecipeId = 1,
                            StepNumber = 1
                        },
                        new
                        {
                            Id = 6,
                            Instruction = "mettre les oeuf dans un bol et batter les.",
                            RecipeId = 1,
                            StepNumber = 2
                        },
                        new
                        {
                            Id = 7,
                            Instruction = "une fois le rie cuit mettre dans la poils avec un peux d'huile de soja",
                            RecipeId = 1,
                            StepNumber = 3
                        },
                        new
                        {
                            Id = 8,
                            Instruction = "ajouter les ingredient un par en en faissant cuire chaque élément dans la poil avec les ancien ingredients",
                            RecipeId = 1,
                            StepNumber = 4
                        });
                });

            modelBuilder.Entity("MyRecipes.Database.EntityModels.Ingredient", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Quantity")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("RecipeId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("RecipeId");

                    b.ToTable("Ingredients");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Name = "Pate",
                            Quantity = "150g",
                            RecipeId = 2
                        },
                        new
                        {
                            Id = 2,
                            Name = "Oeuf",
                            Quantity = "3",
                            RecipeId = 2
                        },
                        new
                        {
                            Id = 3,
                            Name = "Pancetta",
                            Quantity = "100g",
                            RecipeId = 2
                        },
                        new
                        {
                            Id = 4,
                            Name = "Parmessan",
                            Quantity = "100g",
                            RecipeId = 2
                        },
                        new
                        {
                            Id = 5,
                            Name = "Riz",
                            Quantity = "150g",
                            RecipeId = 1
                        },
                        new
                        {
                            Id = 6,
                            Name = "Oeuf",
                            Quantity = "2",
                            RecipeId = 1
                        },
                        new
                        {
                            Id = 7,
                            Name = "viande",
                            Quantity = "100g",
                            RecipeId = 1
                        },
                        new
                        {
                            Id = 8,
                            Name = "legume",
                            Quantity = "100g",
                            RecipeId = 1
                        },
                        new
                        {
                            Id = 9,
                            Name = "soja",
                            Quantity = "2 cas",
                            RecipeId = 1
                        });
                });

            modelBuilder.Entity("MyRecipes.Database.EntityModels.Recipe", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Nationality")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("RecipesUserId")
                        .HasColumnType("int");

                    b.Property<DateTime>("StartDate")
                        .HasColumnType("datetime2");

                    b.HasKey("Id");

                    b.HasIndex("RecipesUserId");

                    b.ToTable("Recipes");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Description = "Riz avec légumes viande si envie!",
                            Name = "Riz Frit",
                            Nationality = "ASIAN",
                            RecipesUserId = 1,
                            StartDate = new DateTime(2023, 6, 21, 13, 33, 54, 301, DateTimeKind.Local).AddTicks(2471)
                        },
                        new
                        {
                            Id = 2,
                            Description = "faire cuire des pate en parallele des lardons",
                            Name = "Pate Carbo",
                            Nationality = "ITALIAN",
                            RecipesUserId = 1,
                            StartDate = new DateTime(2023, 6, 21, 13, 33, 54, 301, DateTimeKind.Local).AddTicks(2485)
                        },
                        new
                        {
                            Id = 3,
                            Description = "Semoule Carrote a la marocaine",
                            Name = "Semoule Marocain",
                            Nationality = "MAROCAIN",
                            RecipesUserId = 2,
                            StartDate = new DateTime(2023, 6, 21, 13, 33, 54, 301, DateTimeKind.Local).AddTicks(2488)
                        });
                });

            modelBuilder.Entity("MyRecipes.Database.EntityModels.RecipesUser", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<int>("UserId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("UserId")
                        .IsUnique();

                    b.ToTable("RecipesUsers");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            UserId = 2
                        },
                        new
                        {
                            Id = 2,
                            UserId = 1
                        },
                        new
                        {
                            Id = 3,
                            UserId = 4
                        });
                });

            modelBuilder.Entity("MyRecipes.Database.EntityModels.User", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<string>("FirstName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("LastName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Mail")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Password")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Role")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("StartDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("UserName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Users");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            FirstName = "john",
                            LastName = "Doe",
                            Mail = "john.Doe@noOne.com",
                            Password = "smtetPdIdXb9x7V8Sd/eTRaFExpDs3ynfRseCnLBw34=",
                            Role = "ADMIN",
                            StartDate = new DateTime(2023, 6, 21, 13, 33, 54, 276, DateTimeKind.Local).AddTicks(7721),
                            UserName = "JoDo"
                        },
                        new
                        {
                            Id = 2,
                            FirstName = "Peter",
                            LastName = "Parker",
                            Mail = "peter.parker@gmail.com",
                            Password = "P9pUnYY3HiZdzZgADzXj/jE3iZ04zDTRrXm0Kne+oNg=",
                            Role = "USER",
                            StartDate = new DateTime(2023, 6, 21, 13, 33, 54, 282, DateTimeKind.Local).AddTicks(6427),
                            UserName = "spiderman"
                        },
                        new
                        {
                            Id = 4,
                            FirstName = "Bruce",
                            LastName = "Wayne",
                            Mail = "Bruce.Wayne@gmail.com",
                            Password = "gzYYaVM9sRA2hFibjSG3i6FC4l8SLHaFSUvbn3Pfe4o=",
                            Role = "USER",
                            StartDate = new DateTime(2023, 6, 21, 13, 33, 54, 294, DateTimeKind.Local).AddTicks(5027),
                            UserName = "Batman"
                        },
                        new
                        {
                            Id = 3,
                            FirstName = "Clark",
                            LastName = "Kent",
                            Mail = "clark.kent@gmail.com",
                            Password = "FlmzpZfIdpTXzlT/fanNK1vOmXseSKymJIIfJpDYfLQ=",
                            Role = "ADMIN",
                            StartDate = new DateTime(2023, 6, 21, 13, 33, 54, 288, DateTimeKind.Local).AddTicks(9144),
                            UserName = "Superman"
                        });
                });

            modelBuilder.Entity("MyRecipes.Database.EntityModels.CookingStep", b =>
                {
                    b.HasOne("MyRecipes.Database.EntityModels.Recipe", null)
                        .WithMany("CookingSteps")
                        .HasForeignKey("RecipeId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("MyRecipes.Database.EntityModels.Ingredient", b =>
                {
                    b.HasOne("MyRecipes.Database.EntityModels.Recipe", "Recipe")
                        .WithMany("Ingredients")
                        .HasForeignKey("RecipeId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Recipe");
                });

            modelBuilder.Entity("MyRecipes.Database.EntityModels.Recipe", b =>
                {
                    b.HasOne("MyRecipes.Database.EntityModels.RecipesUser", "RecipesUser")
                        .WithMany("Recipes")
                        .HasForeignKey("RecipesUserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("RecipesUser");
                });

            modelBuilder.Entity("MyRecipes.Database.EntityModels.RecipesUser", b =>
                {
                    b.HasOne("MyRecipes.Database.EntityModels.User", "User")
                        .WithOne("RecipesUser")
                        .HasForeignKey("MyRecipes.Database.EntityModels.RecipesUser", "UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("User");
                });

            modelBuilder.Entity("MyRecipes.Database.EntityModels.Recipe", b =>
                {
                    b.Navigation("CookingSteps");

                    b.Navigation("Ingredients");
                });

            modelBuilder.Entity("MyRecipes.Database.EntityModels.RecipesUser", b =>
                {
                    b.Navigation("Recipes");
                });

            modelBuilder.Entity("MyRecipes.Database.EntityModels.User", b =>
                {
                    b.Navigation("RecipesUser");
                });
#pragma warning restore 612, 618
        }
    }
}
