using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace BloodBankProject.DAL.Migrations
{
    /// <inheritdoc />
    public partial class BloodStockIdAllownull : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Requests_BloodStocks_BloodStockId",
                table: "Requests");

            migrationBuilder.AlterColumn<int>(
                name: "BloodStockId",
                table: "Requests",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AddForeignKey(
                name: "FK_Requests_BloodStocks_BloodStockId",
                table: "Requests",
                column: "BloodStockId",
                principalTable: "BloodStocks",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Requests_BloodStocks_BloodStockId",
                table: "Requests");

            migrationBuilder.AlterColumn<int>(
                name: "BloodStockId",
                table: "Requests",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Requests_BloodStocks_BloodStockId",
                table: "Requests",
                column: "BloodStockId",
                principalTable: "BloodStocks",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
