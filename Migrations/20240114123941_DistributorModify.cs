using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Dobre_Lucia_Corina_proiect.Migrations
{
    /// <inheritdoc />
    public partial class DistributorModify : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_DistributorProduct_Distributor_DistributorID",
                table: "DistributorProduct");

            migrationBuilder.DropForeignKey(
                name: "FK_Product_DistributorProduct_DistributorProductID",
                table: "Product");

            migrationBuilder.DropIndex(
                name: "IX_DistributorProduct_DistributorID",
                table: "DistributorProduct");

            migrationBuilder.RenameColumn(
                name: "Name",
                table: "DistributorProduct",
                newName: "DistributorProductName");

            migrationBuilder.AlterColumn<int>(
                name: "DistributorProductID",
                table: "Product",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.CreateTable(
                name: "DistributorDistributorProduct",
                columns: table => new
                {
                    DistributorID = table.Column<int>(type: "int", nullable: false),
                    DistributorProductID = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DistributorDistributorProduct", x => new { x.DistributorID, x.DistributorProductID });
                    table.ForeignKey(
                        name: "FK_DistributorDistributorProduct_DistributorProduct_DistributorProductID",
                        column: x => x.DistributorProductID,
                        principalTable: "DistributorProduct",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_DistributorDistributorProduct_Distributor_DistributorID",
                        column: x => x.DistributorID,
                        principalTable: "Distributor",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_DistributorDistributorProduct_DistributorProductID",
                table: "DistributorDistributorProduct",
                column: "DistributorProductID");

            migrationBuilder.AddForeignKey(
                name: "FK_Product_DistributorProduct_DistributorProductID",
                table: "Product",
                column: "DistributorProductID",
                principalTable: "DistributorProduct",
                principalColumn: "ID");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Product_DistributorProduct_DistributorProductID",
                table: "Product");

            migrationBuilder.DropTable(
                name: "DistributorDistributorProduct");

            migrationBuilder.RenameColumn(
                name: "DistributorProductName",
                table: "DistributorProduct",
                newName: "Name");

            migrationBuilder.AlterColumn<int>(
                name: "DistributorProductID",
                table: "Product",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_DistributorProduct_DistributorID",
                table: "DistributorProduct",
                column: "DistributorID");

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
    }
}
