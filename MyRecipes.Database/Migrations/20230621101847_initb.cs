using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MyRecipes.Database.Migrations
{
    public partial class initb : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Recipes",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "Nationality", "StartDate" },
                values: new object[] { "ASIAN", new DateTime(2023, 6, 21, 12, 18, 47, 424, DateTimeKind.Local).AddTicks(8504) });

            migrationBuilder.UpdateData(
                table: "Recipes",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "Name", "Nationality", "StartDate" },
                values: new object[] { "Pate Carbo", "ITALIAN", new DateTime(2023, 6, 21, 12, 18, 47, 424, DateTimeKind.Local).AddTicks(8507) });

            migrationBuilder.UpdateData(
                table: "Recipes",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "Name", "Nationality", "StartDate" },
                values: new object[] { "Semoule Marocain", "MAROCAIN", new DateTime(2023, 6, 21, 12, 18, 47, 424, DateTimeKind.Local).AddTicks(8509) });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 1,
                column: "StartDate",
                value: new DateTime(2023, 6, 21, 12, 18, 47, 424, DateTimeKind.Local).AddTicks(8463));

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 2,
                column: "StartDate",
                value: new DateTime(2023, 6, 21, 12, 18, 47, 424, DateTimeKind.Local).AddTicks(8496));

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 3,
                column: "StartDate",
                value: new DateTime(2023, 6, 21, 12, 18, 47, 424, DateTimeKind.Local).AddTicks(8498));

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 4,
                column: "StartDate",
                value: new DateTime(2023, 6, 21, 12, 18, 47, 424, DateTimeKind.Local).AddTicks(8501));
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Recipes",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "Nationality", "StartDate" },
                values: new object[] { "ASIA", new DateTime(2023, 6, 21, 2, 30, 26, 137, DateTimeKind.Local).AddTicks(1768) });

            migrationBuilder.UpdateData(
                table: "Recipes",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "Name", "Nationality", "StartDate" },
                values: new object[] { "PateCarbo", "ITALIA", new DateTime(2023, 6, 21, 2, 30, 26, 137, DateTimeKind.Local).AddTicks(1769) });

            migrationBuilder.UpdateData(
                table: "Recipes",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "Name", "Nationality", "StartDate" },
                values: new object[] { "SemouleMarocain", "Marocain", new DateTime(2023, 6, 21, 2, 30, 26, 137, DateTimeKind.Local).AddTicks(1771) });

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
    }
}
