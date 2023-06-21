using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MyRecipes.Database.Migrations
{
    public partial class PasswordHashMigration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Recipes",
                keyColumn: "Id",
                keyValue: 1,
                column: "StartDate",
                value: new DateTime(2023, 6, 21, 13, 33, 54, 301, DateTimeKind.Local).AddTicks(2471));

            migrationBuilder.UpdateData(
                table: "Recipes",
                keyColumn: "Id",
                keyValue: 2,
                column: "StartDate",
                value: new DateTime(2023, 6, 21, 13, 33, 54, 301, DateTimeKind.Local).AddTicks(2485));

            migrationBuilder.UpdateData(
                table: "Recipes",
                keyColumn: "Id",
                keyValue: 3,
                column: "StartDate",
                value: new DateTime(2023, 6, 21, 13, 33, 54, 301, DateTimeKind.Local).AddTicks(2488));

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "Password", "StartDate" },
                values: new object[] { "smtetPdIdXb9x7V8Sd/eTRaFExpDs3ynfRseCnLBw34=", new DateTime(2023, 6, 21, 13, 33, 54, 276, DateTimeKind.Local).AddTicks(7721) });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "Password", "StartDate" },
                values: new object[] { "P9pUnYY3HiZdzZgADzXj/jE3iZ04zDTRrXm0Kne+oNg=", new DateTime(2023, 6, 21, 13, 33, 54, 282, DateTimeKind.Local).AddTicks(6427) });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "Password", "StartDate" },
                values: new object[] { "FlmzpZfIdpTXzlT/fanNK1vOmXseSKymJIIfJpDYfLQ=", new DateTime(2023, 6, 21, 13, 33, 54, 288, DateTimeKind.Local).AddTicks(9144) });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 4,
                columns: new[] { "Password", "StartDate" },
                values: new object[] { "gzYYaVM9sRA2hFibjSG3i6FC4l8SLHaFSUvbn3Pfe4o=", new DateTime(2023, 6, 21, 13, 33, 54, 294, DateTimeKind.Local).AddTicks(5027) });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
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
                column: "StartDate",
                value: new DateTime(2023, 6, 21, 12, 51, 14, 217, DateTimeKind.Local).AddTicks(7515));

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "Password", "StartDate" },
                values: new object[] { "password", new DateTime(2023, 6, 21, 12, 51, 14, 217, DateTimeKind.Local).AddTicks(7474) });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "Password", "StartDate" },
                values: new object[] { "spiderPassword", new DateTime(2023, 6, 21, 12, 51, 14, 217, DateTimeKind.Local).AddTicks(7502) });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "Password", "StartDate" },
                values: new object[] { "SuperPassword", new DateTime(2023, 6, 21, 12, 51, 14, 217, DateTimeKind.Local).AddTicks(7504) });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 4,
                columns: new[] { "Password", "StartDate" },
                values: new object[] { "BatPassword", new DateTime(2023, 6, 21, 12, 51, 14, 217, DateTimeKind.Local).AddTicks(7508) });
        }
    }
}
