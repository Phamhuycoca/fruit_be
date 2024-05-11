using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace onion_architecture.Infrastructure.Migrations
{
    public partial class updatefruit : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<long>(
                name: "StoreId",
                table: "Fruits",
                type: "bigint",
                nullable: false,
                defaultValue: 0L);

            migrationBuilder.CreateIndex(
                name: "IX_Fruits_StoreId",
                table: "Fruits",
                column: "StoreId");

            migrationBuilder.AddForeignKey(
                name: "FK_Fruits_Stores_StoreId",
                table: "Fruits",
                column: "StoreId",
                principalTable: "Stores",
                principalColumn: "StoreId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Fruits_Stores_StoreId",
                table: "Fruits");

            migrationBuilder.DropIndex(
                name: "IX_Fruits_StoreId",
                table: "Fruits");

            migrationBuilder.DropColumn(
                name: "StoreId",
                table: "Fruits");
        }
    }
}
