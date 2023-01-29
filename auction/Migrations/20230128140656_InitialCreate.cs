using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace auction.Migrations
{
    /// <inheritdoc />
    public partial class InitialCreate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Buyer",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    firstnamebuyer = table.Column<string>(name: "first_name_buyer", type: "nvarchar(max)", nullable: false),
                    lastnamebuyer = table.Column<string>(name: "last_name_buyer", type: "nvarchar(max)", nullable: false),
                    phonenumberbuyer = table.Column<string>(name: "phone_number_buyer", type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Buyer", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Lot",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    nameorder = table.Column<string>(name: "name_order", type: "nvarchar(max)", nullable: false),
                    startingprice = table.Column<float>(name: "starting_price", type: "real", nullable: false),
                    buyeridbuyer = table.Column<int>(name: "buyer_id_buyer", type: "int", nullable: false),
                    selleridseller = table.Column<int>(name: "seller_id_seller", type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Lot", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Seller",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    firstnameseller = table.Column<string>(name: "first_name_seller", type: "nvarchar(max)", nullable: false),
                    lastnameseller = table.Column<string>(name: "last_name_seller", type: "nvarchar(max)", nullable: false),
                    phonenumberseller = table.Column<string>(name: "phone_number_seller", type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Seller", x => x.Id);
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Buyer");

            migrationBuilder.DropTable(
                name: "Lot");

            migrationBuilder.DropTable(
                name: "Seller");
        }
    }
}
