using System;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace mvcgog.Migrations
{
    /// <inheritdoc />
    public partial class InitialCreate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterDatabase()
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "LigneBackup",
                columns: table => new
                {
                    LigneBackupID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    LignePanierID = table.Column<int>(type: "int", nullable: false),
                    PanierID = table.Column<int>(type: "int", nullable: false),
                    ProduitID = table.Column<int>(type: "int", nullable: false),
                    NbreArticle = table.Column<int>(type: "int", nullable: false),
                    Total = table.Column<double>(type: "double", nullable: false),
                    Prodname = table.Column<string>(type: "longtext", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_LigneBackup", x => x.LigneBackupID);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "Produit",
                columns: table => new
                {
                    ProduitID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    PanierID = table.Column<int>(type: "int", nullable: false),
                    imageurl = table.Column<string>(type: "longtext", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Prodname = table.Column<string>(type: "longtext", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Price = table.Column<float>(type: "float", nullable: false),
                    Dateofcreation = table.Column<DateTime>(type: "datetime(6)", nullable: false),
                    desc = table.Column<string>(type: "longtext", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Autor = table.Column<string>(type: "longtext", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Produit", x => x.ProduitID);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "User",
                columns: table => new
                {
                    UserID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    Email = table.Column<string>(type: "varchar(255)", maxLength: 255, nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Password = table.Column<string>(type: "varchar(255)", maxLength: 255, nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    FirstName = table.Column<string>(type: "varchar(255)", maxLength: 255, nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    LastName = table.Column<string>(type: "varchar(255)", maxLength: 255, nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    IsAdmin = table.Column<bool>(type: "tinyint(1)", nullable: false),
                    BirthDate = table.Column<DateTime>(type: "datetime(6)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_User", x => x.UserID);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "Panier",
                columns: table => new
                {
                    PanierID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    NbreArticle = table.Column<int>(type: "int", nullable: false),
                    Total = table.Column<double>(type: "double", nullable: false),
                    UserID = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Panier", x => x.PanierID);
                    table.ForeignKey(
                        name: "FK_Panier_User_UserID",
                        column: x => x.UserID,
                        principalTable: "User",
                        principalColumn: "UserID");
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "LignePanier",
                columns: table => new
                {
                    LignePanierID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    PanierID = table.Column<int>(type: "int", nullable: false),
                    ProduitID = table.Column<int>(type: "int", nullable: false),
                    NbreArticle = table.Column<int>(type: "int", nullable: false),
                    Total = table.Column<double>(type: "double", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_LignePanier", x => x.LignePanierID);
                    table.ForeignKey(
                        name: "FK_LignePanier_Panier_PanierID",
                        column: x => x.PanierID,
                        principalTable: "Panier",
                        principalColumn: "PanierID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_LignePanier_Produit_ProduitID",
                        column: x => x.ProduitID,
                        principalTable: "Produit",
                        principalColumn: "ProduitID",
                        onDelete: ReferentialAction.Cascade);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateIndex(
                name: "IX_LignePanier_PanierID",
                table: "LignePanier",
                column: "PanierID");

            migrationBuilder.CreateIndex(
                name: "IX_LignePanier_ProduitID",
                table: "LignePanier",
                column: "ProduitID");

            migrationBuilder.CreateIndex(
                name: "IX_Panier_UserID",
                table: "Panier",
                column: "UserID");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "LigneBackup");

            migrationBuilder.DropTable(
                name: "LignePanier");

            migrationBuilder.DropTable(
                name: "Panier");

            migrationBuilder.DropTable(
                name: "Produit");

            migrationBuilder.DropTable(
                name: "User");
        }
    }
}
