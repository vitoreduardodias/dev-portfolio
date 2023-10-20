using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MyStock.Migrations
{
    /// <inheritdoc />
    public partial class v4 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Entries_Products_ProductId",
                table: "Entries");

            migrationBuilder.DropColumn(
                name: "ProductEntryId",
                table: "Entries");

            migrationBuilder.AlterColumn<int>(
                name: "ProductId",
                table: "Entries",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Entries_Products_ProductId",
                table: "Entries",
                column: "ProductId",
                principalTable: "Products",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Entries_Products_ProductId",
                table: "Entries");

            migrationBuilder.AlterColumn<int>(
                name: "ProductId",
                table: "Entries",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AddColumn<int>(
                name: "ProductEntryId",
                table: "Entries",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddForeignKey(
                name: "FK_Entries_Products_ProductId",
                table: "Entries",
                column: "ProductId",
                principalTable: "Products",
                principalColumn: "Id");
        }
    }
}
