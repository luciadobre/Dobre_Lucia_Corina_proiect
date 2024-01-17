using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Dobre_Lucia_Corina_proiect.Migrations
{
    /// <inheritdoc />
    public partial class SaleUpdate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Purchase_Buyer_BuyerID",
                table: "Purchase");

            migrationBuilder.DropForeignKey(
                name: "FK_Purchase_Product_ProductID",
                table: "Purchase");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Purchase",
                table: "Purchase");

            migrationBuilder.RenameTable(
                name: "Purchase",
                newName: "Sale");

            migrationBuilder.RenameIndex(
                name: "IX_Purchase_ProductID",
                table: "Sale",
                newName: "IX_Sale_ProductID");

            migrationBuilder.RenameIndex(
                name: "IX_Purchase_BuyerID",
                table: "Sale",
                newName: "IX_Sale_BuyerID");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Sale",
                table: "Sale",
                column: "ID");

            migrationBuilder.AddForeignKey(
                name: "FK_Sale_Buyer_BuyerID",
                table: "Sale",
                column: "BuyerID",
                principalTable: "Buyer",
                principalColumn: "ID");

            migrationBuilder.AddForeignKey(
                name: "FK_Sale_Product_ProductID",
                table: "Sale",
                column: "ProductID",
                principalTable: "Product",
                principalColumn: "ID");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Sale_Buyer_BuyerID",
                table: "Sale");

            migrationBuilder.DropForeignKey(
                name: "FK_Sale_Product_ProductID",
                table: "Sale");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Sale",
                table: "Sale");

            migrationBuilder.RenameTable(
                name: "Sale",
                newName: "Purchase");

            migrationBuilder.RenameIndex(
                name: "IX_Sale_ProductID",
                table: "Purchase",
                newName: "IX_Purchase_ProductID");

            migrationBuilder.RenameIndex(
                name: "IX_Sale_BuyerID",
                table: "Purchase",
                newName: "IX_Purchase_BuyerID");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Purchase",
                table: "Purchase",
                column: "ID");

            migrationBuilder.AddForeignKey(
                name: "FK_Purchase_Buyer_BuyerID",
                table: "Purchase",
                column: "BuyerID",
                principalTable: "Buyer",
                principalColumn: "ID");

            migrationBuilder.AddForeignKey(
                name: "FK_Purchase_Product_ProductID",
                table: "Purchase",
                column: "ProductID",
                principalTable: "Product",
                principalColumn: "ID");
        }
    }
}
