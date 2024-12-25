using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace BloodBankProject.DAL.Migrations
{
    /// <inheritdoc />
    public partial class RemoveAvailableQuantityFromBloodStockModel : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "AvailableQuantity",
                table: "BloodStocks");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "AvailableQuantity",
                table: "BloodStocks",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }
    }
}
