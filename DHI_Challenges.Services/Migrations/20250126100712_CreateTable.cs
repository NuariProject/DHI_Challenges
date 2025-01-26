using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DHI_Challenges.Services.Migrations
{
    /// <inheritdoc />
    public partial class CreateTable : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.EnsureSchema(
                name: "Transaction");

            migrationBuilder.EnsureSchema(
                name: "Product");

            migrationBuilder.EnsureSchema(
                name: "User");

            migrationBuilder.CreateTable(
                name: "MasterProducts",
                schema: "Product",
                columns: table => new
                {
                    ProductID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ProductName = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    Price = table.Column<decimal>(type: "decimal(18,2)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MasterProducts", x => x.ProductID);
                });

            migrationBuilder.CreateTable(
                name: "MasterUsers",
                schema: "User",
                columns: table => new
                {
                    UserID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    FullName = table.Column<string>(type: "nvarchar(25)", maxLength: 25, nullable: false),
                    PhoneNumber = table.Column<string>(type: "nvarchar(15)", maxLength: 15, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MasterUsers", x => x.UserID);
                });

            migrationBuilder.CreateTable(
                name: "Headers",
                schema: "Transaction",
                columns: table => new
                {
                    HeaderID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserID = table.Column<int>(type: "int", nullable: false),
                    CreateDate = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Headers", x => x.HeaderID);
                    table.ForeignKey(
                        name: "FK_Headers_MasterUsers_UserID",
                        column: x => x.UserID,
                        principalSchema: "User",
                        principalTable: "MasterUsers",
                        principalColumn: "UserID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Details",
                schema: "Transaction",
                columns: table => new
                {
                    DetailID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    HeaderID = table.Column<int>(type: "int", nullable: false),
                    ProductID = table.Column<int>(type: "int", nullable: false),
                    Price = table.Column<decimal>(type: "decimal(18,2)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Details", x => x.DetailID);
                    table.ForeignKey(
                        name: "FK_Details_Headers_HeaderID",
                        column: x => x.HeaderID,
                        principalSchema: "Transaction",
                        principalTable: "Headers",
                        principalColumn: "HeaderID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Details_MasterProducts_ProductID",
                        column: x => x.ProductID,
                        principalSchema: "Product",
                        principalTable: "MasterProducts",
                        principalColumn: "ProductID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Details_HeaderID",
                schema: "Transaction",
                table: "Details",
                column: "HeaderID");

            migrationBuilder.CreateIndex(
                name: "IX_Details_ProductID",
                schema: "Transaction",
                table: "Details",
                column: "ProductID");

            migrationBuilder.CreateIndex(
                name: "IX_Headers_UserID",
                schema: "Transaction",
                table: "Headers",
                column: "UserID");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Details",
                schema: "Transaction");

            migrationBuilder.DropTable(
                name: "Headers",
                schema: "Transaction");

            migrationBuilder.DropTable(
                name: "MasterProducts",
                schema: "Product");

            migrationBuilder.DropTable(
                name: "MasterUsers",
                schema: "User");
        }
    }
}
