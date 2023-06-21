using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MyRecipes.Database.Migrations
{
    public partial class superMiration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Recipes",
                keyColumn: "Id",
                keyValue: 1,
                column: "StartDate",
                value: new DateTime(2023, 6, 21, 12, 51, 14, 217, DateTimeKind.Local).AddTicks(7511));

            migrationBuilder.UpdateData(
                table: "Recipes",
                keyColumn: "Id",
                keyValue: 2,
                column: "StartDate",
                value: new DateTime(2023, 6, 21, 12, 51, 14, 217, DateTimeKind.Local).AddTicks(7513));

            migrationBuilder.UpdateData(
                table: "Recipes",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "Description", "StartDate" },
                values: new object[] { "Semoule Carrote a la marocaine", new DateTime(2023, 6, 21, 12, 51, 14, 217, DateTimeKind.Local).AddTicks(7515) });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "Mail", "StartDate", "UserName" },
                values: new object[] { "john.Doe@noOne.com", new DateTime(2023, 6, 21, 12, 51, 14, 217, DateTimeKind.Local).AddTicks(7474), "JoDo" });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "FirstName", "LastName", "Mail", "Password", "StartDate", "UserName" },
                values: new object[] { "Peter", "Parker", "peter.parker@gmail.com", "spiderPassword", new DateTime(2023, 6, 21, 12, 51, 14, 217, DateTimeKind.Local).AddTicks(7502), "spiderman" });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "Password", "StartDate", "UserName" },
                values: new object[] { "SuperPassword", new DateTime(2023, 6, 21, 12, 51, 14, 217, DateTimeKind.Local).AddTicks(7504), "Superman" });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 4,
                columns: new[] { "Password", "StartDate" },
                values: new object[] { "BatPassword", new DateTime(2023, 6, 21, 12, 51, 14, 217, DateTimeKind.Local).AddTicks(7508) });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Recipes",
                keyColumn: "Id",
                keyValue: 1,
                column: "StartDate",
                value: new DateTime(2023, 6, 21, 12, 18, 47, 424, DateTimeKind.Local).AddTicks(8504));

            migrationBuilder.UpdateData(
                table: "Recipes",
                keyColumn: "Id",
                keyValue: 2,
                column: "StartDate",
                value: new DateTime(2023, 6, 21, 12, 18, 47, 424, DateTimeKind.Local).AddTicks(8507));

            migrationBuilder.UpdateData(
                table: "Recipes",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "Description", "StartDate" },
                values: new object[] { "Semoule Carrote a la maraaine", new DateTime(2023, 6, 21, 12, 18, 47, 424, DateTimeKind.Local).AddTicks(8509) });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "Mail", "StartDate", "UserName" },
                values: new object[] { "antoine.pinloche@admin.com", new DateTime(2023, 6, 21, 12, 18, 47, 424, DateTimeKind.Local).AddTicks(8463), "admin" });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "FirstName", "LastName", "Mail", "Password", "StartDate", "UserName" },
                values: new object[] { "john", "Doe", "antoine.pinloche@user.com", "password", new DateTime(2023, 6, 21, 12, 18, 47, 424, DateTimeKind.Local).AddTicks(8496), "user" });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "Password", "StartDate", "UserName" },
                values: new object[] { "string", new DateTime(2023, 6, 21, 12, 18, 47, 424, DateTimeKind.Local).AddTicks(8498), "string" });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 4,
                columns: new[] { "Password", "StartDate" },
                values: new object[] { "string", new DateTime(2023, 6, 21, 12, 18, 47, 424, DateTimeKind.Local).AddTicks(8501) });
        }
    }
}
