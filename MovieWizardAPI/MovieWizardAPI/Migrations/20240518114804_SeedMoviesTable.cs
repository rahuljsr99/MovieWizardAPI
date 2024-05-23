using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MovieWizardAPI.Migrations
{
    public partial class SeedMoviesTable : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "MovieNew",
                columns: new[] { "MovieId", "IMBDRating", "MovieName", "MovieReleaseDate" },
                values: new object[] { 1, 3f, "Shrek", new DateTime(2024, 5, 18, 17, 18, 3, 999, DateTimeKind.Local).AddTicks(3066) });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "MovieNew",
                keyColumn: "MovieId",
                keyValue: 1);
        }
    }
}
