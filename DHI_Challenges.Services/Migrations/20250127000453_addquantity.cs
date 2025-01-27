using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DHI_Challenges.Services.Migrations
{
    /// <inheritdoc />
    public partial class addquantity : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "SummaryQuantity",
                schema: "Transaction",
                table: "Headers",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "Quantity",
                schema: "Transaction",
                table: "Details",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "SummaryQuantity",
                schema: "Transaction",
                table: "Headers");

            migrationBuilder.DropColumn(
                name: "Quantity",
                schema: "Transaction",
                table: "Details");
        }
    }
}
