using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Infrastructure.Migrations
{
    public partial class SeedingTodos : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Todos",
                columns: new[] { "Id", "Category", "City", "Description", "EndDate", "StartDate", "Title", "Venue" },
                values: new object[] { new Guid("fa9025ee-3b16-4fb2-97c1-356c69bda994"), "Sports Activity", "Klosterneuburg", "Laufen 2km", new DateTime(2021, 2, 7, 20, 52, 0, 0, DateTimeKind.Unspecified), new DateTime(2021, 2, 7, 20, 30, 0, 0, DateTimeKind.Unspecified), null, "Laufen 2km" });

            migrationBuilder.InsertData(
                table: "Todos",
                columns: new[] { "Id", "Category", "City", "Description", "EndDate", "StartDate", "Title", "Venue" },
                values: new object[] { new Guid("e48e9092-0bb3-4eea-9481-df59d23e8b7a"), "Work", "Wien", "Arbeiten im Büro", new DateTime(2021, 2, 1, 17, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2021, 2, 1, 9, 30, 0, 0, DateTimeKind.Unspecified), null, "Working at the office" });

            migrationBuilder.InsertData(
                table: "Todos",
                columns: new[] { "Id", "Category", "City", "Description", "EndDate", "StartDate", "Title", "Venue" },
                values: new object[] { new Guid("5ea6673e-ff84-42d0-8bc8-cf343b3a1ffe"), "Sports Activity", "Klosterneuburg", "Training mit Klimmzugstange", new DateTime(2021, 2, 7, 20, 15, 0, 0, DateTimeKind.Unspecified), new DateTime(2021, 2, 7, 20, 0, 0, 0, DateTimeKind.Unspecified), null, "Training mit Klimmzugstange" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Todos",
                keyColumn: "Id",
                keyValue: new Guid("5ea6673e-ff84-42d0-8bc8-cf343b3a1ffe"));

            migrationBuilder.DeleteData(
                table: "Todos",
                keyColumn: "Id",
                keyValue: new Guid("e48e9092-0bb3-4eea-9481-df59d23e8b7a"));

            migrationBuilder.DeleteData(
                table: "Todos",
                keyColumn: "Id",
                keyValue: new Guid("fa9025ee-3b16-4fb2-97c1-356c69bda994"));
        }
    }
}
