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
                    Naam = table.Column<string>(type: "TEXT", nullable: false)
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
                    onderwerp = table.Column<string>(type: "TEXT", nullable: false),
                    beschrijving = table.Column<string>(type: "TEXT", nullable: false),
                    userId = table.Column<int>(type: "INTEGER", nullable: true),
                    username = table.Column<string>(type: "TEXT", nullable: true),
                    type = table.Column<string>(type: "TEXT", nullable: false),
                    beginDatum = table.Column<string>(type: "TEXT", nullable: true),
                    eindDatum = table.Column<string>(type: "TEXT", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Ideeen", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "CategorieEntityIdeeEntity",
                columns: table => new
                {
                    categoryEntitiesId = table.Column<int>(type: "INTEGER", nullable: false),
                    ideeEntitiesId = table.Column<string>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CategorieEntityIdeeEntity", x => new { x.categoryEntitiesId, x.ideeEntitiesId });
                    table.ForeignKey(
                        name: "FK_CategorieEntityIdeeEntity_Categories_categoryEntitiesId",
                        column: x => x.categoryEntitiesId,
                        principalTable: "Categories",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_CategorieEntityIdeeEntity_Ideeen_ideeEntitiesId",
                        column: x => x.ideeEntitiesId,
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
                name: "IX_CategorieEntityIdeeEntity_ideeEntitiesId",
                table: "CategorieEntityIdeeEntity",
                column: "ideeEntitiesId");

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
