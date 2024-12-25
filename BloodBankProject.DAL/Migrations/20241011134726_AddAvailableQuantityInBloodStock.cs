using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace BloodBankProject.DAL.Migrations
{
    /// <inheritdoc />
    public partial class AddAvailableQuantityInBloodStock : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "AvailableQuantity",
                table: "BloodStocks",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "AvailableQuantity",
                table: "BloodStocks");
        }
    }
}
