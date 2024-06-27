using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MovieWizardAPI.Migrations.DirectorDb
{
    public partial class AddedDirectorProfilePictureField : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<byte[]>(
                name: "ProfilePicture",
                table: "Directors",
                type: "VARBINARY(MAX)",
                nullable: false,
                defaultValue: new byte[0]);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ProfilePicture",
                table: "Directors");
        }
    }
}
