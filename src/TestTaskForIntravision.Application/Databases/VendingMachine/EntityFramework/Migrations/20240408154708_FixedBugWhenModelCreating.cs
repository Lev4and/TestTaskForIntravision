using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace TestTaskForIntravision.Application.Databases.VendingMachine.EntityFramework.Migrations
{
    /// <inheritdoc />
    public partial class FixedBugWhenModelCreating : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "fk_beverages_beverage_images_id",
                table: "beverages");

            migrationBuilder.DropForeignKey(
                name: "fk_beverages_storage_beverages_storage_beverage_id",
                table: "beverages");

            migrationBuilder.DropForeignKey(
                name: "fk_coins_storage_coins_id",
                table: "coins");

            migrationBuilder.DropUniqueConstraint(
                name: "ak_storage_coins_coin_id",
                table: "storage_coins");

            migrationBuilder.DropUniqueConstraint(
                name: "ak_storage_beverages_beverage_id",
                table: "storage_beverages");

            migrationBuilder.DropIndex(
                name: "ix_beverages_storage_beverage_id",
                table: "beverages");

            migrationBuilder.DropUniqueConstraint(
                name: "ak_beverage_images_beverage_id",
                table: "beverage_images");

            migrationBuilder.DropColumn(
                name: "storage_beverage_id",
                table: "beverages");

            migrationBuilder.CreateIndex(
                name: "ix_storage_coins_coin_id",
                table: "storage_coins",
                column: "coin_id",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "ix_storage_beverages_beverage_id",
                table: "storage_beverages",
                column: "beverage_id",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "ix_beverage_images_beverage_id",
                table: "beverage_images",
                column: "beverage_id",
                unique: true);

            migrationBuilder.AddForeignKey(
                name: "fk_beverage_images_beverages_beverage_id",
                table: "beverage_images",
                column: "beverage_id",
                principalTable: "beverages",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "fk_storage_beverages_beverages_beverage_id",
                table: "storage_beverages",
                column: "beverage_id",
                principalTable: "beverages",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "fk_storage_coins_coins_coin_id",
                table: "storage_coins",
                column: "coin_id",
                principalTable: "coins",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "fk_beverage_images_beverages_beverage_id",
                table: "beverage_images");

            migrationBuilder.DropForeignKey(
                name: "fk_storage_beverages_beverages_beverage_id",
                table: "storage_beverages");

            migrationBuilder.DropForeignKey(
                name: "fk_storage_coins_coins_coin_id",
                table: "storage_coins");

            migrationBuilder.DropIndex(
                name: "ix_storage_coins_coin_id",
                table: "storage_coins");

            migrationBuilder.DropIndex(
                name: "ix_storage_beverages_beverage_id",
                table: "storage_beverages");

            migrationBuilder.DropIndex(
                name: "ix_beverage_images_beverage_id",
                table: "beverage_images");

            migrationBuilder.AddColumn<Guid>(
                name: "storage_beverage_id",
                table: "beverages",
                type: "uuid",
                nullable: true);

            migrationBuilder.AddUniqueConstraint(
                name: "ak_storage_coins_coin_id",
                table: "storage_coins",
                column: "coin_id");

            migrationBuilder.AddUniqueConstraint(
                name: "ak_storage_beverages_beverage_id",
                table: "storage_beverages",
                column: "beverage_id");

            migrationBuilder.AddUniqueConstraint(
                name: "ak_beverage_images_beverage_id",
                table: "beverage_images",
                column: "beverage_id");

            migrationBuilder.UpdateData(
                table: "beverages",
                keyColumn: "id",
                keyValue: new Guid("110cf5f8-9cfb-4bf4-98bb-c4d5e1bd286e"),
                column: "storage_beverage_id",
                value: null);

            migrationBuilder.UpdateData(
                table: "beverages",
                keyColumn: "id",
                keyValue: new Guid("2ae2f786-af31-4282-8796-0c6ab8540cec"),
                column: "storage_beverage_id",
                value: null);

            migrationBuilder.UpdateData(
                table: "beverages",
                keyColumn: "id",
                keyValue: new Guid("87576b72-e4b6-4194-a5e5-75cc391f0c93"),
                column: "storage_beverage_id",
                value: null);

            migrationBuilder.UpdateData(
                table: "beverages",
                keyColumn: "id",
                keyValue: new Guid("907dba77-8a18-4a69-9bc0-bb2a94b2c326"),
                column: "storage_beverage_id",
                value: null);

            migrationBuilder.UpdateData(
                table: "beverages",
                keyColumn: "id",
                keyValue: new Guid("a54f7aa1-1eda-4bc0-8481-58e741fc9f86"),
                column: "storage_beverage_id",
                value: null);

            migrationBuilder.UpdateData(
                table: "beverages",
                keyColumn: "id",
                keyValue: new Guid("ab973cc1-0313-4324-ad63-b7572004de8d"),
                column: "storage_beverage_id",
                value: null);

            migrationBuilder.UpdateData(
                table: "beverages",
                keyColumn: "id",
                keyValue: new Guid("ac2b9500-e6e6-4d29-9899-1d3f4304ee29"),
                column: "storage_beverage_id",
                value: null);

            migrationBuilder.UpdateData(
                table: "beverages",
                keyColumn: "id",
                keyValue: new Guid("c5a455eb-4445-4e11-ac9f-6f6520a529da"),
                column: "storage_beverage_id",
                value: null);

            migrationBuilder.UpdateData(
                table: "beverages",
                keyColumn: "id",
                keyValue: new Guid("d6c185da-e136-4e31-9d6c-440ce6d3ffa1"),
                column: "storage_beverage_id",
                value: null);

            migrationBuilder.UpdateData(
                table: "beverages",
                keyColumn: "id",
                keyValue: new Guid("da310bc3-0e9e-4183-bb12-860675f22a75"),
                column: "storage_beverage_id",
                value: null);

            migrationBuilder.UpdateData(
                table: "beverages",
                keyColumn: "id",
                keyValue: new Guid("dd42b6a4-fb4e-4022-a34f-6a07e94cab8a"),
                column: "storage_beverage_id",
                value: null);

            migrationBuilder.UpdateData(
                table: "beverages",
                keyColumn: "id",
                keyValue: new Guid("f2a6ea68-a33f-4ee8-8fc8-0532ef49c308"),
                column: "storage_beverage_id",
                value: null);

            migrationBuilder.UpdateData(
                table: "beverages",
                keyColumn: "id",
                keyValue: new Guid("fa681e9d-d304-4358-99e0-71244a6c0014"),
                column: "storage_beverage_id",
                value: null);

            migrationBuilder.UpdateData(
                table: "beverages",
                keyColumn: "id",
                keyValue: new Guid("fca51e13-1875-46fd-9e25-4728f4f09962"),
                column: "storage_beverage_id",
                value: null);

            migrationBuilder.CreateIndex(
                name: "ix_beverages_storage_beverage_id",
                table: "beverages",
                column: "storage_beverage_id",
                unique: true);

            migrationBuilder.AddForeignKey(
                name: "fk_beverages_beverage_images_id",
                table: "beverages",
                column: "id",
                principalTable: "beverage_images",
                principalColumn: "beverage_id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "fk_beverages_storage_beverages_storage_beverage_id",
                table: "beverages",
                column: "storage_beverage_id",
                principalTable: "storage_beverages",
                principalColumn: "beverage_id");

            migrationBuilder.AddForeignKey(
                name: "fk_coins_storage_coins_id",
                table: "coins",
                column: "id",
                principalTable: "storage_coins",
                principalColumn: "coin_id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
