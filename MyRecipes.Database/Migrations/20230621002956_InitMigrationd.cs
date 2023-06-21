using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MyRecipes.Database.Migrations
{
    public partial class InitMigrationd : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
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

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Recipes",
                keyColumn: "Id",
                keyValue: 1,
                column: "StartDate",
                value: new DateTime(2023, 6, 21, 2, 20, 20, 881, DateTimeKind.Local).AddTicks(2618));

            migrationBuilder.UpdateData(
                table: "Recipes",
                keyColumn: "Id",
                keyValue: 2,
                column: "StartDate",
                value: new DateTime(2023, 6, 21, 2, 20, 20, 881, DateTimeKind.Local).AddTicks(2620));

            migrationBuilder.UpdateData(
                table: "Recipes",
                keyColumn: "Id",
                keyValue: 3,
                column: "StartDate",
                value: new DateTime(2023, 6, 21, 2, 20, 20, 881, DateTimeKind.Local).AddTicks(2621));

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 1,
                column: "StartDate",
                value: new DateTime(2023, 6, 21, 2, 20, 20, 881, DateTimeKind.Local).AddTicks(2548));

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 2,
                column: "StartDate",
                value: new DateTime(2023, 6, 21, 2, 20, 20, 881, DateTimeKind.Local).AddTicks(2610));

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 3,
                column: "StartDate",
                value: new DateTime(2023, 6, 21, 2, 20, 20, 881, DateTimeKind.Local).AddTicks(2612));

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 4,
                column: "StartDate",
                value: new DateTime(2023, 6, 21, 2, 20, 20, 881, DateTimeKind.Local).AddTicks(2614));
        }
    }
}
