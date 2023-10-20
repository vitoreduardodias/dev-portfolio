using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MyStock.Migrations
{
    /// <inheritdoc />
    public partial class v5 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Outputs_Products_OutputProductId",
                table: "Outputs");

            migrationBuilder.DropIndex(
                name: "IX_Outputs_OutputProductId",
                table: "Outputs");

            migrationBuilder.DropColumn(
                name: "OutputProductId",
                table: "Outputs");

            migrationBuilder.RenameColumn(
                name: "ProductOutputId",
                table: "Outputs",
                newName: "ProductOutId");

            migrationBuilder.CreateIndex(
                name: "IX_Outputs_ProductOutId",
                table: "Outputs",
                column: "ProductOutId");

            migrationBuilder.AddForeignKey(
                name: "FK_Outputs_Products_ProductOutId",
                table: "Outputs",
                column: "ProductOutId",
                principalTable: "Products",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Outputs_Products_ProductOutId",
                table: "Outputs");

            migrationBuilder.DropIndex(
                name: "IX_Outputs_ProductOutId",
                table: "Outputs");

            migrationBuilder.RenameColumn(
                name: "ProductOutId",
                table: "Outputs",
                newName: "ProductOutputId");

            migrationBuilder.AddColumn<int>(
                name: "OutputProductId",
                table: "Outputs",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Outputs_OutputProductId",
                table: "Outputs",
                column: "OutputProductId");

            migrationBuilder.AddForeignKey(
                name: "FK_Outputs_Products_OutputProductId",
                table: "Outputs",
                column: "OutputProductId",
                principalTable: "Products",
                principalColumn: "Id");
        }
    }
}
