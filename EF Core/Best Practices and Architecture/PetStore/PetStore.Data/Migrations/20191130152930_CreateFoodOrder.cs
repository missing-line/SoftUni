using Microsoft.EntityFrameworkCore.Migrations;

namespace PetStore.Data.Migrations
{
    public partial class CreateFoodOrder : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_FoodOrder_Foods_FoodId",
                table: "FoodOrder");

            migrationBuilder.DropForeignKey(
                name: "FK_FoodOrder_Orders_OrderId",
                table: "FoodOrder");

            migrationBuilder.DropPrimaryKey(
                name: "PK_FoodOrder",
                table: "FoodOrder");

            migrationBuilder.RenameTable(
                name: "FoodOrder",
                newName: "FoodOrders");

            migrationBuilder.RenameIndex(
                name: "IX_FoodOrder_FoodId",
                table: "FoodOrders",
                newName: "IX_FoodOrders_FoodId");

            migrationBuilder.AddColumn<decimal>(
                name: "PriceFromDistributor",
                table: "Toys",
                nullable: false,
                defaultValue: 0m);

            migrationBuilder.AddPrimaryKey(
                name: "PK_FoodOrders",
                table: "FoodOrders",
                columns: new[] { "OrderId", "FoodId" });

            migrationBuilder.AddForeignKey(
                name: "FK_FoodOrders_Foods_FoodId",
                table: "FoodOrders",
                column: "FoodId",
                principalTable: "Foods",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_FoodOrders_Orders_OrderId",
                table: "FoodOrders",
                column: "OrderId",
                principalTable: "Orders",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_FoodOrders_Foods_FoodId",
                table: "FoodOrders");

            migrationBuilder.DropForeignKey(
                name: "FK_FoodOrders_Orders_OrderId",
                table: "FoodOrders");

            migrationBuilder.DropPrimaryKey(
                name: "PK_FoodOrders",
                table: "FoodOrders");

            migrationBuilder.DropColumn(
                name: "PriceFromDistributor",
                table: "Toys");

            migrationBuilder.RenameTable(
                name: "FoodOrders",
                newName: "FoodOrder");

            migrationBuilder.RenameIndex(
                name: "IX_FoodOrders_FoodId",
                table: "FoodOrder",
                newName: "IX_FoodOrder_FoodId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_FoodOrder",
                table: "FoodOrder",
                columns: new[] { "OrderId", "FoodId" });

            migrationBuilder.AddForeignKey(
                name: "FK_FoodOrder_Foods_FoodId",
                table: "FoodOrder",
                column: "FoodId",
                principalTable: "Foods",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_FoodOrder_Orders_OrderId",
                table: "FoodOrder",
                column: "OrderId",
                principalTable: "Orders",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
