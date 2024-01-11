using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Services.Migrations
{
    /// <inheritdoc />
    public partial class init : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Articles",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Theme = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    Auteur = table.Column<string>(type: "nvarchar(30)", maxLength: 30, nullable: false),
                    DateCreation = table.Column<DateOnly>(type: "date", nullable: false),
                    DateModification = table.Column<DateOnly>(type: "date", nullable: false),
                    Contenu = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Articles", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Commentaires",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Auteur = table.Column<string>(type: "nvarchar(30)", maxLength: 30, nullable: false),
                    DateCreation = table.Column<DateOnly>(type: "date", nullable: false),
                    DateModification = table.Column<DateOnly>(type: "date", nullable: false),
                    Contenu = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    ArticleId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Commentaires", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Commentaires_Articles_ArticleId",
                        column: x => x.ArticleId,
                        principalTable: "Articles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Articles",
                columns: new[] { "Id", "Auteur", "Contenu", "DateCreation", "DateModification", "Theme" },
                values: new object[] { 1, "Yoann", "Message 1", new DateOnly(2024, 1, 4), new DateOnly(2024, 1, 4), "Roadster" });

            migrationBuilder.InsertData(
                table: "Commentaires",
                columns: new[] { "Id", "ArticleId", "Auteur", "Contenu", "DateCreation", "DateModification" },
                values: new object[] { 1, 1, "Yoann", "Les roadsters c'est bien mais ça prend le vent !", new DateOnly(2024, 1, 4), new DateOnly(2024, 1, 4) });

            migrationBuilder.CreateIndex(
                name: "IX_Commentaires_ArticleId",
                table: "Commentaires",
                column: "ArticleId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Commentaires");

            migrationBuilder.DropTable(
                name: "Articles");
        }
    }
}
