using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Dobre_Lucia_Corina_proiect.Migrations
{
    /// <inheritdoc />
    public partial class BuyersSalesModify : Migration
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

            migrationBuilder.AlterColumn<int>(
                name: "ProductID",
                table: "Purchase",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AlterColumn<int>(
                name: "BuyerID",
                table: "Purchase",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

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

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Purchase_Buyer_BuyerID",
                table: "Purchase");

            migrationBuilder.DropForeignKey(
                name: "FK_Purchase_Product_ProductID",
                table: "Purchase");

            migrationBuilder.AlterColumn<int>(
                name: "ProductID",
                table: "Purchase",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "BuyerID",
                table: "Purchase",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Purchase_Buyer_BuyerID",
                table: "Purchase",
                column: "BuyerID",
                principalTable: "Buyer",
                principalColumn: "ID",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Purchase_Product_ProductID",
                table: "Purchase",
                column: "ProductID",
                principalTable: "Product",
                principalColumn: "ID",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
