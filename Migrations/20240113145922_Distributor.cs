using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Dobre_Lucia_Corina_proiect.Migrations
{
    /// <inheritdoc />
    public partial class Distributor : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Distributor",
                table: "Product",
                newName: "DistributorName");

            migrationBuilder.AddColumn<int>(
                name: "DistributorID",
                table: "Product",
                type: "int",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "Distributor",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    DistributorName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Address = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Distributor", x => x.ID);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Product_DistributorID",
                table: "Product",
                column: "DistributorID");

            migrationBuilder.AddForeignKey(
                name: "FK_Product_Distributor_DistributorID",
                table: "Product",
                column: "DistributorID",
                principalTable: "Distributor",
                principalColumn: "ID");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Product_Distributor_DistributorID",
                table: "Product");

            migrationBuilder.DropTable(
                name: "Distributor");

            migrationBuilder.DropIndex(
                name: "IX_Product_DistributorID",
                table: "Product");

            migrationBuilder.DropColumn(
                name: "DistributorID",
                table: "Product");

            migrationBuilder.RenameColumn(
                name: "DistributorName",
                table: "Product",
                newName: "Distributor");
        }
    }
}
