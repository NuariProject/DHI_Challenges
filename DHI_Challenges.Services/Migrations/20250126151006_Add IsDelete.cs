using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DHI_Challenges.Services.Migrations
{
    /// <inheritdoc />
    public partial class AddIsDelete : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<bool>(
                name: "IsDelete",
                schema: "User",
                table: "MasterUsers",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "IsDelete",
                schema: "Product",
                table: "MasterProducts",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "IsDelete",
                schema: "Transaction",
                table: "Headers",
                type: "bit",
                nullable: false,
                defaultValue: false);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "IsDelete",
                schema: "User",
                table: "MasterUsers");

            migrationBuilder.DropColumn(
                name: "IsDelete",
                schema: "Product",
                table: "MasterProducts");

            migrationBuilder.DropColumn(
                name: "IsDelete",
                schema: "Transaction",
                table: "Headers");
        }
    }
}
