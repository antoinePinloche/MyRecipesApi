using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MyRecipes.Database.Migrations
{
    public partial class InitMigrationa : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Recipes",
                keyColumn: "Id",
                keyValue: 1,
                column: "StartDate",
                value: new DateTime(2023, 6, 21, 2, 30, 26, 137, DateTimeKind.Local).AddTicks(1768));

            migrationBuilder.UpdateData(
                table: "Recipes",
                keyColumn: "Id",
                keyValue: 2,
                column: "StartDate",
                value: new DateTime(2023, 6, 21, 2, 30, 26, 137, DateTimeKind.Local).AddTicks(1769));

            migrationBuilder.UpdateData(
                table: "Recipes",
                keyColumn: "Id",
                keyValue: 3,
                column: "StartDate",
                value: new DateTime(2023, 6, 21, 2, 30, 26, 137, DateTimeKind.Local).AddTicks(1771));

            migrationBuilder.InsertData(
                table: "RecipesUsers",
                columns: new[] { "Id", "UserId" },
                values: new object[] { 3, 4 });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 1,
                column: "StartDate",
                value: new DateTime(2023, 6, 21, 2, 30, 26, 137, DateTimeKind.Local).AddTicks(1663));

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 2,
                column: "StartDate",
                value: new DateTime(2023, 6, 21, 2, 30, 26, 137, DateTimeKind.Local).AddTicks(1754));

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 3,
                column: "StartDate",
                value: new DateTime(2023, 6, 21, 2, 30, 26, 137, DateTimeKind.Local).AddTicks(1758));

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 4,
                column: "StartDate",
                value: new DateTime(2023, 6, 21, 2, 30, 26, 137, DateTimeKind.Local).AddTicks(1762));
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "RecipesUsers",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.UpdateData(
                table: "Recipes",
                keyColumn: "Id",
                keyValue: 1,
                column: "StartDate",
                value: new DateTime(2023, 6, 21, 2, 29, 56, 563, DateTimeKind.Local).AddTicks(3777));

            migrationBuilder.UpdateData(
                table: "Recipes",
                keyColumn: "Id",
                keyValue: 2,
                column: "StartDate",
                value: new DateTime(2023, 6, 21, 2, 29, 56, 563, DateTimeKind.Local).AddTicks(3779));

            migrationBuilder.UpdateData(
                table: "Recipes",
                keyColumn: "Id",
                keyValue: 3,
                column: "StartDate",
                value: new DateTime(2023, 6, 21, 2, 29, 56, 563, DateTimeKind.Local).AddTicks(3781));

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 1,
                column: "StartDate",
                value: new DateTime(2023, 6, 21, 2, 29, 56, 563, DateTimeKind.Local).AddTicks(3742));

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 2,
                column: "StartDate",
                value: new DateTime(2023, 6, 21, 2, 29, 56, 563, DateTimeKind.Local).AddTicks(3770));

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 3,
                column: "StartDate",
                value: new DateTime(2023, 6, 21, 2, 29, 56, 563, DateTimeKind.Local).AddTicks(3772));

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 4,
                column: "StartDate",
                value: new DateTime(2023, 6, 21, 2, 29, 56, 563, DateTimeKind.Local).AddTicks(3774));
        }
    }
}
