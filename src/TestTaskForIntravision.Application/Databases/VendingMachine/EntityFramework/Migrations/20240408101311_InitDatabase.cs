using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace TestTaskForIntravision.Application.Databases.VendingMachine.EntityFramework.Migrations
{
    /// <inheritdoc />
    public partial class InitDatabase : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "beverage_images",
                columns: table => new
                {
                    id = table.Column<Guid>(type: "uuid", nullable: false),
                    beverage_id = table.Column<Guid>(type: "uuid", nullable: false),
                    url = table.Column<string>(type: "text", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_beverage_images", x => x.id);
                    table.UniqueConstraint("ak_beverage_images_beverage_id", x => x.beverage_id);
                });

            migrationBuilder.CreateTable(
                name: "storage_beverages",
                columns: table => new
                {
                    id = table.Column<Guid>(type: "uuid", nullable: false),
                    beverage_id = table.Column<Guid>(type: "uuid", nullable: false),
                    count = table.Column<long>(type: "bigint", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_storage_beverages", x => x.id);
                    table.UniqueConstraint("ak_storage_beverages_beverage_id", x => x.beverage_id);
                });

            migrationBuilder.CreateTable(
                name: "storage_coins",
                columns: table => new
                {
                    id = table.Column<Guid>(type: "uuid", nullable: false),
                    coin_id = table.Column<Guid>(type: "uuid", nullable: false),
                    count = table.Column<long>(type: "bigint", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_storage_coins", x => x.id);
                    table.UniqueConstraint("ak_storage_coins_coin_id", x => x.coin_id);
                });

            migrationBuilder.CreateTable(
                name: "beverages",
                columns: table => new
                {
                    id = table.Column<Guid>(type: "uuid", nullable: false),
                    title = table.Column<string>(type: "text", nullable: false),
                    price = table.Column<decimal>(type: "numeric", nullable: false),
                    storage_beverage_id = table.Column<Guid>(type: "uuid", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_beverages", x => x.id);
                    table.ForeignKey(
                        name: "fk_beverages_beverage_images_id",
                        column: x => x.id,
                        principalTable: "beverage_images",
                        principalColumn: "beverage_id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "fk_beverages_storage_beverages_storage_beverage_id",
                        column: x => x.storage_beverage_id,
                        principalTable: "storage_beverages",
                        principalColumn: "beverage_id");
                });

            migrationBuilder.CreateTable(
                name: "coins",
                columns: table => new
                {
                    id = table.Column<Guid>(type: "uuid", nullable: false),
                    value = table.Column<decimal>(type: "numeric", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_coins", x => x.id);
                    table.ForeignKey(
                        name: "fk_coins_storage_coins_id",
                        column: x => x.id,
                        principalTable: "storage_coins",
                        principalColumn: "coin_id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "ix_beverages_price",
                table: "beverages",
                column: "price");

            migrationBuilder.CreateIndex(
                name: "ix_beverages_storage_beverage_id",
                table: "beverages",
                column: "storage_beverage_id",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "ix_beverages_title",
                table: "beverages",
                column: "title");

            migrationBuilder.CreateIndex(
                name: "ix_coins_value",
                table: "coins",
                column: "value");

            migrationBuilder.CreateIndex(
                name: "ix_storage_beverages_count",
                table: "storage_beverages",
                column: "count");

            migrationBuilder.CreateIndex(
                name: "ix_storage_coins_count",
                table: "storage_coins",
                column: "count");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "beverages");

            migrationBuilder.DropTable(
                name: "coins");

            migrationBuilder.DropTable(
                name: "beverage_images");

            migrationBuilder.DropTable(
                name: "storage_beverages");

            migrationBuilder.DropTable(
                name: "storage_coins");
        }
    }
}
