using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace GoodEatDatabase.Migrations
{
    public partial class InitialMigration1 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "Id", "Email", "FirstName", "LastName", "Password", "StartDate", "UserRightID", "Username" },
                values: new object[] { 1, "antoine.pinloche@admin.com", "john", "Doe", "password", new DateTime(2023, 1, 11, 17, 0, 43, 53, DateTimeKind.Local).AddTicks(5940), 1, "admin" });

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "Id", "Email", "FirstName", "LastName", "Password", "StartDate", "UserRightID", "Username" },
                values: new object[] { 2, "antoine.pinloche@user.com", "john", "Doe", "password", new DateTime(2023, 1, 11, 17, 0, 43, 53, DateTimeKind.Local).AddTicks(5999), 2, "user" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 2);
        }
    }
}
