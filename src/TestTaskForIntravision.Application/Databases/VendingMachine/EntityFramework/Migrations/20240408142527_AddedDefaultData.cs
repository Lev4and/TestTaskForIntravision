using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace TestTaskForIntravision.Application.Databases.VendingMachine.EntityFramework.Migrations
{
    /// <inheritdoc />
    public partial class AddedDefaultData : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<bool>(
                name: "is_blocked_for_deposit",
                table: "storage_coins",
                type: "boolean",
                nullable: false,
                defaultValue: false);

            migrationBuilder.InsertData(
                table: "beverage_images",
                columns: new[] { "id", "beverage_id", "url" },
                values: new object[,]
                {
                    { new Guid("03fdfa86-05f2-4d1f-996d-188fae0b3829"), new Guid("fa681e9d-d304-4358-99e0-71244a6c0014"), "https://lenta.servicecdn.ru/globalassets/1/-/50/86/69/13b74f22-2728-55ca-b284-ace48a86514c.png?preset=fulllossywhite" },
                    { new Guid("23f1955f-05ed-4836-91a0-fea1e31ab83d"), new Guid("a54f7aa1-1eda-4bc0-8481-58e741fc9f86"), "https://lenta.servicecdn.ru/globalassets/1/-/50/14/39/249346_1.png?preset=fulllossywhite" },
                    { new Guid("2b91ef26-1232-4fb0-aab9-e373ac5a93d1"), new Guid("dd42b6a4-fb4e-4022-a34f-6a07e94cab8a"), "https://lenta.servicecdn.ru/globalassets/1/-/67/99/68/479519.png?preset=fulllossywhite" },
                    { new Guid("2e4d86ce-23c9-4c24-9245-92714841a99a"), new Guid("fca51e13-1875-46fd-9e25-4728f4f09962"), "https://lenta.servicecdn.ru/globalassets/1/-/65/86/05/296384c1-bbb0-5ca5-8872-a3c5bdb00343_1.png?preset=fulllossywhite" },
                    { new Guid("2e5c0935-5cff-4fa9-bea2-3b6218767236"), new Guid("da310bc3-0e9e-4183-bb12-860675f22a75"), "https://lenta.servicecdn.ru/globalassets/1/-/65/86/06/18228960-e6b3-513d-b43b-f0df039eefc9_1.png?preset=fulllossywhite" },
                    { new Guid("35dd0475-5acf-44d9-9d6c-e1591f89468c"), new Guid("d6c185da-e136-4e31-9d6c-440ce6d3ffa1"), "https://lenta.servicecdn.ru/globalassets/1/-/65/86/07/437717_1.png?preset=fulllossywhite" },
                    { new Guid("70361347-9d92-4e17-91fb-beb1c20cb1f3"), new Guid("907dba77-8a18-4a69-9bc0-bb2a94b2c326"), "https://lenta.servicecdn.ru/globalassets/1/-/48/48/76/a9ccd5a6-200f-5306-9d93-b5225719e483_1.png?preset=fulllossywhite" },
                    { new Guid("84129000-660a-4688-8320-87c34c44db63"), new Guid("ac2b9500-e6e6-4d29-9899-1d3f4304ee29"), "https://lenta.servicecdn.ru/globalassets/1/-/53/41/25/251073_2.png?preset=fulllossywhite" },
                    { new Guid("8f1d40d7-ce08-4c7f-b087-382dff6d2496"), new Guid("c5a455eb-4445-4e11-ac9f-6f6520a529da"), "https://lenta.servicecdn.ru/globalassets/1/-/65/86/08/437715_1.png?preset=fulllossywhite" },
                    { new Guid("9956f5d9-07ab-4e60-942a-34171000f557"), new Guid("ab973cc1-0313-4324-ad63-b7572004de8d"), "https://lenta.servicecdn.ru/globalassets/1/-/65/86/09/7c8f2be3-1270-56ee-839a-1e05fcb9a75b_1.png?preset=fulllossywhite" },
                    { new Guid("a7c0fe12-8e24-4f80-98a6-89d9b457847a"), new Guid("2ae2f786-af31-4282-8796-0c6ab8540cec"), "https://lenta.servicecdn.ru/globalassets/1/-/65/90/48/442688.png?preset=fulllossywhite" },
                    { new Guid("cc13a760-f11f-4e89-91a9-f44df584ee79"), new Guid("110cf5f8-9cfb-4bf4-98bb-c4d5e1bd286e"), "https://lenta.servicecdn.ru/globalassets/1/-/44/93/94/283080_9.png?preset=fulllossywhite" },
                    { new Guid("d82cabdf-f1ff-4336-b2f5-541b1afca315"), new Guid("87576b72-e4b6-4194-a5e5-75cc391f0c93"), "https://lenta.servicecdn.ru/globalassets/1/-/50/79/72/188132.png?preset=fulllossywhite" },
                    { new Guid("fb91da02-864e-4f13-b61f-d3d69df11d52"), new Guid("f2a6ea68-a33f-4ee8-8fc8-0532ef49c308"), "https://lenta.servicecdn.ru/globalassets/1/-/63/68/75/4d18e191-6454-57e8-89ec-9716286140d5.png?preset=fulllossywhite" }
                });

            migrationBuilder.InsertData(
                table: "storage_beverages",
                columns: new[] { "id", "beverage_id", "count" },
                values: new object[,]
                {
                    { new Guid("16a32ef0-b43d-4371-a41c-ab3e29d0688c"), new Guid("2ae2f786-af31-4282-8796-0c6ab8540cec"), 2L },
                    { new Guid("3c6670e4-6a50-4b42-8e0c-8aac1429db11"), new Guid("110cf5f8-9cfb-4bf4-98bb-c4d5e1bd286e"), 0L },
                    { new Guid("3fb2d4a5-7cc3-4d50-a800-282b8aaedf3a"), new Guid("87576b72-e4b6-4194-a5e5-75cc391f0c93"), 3L },
                    { new Guid("3fcf0bd6-b7e7-4654-86d9-e6d6dfd7a575"), new Guid("a54f7aa1-1eda-4bc0-8481-58e741fc9f86"), 5L },
                    { new Guid("421cfe57-f499-4ad8-a55d-51d394cd10aa"), new Guid("fca51e13-1875-46fd-9e25-4728f4f09962"), 3L },
                    { new Guid("462094fa-e637-4434-a750-ac8c74b12004"), new Guid("dd42b6a4-fb4e-4022-a34f-6a07e94cab8a"), 2L },
                    { new Guid("55c16d07-bff2-4fdc-a125-866eb4d56916"), new Guid("907dba77-8a18-4a69-9bc0-bb2a94b2c326"), 1L },
                    { new Guid("9a60210e-297b-460b-b88b-e04763612694"), new Guid("da310bc3-0e9e-4183-bb12-860675f22a75"), 3L },
                    { new Guid("a730bd9b-fb99-42db-96d3-58edaa93851d"), new Guid("ac2b9500-e6e6-4d29-9899-1d3f4304ee29"), 4L },
                    { new Guid("b5c2073f-303c-4779-9812-34e1476d3351"), new Guid("c5a455eb-4445-4e11-ac9f-6f6520a529da"), 4L },
                    { new Guid("daa4b771-a079-45cd-b859-6d5bbf171502"), new Guid("fa681e9d-d304-4358-99e0-71244a6c0014"), 2L },
                    { new Guid("e1a5e1ea-6e6a-4a8b-bf54-0a5a5189b8a2"), new Guid("f2a6ea68-a33f-4ee8-8fc8-0532ef49c308"), 5L },
                    { new Guid("fe47162d-e857-4a1a-b6ae-250f9f42a15e"), new Guid("d6c185da-e136-4e31-9d6c-440ce6d3ffa1"), 4L },
                    { new Guid("ffa5821e-edaa-498f-a132-d36fa7fd9937"), new Guid("ab973cc1-0313-4324-ad63-b7572004de8d"), 1L }
                });

            migrationBuilder.InsertData(
                table: "storage_coins",
                columns: new[] { "id", "coin_id", "count", "is_blocked_for_deposit" },
                values: new object[,]
                {
                    { new Guid("1afff46c-eb57-46a3-80ef-62988a93aba1"), new Guid("238bcf95-3380-4dde-b878-f3de87e11cd6"), 25L, false },
                    { new Guid("5da7221e-efaf-45dc-9ab8-8de83bee6e7e"), new Guid("406ee996-3552-4bfb-9d3a-b149d99b2a47"), 50L, true },
                    { new Guid("e876e3c9-fa62-4889-9491-6a21484195cc"), new Guid("82e050b3-dce3-4d56-a95c-b62911867fe2"), 75L, false },
                    { new Guid("ef503d11-c3f6-4275-919a-204d21dc565e"), new Guid("d32859c5-e579-47ed-bea9-afcf252ed0fd"), 100L, false }
                });

            migrationBuilder.InsertData(
                table: "beverages",
                columns: new[] { "id", "price", "storage_beverage_id", "title" },
                values: new object[,]
                {
                    { new Guid("110cf5f8-9cfb-4bf4-98bb-c4d5e1bd286e"), 70m, null, "Вода минеральная BORJOMI природная газированная, 0.33л, Грузия, 0.33 L" },
                    { new Guid("2ae2f786-af31-4282-8796-0c6ab8540cec"), 45m, null, "Напиток COOL COLA сильногазированный, 0.33л, Россия, 0.33 L" },
                    { new Guid("87576b72-e4b6-4194-a5e5-75cc391f0c93"), 135m, null, "Напиток CHUPA CHUPS Апельсин газированный, 0.345л, Корея, 0.345 L" },
                    { new Guid("907dba77-8a18-4a69-9bc0-bb2a94b2c326"), 150m, null, "Напиток CHUPA CHUPS Клубничный крем газированный, 0.345л, Корея, 0.345 L" },
                    { new Guid("a54f7aa1-1eda-4bc0-8481-58e741fc9f86"), 120m, null, "Напиток энергетический ADRENALINE Rush Энергия газированный, 0.449л, Россия, 0.449 L" },
                    { new Guid("ab973cc1-0313-4324-ad63-b7572004de8d"), 80m, null, "Напиток ДОБРЫЙ Кола без сахара сильногазированный, 0.33л, Россия, 0.33 L" },
                    { new Guid("ac2b9500-e6e6-4d29-9899-1d3f4304ee29"), 95m, null, "Напиток энергетический BURN сильногазированный, 0.449л, Россия, 0.449 L" },
                    { new Guid("c5a455eb-4445-4e11-ac9f-6f6520a529da"), 80m, null, "Напиток ДОБРЫЙ Лимон, лайм сильногазированный, 0.33л, Россия, 0.33 L" },
                    { new Guid("d6c185da-e136-4e31-9d6c-440ce6d3ffa1"), 80m, null, "Напиток ДОБРЫЙ Манго, маракуйя сильногазированный, 0.33л" },
                    { new Guid("da310bc3-0e9e-4183-bb12-860675f22a75"), 80m, null, "Напиток ДОБРЫЙ Апельсин сильногазированный, 0.33л, Россия, 0.33 L" },
                    { new Guid("dd42b6a4-fb4e-4022-a34f-6a07e94cab8a"), 55m, null, "Напиток ФРУСТАЙЛ Лимон, лайм газированный, 0.33л, Россия, 0.33 L" },
                    { new Guid("f2a6ea68-a33f-4ee8-8fc8-0532ef49c308"), 84m, null, "Напиток сокосодержащий RICH Fleur из винограда с ароматом лаванды газированный, 0.33л" },
                    { new Guid("fa681e9d-d304-4358-99e0-71244a6c0014"), 60m, null, "Напиток энергетический ФЛЭШ АП Energy Ягодный микс с кофеином и таурином газированный, 0.45л, Россия, 0.45 L" },
                    { new Guid("fca51e13-1875-46fd-9e25-4728f4f09962"), 80m, null, "Напиток ДОБРЫЙ Кола сильногазированный, 0.33л, Россия, 0.33 L" }
                });

            migrationBuilder.InsertData(
                table: "coins",
                columns: new[] { "id", "value" },
                values: new object[,]
                {
                    { new Guid("238bcf95-3380-4dde-b878-f3de87e11cd6"), 10m },
                    { new Guid("406ee996-3552-4bfb-9d3a-b149d99b2a47"), 5m },
                    { new Guid("82e050b3-dce3-4d56-a95c-b62911867fe2"), 2m },
                    { new Guid("d32859c5-e579-47ed-bea9-afcf252ed0fd"), 1m }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "beverages",
                keyColumn: "id",
                keyValue: new Guid("110cf5f8-9cfb-4bf4-98bb-c4d5e1bd286e"));

            migrationBuilder.DeleteData(
                table: "beverages",
                keyColumn: "id",
                keyValue: new Guid("2ae2f786-af31-4282-8796-0c6ab8540cec"));

            migrationBuilder.DeleteData(
                table: "beverages",
                keyColumn: "id",
                keyValue: new Guid("87576b72-e4b6-4194-a5e5-75cc391f0c93"));

            migrationBuilder.DeleteData(
                table: "beverages",
                keyColumn: "id",
                keyValue: new Guid("907dba77-8a18-4a69-9bc0-bb2a94b2c326"));

            migrationBuilder.DeleteData(
                table: "beverages",
                keyColumn: "id",
                keyValue: new Guid("a54f7aa1-1eda-4bc0-8481-58e741fc9f86"));

            migrationBuilder.DeleteData(
                table: "beverages",
                keyColumn: "id",
                keyValue: new Guid("ab973cc1-0313-4324-ad63-b7572004de8d"));

            migrationBuilder.DeleteData(
                table: "beverages",
                keyColumn: "id",
                keyValue: new Guid("ac2b9500-e6e6-4d29-9899-1d3f4304ee29"));

            migrationBuilder.DeleteData(
                table: "beverages",
                keyColumn: "id",
                keyValue: new Guid("c5a455eb-4445-4e11-ac9f-6f6520a529da"));

            migrationBuilder.DeleteData(
                table: "beverages",
                keyColumn: "id",
                keyValue: new Guid("d6c185da-e136-4e31-9d6c-440ce6d3ffa1"));

            migrationBuilder.DeleteData(
                table: "beverages",
                keyColumn: "id",
                keyValue: new Guid("da310bc3-0e9e-4183-bb12-860675f22a75"));

            migrationBuilder.DeleteData(
                table: "beverages",
                keyColumn: "id",
                keyValue: new Guid("dd42b6a4-fb4e-4022-a34f-6a07e94cab8a"));

            migrationBuilder.DeleteData(
                table: "beverages",
                keyColumn: "id",
                keyValue: new Guid("f2a6ea68-a33f-4ee8-8fc8-0532ef49c308"));

            migrationBuilder.DeleteData(
                table: "beverages",
                keyColumn: "id",
                keyValue: new Guid("fa681e9d-d304-4358-99e0-71244a6c0014"));

            migrationBuilder.DeleteData(
                table: "beverages",
                keyColumn: "id",
                keyValue: new Guid("fca51e13-1875-46fd-9e25-4728f4f09962"));

            migrationBuilder.DeleteData(
                table: "coins",
                keyColumn: "id",
                keyValue: new Guid("238bcf95-3380-4dde-b878-f3de87e11cd6"));

            migrationBuilder.DeleteData(
                table: "coins",
                keyColumn: "id",
                keyValue: new Guid("406ee996-3552-4bfb-9d3a-b149d99b2a47"));

            migrationBuilder.DeleteData(
                table: "coins",
                keyColumn: "id",
                keyValue: new Guid("82e050b3-dce3-4d56-a95c-b62911867fe2"));

            migrationBuilder.DeleteData(
                table: "coins",
                keyColumn: "id",
                keyValue: new Guid("d32859c5-e579-47ed-bea9-afcf252ed0fd"));

            migrationBuilder.DeleteData(
                table: "storage_beverages",
                keyColumn: "id",
                keyValue: new Guid("16a32ef0-b43d-4371-a41c-ab3e29d0688c"));

            migrationBuilder.DeleteData(
                table: "storage_beverages",
                keyColumn: "id",
                keyValue: new Guid("3c6670e4-6a50-4b42-8e0c-8aac1429db11"));

            migrationBuilder.DeleteData(
                table: "storage_beverages",
                keyColumn: "id",
                keyValue: new Guid("3fb2d4a5-7cc3-4d50-a800-282b8aaedf3a"));

            migrationBuilder.DeleteData(
                table: "storage_beverages",
                keyColumn: "id",
                keyValue: new Guid("3fcf0bd6-b7e7-4654-86d9-e6d6dfd7a575"));

            migrationBuilder.DeleteData(
                table: "storage_beverages",
                keyColumn: "id",
                keyValue: new Guid("421cfe57-f499-4ad8-a55d-51d394cd10aa"));

            migrationBuilder.DeleteData(
                table: "storage_beverages",
                keyColumn: "id",
                keyValue: new Guid("462094fa-e637-4434-a750-ac8c74b12004"));

            migrationBuilder.DeleteData(
                table: "storage_beverages",
                keyColumn: "id",
                keyValue: new Guid("55c16d07-bff2-4fdc-a125-866eb4d56916"));

            migrationBuilder.DeleteData(
                table: "storage_beverages",
                keyColumn: "id",
                keyValue: new Guid("9a60210e-297b-460b-b88b-e04763612694"));

            migrationBuilder.DeleteData(
                table: "storage_beverages",
                keyColumn: "id",
                keyValue: new Guid("a730bd9b-fb99-42db-96d3-58edaa93851d"));

            migrationBuilder.DeleteData(
                table: "storage_beverages",
                keyColumn: "id",
                keyValue: new Guid("b5c2073f-303c-4779-9812-34e1476d3351"));

            migrationBuilder.DeleteData(
                table: "storage_beverages",
                keyColumn: "id",
                keyValue: new Guid("daa4b771-a079-45cd-b859-6d5bbf171502"));

            migrationBuilder.DeleteData(
                table: "storage_beverages",
                keyColumn: "id",
                keyValue: new Guid("e1a5e1ea-6e6a-4a8b-bf54-0a5a5189b8a2"));

            migrationBuilder.DeleteData(
                table: "storage_beverages",
                keyColumn: "id",
                keyValue: new Guid("fe47162d-e857-4a1a-b6ae-250f9f42a15e"));

            migrationBuilder.DeleteData(
                table: "storage_beverages",
                keyColumn: "id",
                keyValue: new Guid("ffa5821e-edaa-498f-a132-d36fa7fd9937"));

            migrationBuilder.DeleteData(
                table: "beverage_images",
                keyColumn: "id",
                keyValue: new Guid("03fdfa86-05f2-4d1f-996d-188fae0b3829"));

            migrationBuilder.DeleteData(
                table: "beverage_images",
                keyColumn: "id",
                keyValue: new Guid("23f1955f-05ed-4836-91a0-fea1e31ab83d"));

            migrationBuilder.DeleteData(
                table: "beverage_images",
                keyColumn: "id",
                keyValue: new Guid("2b91ef26-1232-4fb0-aab9-e373ac5a93d1"));

            migrationBuilder.DeleteData(
                table: "beverage_images",
                keyColumn: "id",
                keyValue: new Guid("2e4d86ce-23c9-4c24-9245-92714841a99a"));

            migrationBuilder.DeleteData(
                table: "beverage_images",
                keyColumn: "id",
                keyValue: new Guid("2e5c0935-5cff-4fa9-bea2-3b6218767236"));

            migrationBuilder.DeleteData(
                table: "beverage_images",
                keyColumn: "id",
                keyValue: new Guid("35dd0475-5acf-44d9-9d6c-e1591f89468c"));

            migrationBuilder.DeleteData(
                table: "beverage_images",
                keyColumn: "id",
                keyValue: new Guid("70361347-9d92-4e17-91fb-beb1c20cb1f3"));

            migrationBuilder.DeleteData(
                table: "beverage_images",
                keyColumn: "id",
                keyValue: new Guid("84129000-660a-4688-8320-87c34c44db63"));

            migrationBuilder.DeleteData(
                table: "beverage_images",
                keyColumn: "id",
                keyValue: new Guid("8f1d40d7-ce08-4c7f-b087-382dff6d2496"));

            migrationBuilder.DeleteData(
                table: "beverage_images",
                keyColumn: "id",
                keyValue: new Guid("9956f5d9-07ab-4e60-942a-34171000f557"));

            migrationBuilder.DeleteData(
                table: "beverage_images",
                keyColumn: "id",
                keyValue: new Guid("a7c0fe12-8e24-4f80-98a6-89d9b457847a"));

            migrationBuilder.DeleteData(
                table: "beverage_images",
                keyColumn: "id",
                keyValue: new Guid("cc13a760-f11f-4e89-91a9-f44df584ee79"));

            migrationBuilder.DeleteData(
                table: "beverage_images",
                keyColumn: "id",
                keyValue: new Guid("d82cabdf-f1ff-4336-b2f5-541b1afca315"));

            migrationBuilder.DeleteData(
                table: "beverage_images",
                keyColumn: "id",
                keyValue: new Guid("fb91da02-864e-4f13-b61f-d3d69df11d52"));

            migrationBuilder.DeleteData(
                table: "storage_coins",
                keyColumn: "id",
                keyValue: new Guid("1afff46c-eb57-46a3-80ef-62988a93aba1"));

            migrationBuilder.DeleteData(
                table: "storage_coins",
                keyColumn: "id",
                keyValue: new Guid("5da7221e-efaf-45dc-9ab8-8de83bee6e7e"));

            migrationBuilder.DeleteData(
                table: "storage_coins",
                keyColumn: "id",
                keyValue: new Guid("e876e3c9-fa62-4889-9491-6a21484195cc"));

            migrationBuilder.DeleteData(
                table: "storage_coins",
                keyColumn: "id",
                keyValue: new Guid("ef503d11-c3f6-4275-919a-204d21dc565e"));

            migrationBuilder.DropColumn(
                name: "is_blocked_for_deposit",
                table: "storage_coins");
        }
    }
}
