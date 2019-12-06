namespace PetStore.Data.Migrations
{
    using Microsoft.EntityFrameworkCore.Migrations;
    public partial class AddDistributorPrice : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<decimal>(
                name: "PriceFromDistributor",
                table: "Foods",
                nullable: false,
                defaultValue: 0m);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "PriceFromDistributor",
                table: "Foods");
        }
    }
}
