using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MovieWizardAPI.Migrations.ActorDb
{
    public partial class UpdatedActors : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Director",
                columns: table => new
                {
                    DirectorId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    DirectorName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    DirectorAge = table.Column<int>(type: "int", nullable: false),
                    DirectorLocation = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    DirectorDescription = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    IsActive = table.Column<bool>(type: "bit", nullable: false),
                    CreatedTime = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CreatedBy = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    UpdatedTime = table.Column<DateTime>(type: "datetime2", nullable: true),
                    UpdatedBy = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ProfilePicture = table.Column<byte[]>(type: "VARBINARY(MAX)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Director", x => x.DirectorId);
                });

            migrationBuilder.CreateTable(
                name: "MovieBudget",
                columns: table => new
                {
                    MovieBudgetId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    BudgetAmount = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    BudgetDate = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MovieBudget", x => x.MovieBudgetId);
                });

            migrationBuilder.CreateTable(
                name: "MoviePrice",
                columns: table => new
                {
                    MoviePriceId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    PriceAmount = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    PriceDate = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MoviePrice", x => x.MoviePriceId);
                });

            migrationBuilder.CreateTable(
                name: "MovieRevenue",
                columns: table => new
                {
                    MovieRevenueId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    RevenueAmount = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    RevenueDate = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MovieRevenue", x => x.MovieRevenueId);
                });

            migrationBuilder.CreateTable(
                name: "MovieModel",
                columns: table => new
                {
                    MovieId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    MovieName = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    MovieReleaseDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    DirectorId = table.Column<int>(type: "int", nullable: false),
                    MovieBudgetId = table.Column<int>(type: "int", nullable: false),
                    MoviePriceId = table.Column<int>(type: "int", nullable: false),
                    MovieRevenueId = table.Column<int>(type: "int", nullable: true),
                    CreatedBy = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdatedBy = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    UpdatedDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    IsActive = table.Column<bool>(type: "bit", nullable: false),
                    MoviePoster = table.Column<byte[]>(type: "VARBINARY(MAX)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MovieModel", x => x.MovieId);
                    table.ForeignKey(
                        name: "FK_MovieModel_Director_DirectorId",
                        column: x => x.DirectorId,
                        principalTable: "Director",
                        principalColumn: "DirectorId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_MovieModel_MovieBudget_MovieBudgetId",
                        column: x => x.MovieBudgetId,
                        principalTable: "MovieBudget",
                        principalColumn: "MovieBudgetId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_MovieModel_MoviePrice_MoviePriceId",
                        column: x => x.MoviePriceId,
                        principalTable: "MoviePrice",
                        principalColumn: "MoviePriceId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_MovieModel_MovieRevenue_MovieRevenueId",
                        column: x => x.MovieRevenueId,
                        principalTable: "MovieRevenue",
                        principalColumn: "MovieRevenueId");
                });

            migrationBuilder.CreateTable(
                name: "ActorMovieModel",
                columns: table => new
                {
                    ActorsActorId = table.Column<int>(type: "int", nullable: false),
                    MoviesMovieId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ActorMovieModel", x => new { x.ActorsActorId, x.MoviesMovieId });
                    table.ForeignKey(
                        name: "FK_ActorMovieModel_Actors_ActorsActorId",
                        column: x => x.ActorsActorId,
                        principalTable: "Actors",
                        principalColumn: "ActorId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ActorMovieModel_MovieModel_MoviesMovieId",
                        column: x => x.MoviesMovieId,
                        principalTable: "MovieModel",
                        principalColumn: "MovieId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_ActorMovieModel_MoviesMovieId",
                table: "ActorMovieModel",
                column: "MoviesMovieId");

            migrationBuilder.CreateIndex(
                name: "IX_MovieModel_DirectorId",
                table: "MovieModel",
                column: "DirectorId");

            migrationBuilder.CreateIndex(
                name: "IX_MovieModel_MovieBudgetId",
                table: "MovieModel",
                column: "MovieBudgetId");

            migrationBuilder.CreateIndex(
                name: "IX_MovieModel_MoviePriceId",
                table: "MovieModel",
                column: "MoviePriceId");

            migrationBuilder.CreateIndex(
                name: "IX_MovieModel_MovieRevenueId",
                table: "MovieModel",
                column: "MovieRevenueId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ActorMovieModel");

            migrationBuilder.DropTable(
                name: "MovieModel");

            migrationBuilder.DropTable(
                name: "Director");

            migrationBuilder.DropTable(
                name: "MovieBudget");

            migrationBuilder.DropTable(
                name: "MoviePrice");

            migrationBuilder.DropTable(
                name: "MovieRevenue");
        }
    }
}
