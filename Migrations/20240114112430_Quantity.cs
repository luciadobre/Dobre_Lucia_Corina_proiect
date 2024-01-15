using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Dobre_Lucia_Corina_proiect.Migrations
{
    /// <inheritdoc />
    public partial class Quantity : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_DistributorProduct_Distributor_DistributorID",
                table: "DistributorProduct");

            migrationBuilder.AddColumn<int>(
                name: "DistributorProductID",
                table: "Product",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "Quantity",
                table: "Product",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AlterColumn<int>(
                name: "DistributorID",
                table: "DistributorProduct",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.CreateIndex(
                name: "IX_Product_DistributorProductID",
                table: "Product",
                column: "DistributorProductID");

            migrationBuilder.AddForeignKey(
                name: "FK_DistributorProduct_Distributor_DistributorID",
                table: "DistributorProduct",
                column: "DistributorID",
                principalTable: "Distributor",
                principalColumn: "ID");

            migrationBuilder.AddForeignKey(
                name: "FK_Product_DistributorProduct_DistributorProductID",
                table: "Product",
                column: "DistributorProductID",
                principalTable: "DistributorProduct",
                principalColumn: "ID",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_DistributorProduct_Distributor_DistributorID",
                table: "DistributorProduct");

            migrationBuilder.DropForeignKey(
                name: "FK_Product_DistributorProduct_DistributorProductID",
                table: "Product");

            migrationBuilder.DropIndex(
                name: "IX_Product_DistributorProductID",
                table: "Product");

            migrationBuilder.DropColumn(
                name: "DistributorProductID",
                table: "Product");

            migrationBuilder.DropColumn(
                name: "Quantity",
                table: "Product");

            migrationBuilder.AlterColumn<int>(
                name: "DistributorID",
                table: "DistributorProduct",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_DistributorProduct_Distributor_DistributorID",
                table: "DistributorProduct",
                column: "DistributorID",
                principalTable: "Distributor",
                principalColumn: "ID",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
