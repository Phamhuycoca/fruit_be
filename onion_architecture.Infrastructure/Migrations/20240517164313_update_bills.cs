using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace onion_architecture.Infrastructure.Migrations
{
    public partial class update_bills : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<long>(
                name: "StoreId",
                table: "Bills",
                type: "bigint",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Bills_StoreId",
                table: "Bills",
                column: "StoreId");

            migrationBuilder.AddForeignKey(
                name: "FK_Bills_Stores_StoreId",
                table: "Bills",
                column: "StoreId",
                principalTable: "Stores",
                principalColumn: "StoreId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Bills_Stores_StoreId",
                table: "Bills");

            migrationBuilder.DropIndex(
                name: "IX_Bills_StoreId",
                table: "Bills");

            migrationBuilder.DropColumn(
                name: "StoreId",
                table: "Bills");
        }
    }
}
