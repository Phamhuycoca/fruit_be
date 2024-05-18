using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace onion_architecture.Infrastructure.Migrations
{
    public partial class bill_details : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<long>(
                name: "StoreId",
                table: "Bill_Details",
                type: "bigint",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Bill_Details_StoreId",
                table: "Bill_Details",
                column: "StoreId");

            migrationBuilder.AddForeignKey(
                name: "FK_Bill_Details_Stores_StoreId",
                table: "Bill_Details",
                column: "StoreId",
                principalTable: "Stores",
                principalColumn: "StoreId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Bill_Details_Stores_StoreId",
                table: "Bill_Details");

            migrationBuilder.DropIndex(
                name: "IX_Bill_Details_StoreId",
                table: "Bill_Details");

            migrationBuilder.DropColumn(
                name: "StoreId",
                table: "Bill_Details");
        }
    }
}
