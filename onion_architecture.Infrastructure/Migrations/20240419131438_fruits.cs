using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace onion_architecture.Infrastructure.Migrations
{
    public partial class fruits : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Fruits",
                columns: table => new
                {
                    FruitId = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    FruitName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    FruitDescription = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    FruitQuantity = table.Column<int>(type: "int", nullable: false),
                    FruitPrice = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CategoriesId = table.Column<long>(type: "bigint", nullable: false),
                    Discount = table.Column<long>(type: "bigint", nullable: true),
                    PriceDiscount = table.Column<long>(type: "bigint", nullable: true),
                    FruitImg = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    createdBy = table.Column<long>(type: "bigint", nullable: false),
                    createdAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    updatedBy = table.Column<long>(type: "bigint", nullable: false),
                    updatedAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    deletedBy = table.Column<long>(type: "bigint", nullable: false),
                    deletedAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    IsDelete = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Fruits", x => x.FruitId);
                    table.ForeignKey(
                        name: "FK_Fruits_Categories_CategoriesId",
                        column: x => x.CategoriesId,
                        principalTable: "Categories",
                        principalColumn: "CategoriesId");
                });

            migrationBuilder.CreateIndex(
                name: "IX_Fruits_CategoriesId",
                table: "Fruits",
                column: "CategoriesId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Fruits");
        }
    }
}
