using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MyStock.Migrations
{
    /// <inheritdoc />
    public partial class v3 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Entries_Products_EntryProductId",
                table: "Entries");

            migrationBuilder.RenameColumn(
                name: "EntryProductId",
                table: "Entries",
                newName: "ProductId");

            migrationBuilder.RenameIndex(
                name: "IX_Entries_EntryProductId",
                table: "Entries",
                newName: "IX_Entries_ProductId");

            migrationBuilder.AddForeignKey(
                name: "FK_Entries_Products_ProductId",
                table: "Entries",
                column: "ProductId",
                principalTable: "Products",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Entries_Products_ProductId",
                table: "Entries");

            migrationBuilder.RenameColumn(
                name: "ProductId",
                table: "Entries",
                newName: "EntryProductId");

            migrationBuilder.RenameIndex(
                name: "IX_Entries_ProductId",
                table: "Entries",
                newName: "IX_Entries_EntryProductId");

            migrationBuilder.AddForeignKey(
                name: "FK_Entries_Products_EntryProductId",
                table: "Entries",
                column: "EntryProductId",
                principalTable: "Products",
                principalColumn: "Id");
        }
    }
}
