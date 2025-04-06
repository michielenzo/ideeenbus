using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ideeenbus.Migrations
{
    /// <inheritdoc />
    public partial class InitialMigration : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Categories",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Naam = table.Column<string>(type: "TEXT", maxLength: 512, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Categories", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Ideeen",
                columns: table => new
                {
                    Id = table.Column<string>(type: "TEXT", nullable: false),
                    Onderwerp = table.Column<string>(type: "TEXT", maxLength: 512, nullable: false),
                    Beschrijving = table.Column<string>(type: "TEXT", nullable: false),
                    UserId = table.Column<int>(type: "INTEGER", nullable: true),
                    Username = table.Column<string>(type: "TEXT", maxLength: 512, nullable: true),
                    Type = table.Column<string>(type: "TEXT", nullable: false),
                    BeginDatum = table.Column<DateTime>(type: "TEXT", nullable: true),
                    EindDatum = table.Column<DateTime>(type: "TEXT", nullable: true),
                    CreatedAt = table.Column<DateTime>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Ideeen", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "CategorieEntityIdeeEntity",
                columns: table => new
                {
                    CategoryEntitiesId = table.Column<int>(type: "INTEGER", nullable: false),
                    IdeeEntitiesId = table.Column<string>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CategorieEntityIdeeEntity", x => new { x.CategoryEntitiesId, x.IdeeEntitiesId });
                    table.ForeignKey(
                        name: "FK_CategorieEntityIdeeEntity_Categories_CategoryEntitiesId",
                        column: x => x.CategoryEntitiesId,
                        principalTable: "Categories",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_CategorieEntityIdeeEntity_Ideeen_IdeeEntitiesId",
                        column: x => x.IdeeEntitiesId,
                        principalTable: "Ideeen",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "CategorieInIdeeEntities",
                columns: table => new
                {
                    CategoryEntityId = table.Column<int>(type: "INTEGER", nullable: false),
                    IdeeEntityId = table.Column<int>(type: "INTEGER", nullable: false),
                    CategorieEntityId = table.Column<int>(type: "INTEGER", nullable: false),
                    IdeeEntityId1 = table.Column<string>(type: "TEXT", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CategorieInIdeeEntities", x => new { x.CategoryEntityId, x.IdeeEntityId });
                    table.ForeignKey(
                        name: "FK_CategorieInIdeeEntities_Categories_CategorieEntityId",
                        column: x => x.CategorieEntityId,
                        principalTable: "Categories",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_CategorieInIdeeEntities_Ideeen_IdeeEntityId1",
                        column: x => x.IdeeEntityId1,
                        principalTable: "Ideeen",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateIndex(
                name: "IX_CategorieEntityIdeeEntity_IdeeEntitiesId",
                table: "CategorieEntityIdeeEntity",
                column: "IdeeEntitiesId");

            migrationBuilder.CreateIndex(
                name: "IX_CategorieInIdeeEntities_CategorieEntityId",
                table: "CategorieInIdeeEntities",
                column: "CategorieEntityId");

            migrationBuilder.CreateIndex(
                name: "IX_CategorieInIdeeEntities_IdeeEntityId1",
                table: "CategorieInIdeeEntities",
                column: "IdeeEntityId1");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "CategorieEntityIdeeEntity");

            migrationBuilder.DropTable(
                name: "CategorieInIdeeEntities");

            migrationBuilder.DropTable(
                name: "Categories");

            migrationBuilder.DropTable(
                name: "Ideeen");
        }
    }
}
