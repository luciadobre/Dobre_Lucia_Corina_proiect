using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Dobre_Lucia_Corina_proiect.Migrations
{
    /// <inheritdoc />
    public partial class DistributorProduct : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "DistributorProduct",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    DistributorID = table.Column<int>(type: "int", nullable: false),
                    Type = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Quantity = table.Column<int>(type: "int", nullable: false),
                    BuyPrice = table.Column<decimal>(type: "decimal(18,2)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DistributorProduct", x => x.ID);
                    table.ForeignKey(
                        name: "FK_DistributorProduct_Distributor_DistributorID",
                        column: x => x.DistributorID,
                        principalTable: "Distributor",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_DistributorProduct_DistributorID",
                table: "DistributorProduct",
                column: "DistributorID");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "DistributorProduct");
        }
    }
}
