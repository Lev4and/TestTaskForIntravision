using TestTaskForIntravision.Domain.Entities;

namespace TestTaskForIntravision.Application.Databases.VendingMachine.DefaultData
{
    public class Beverages : List<Beverage>
    {
        public Beverages()
        {
            Add(new Beverage
            {
                Id = Guid.Parse("a54f7aa1-1eda-4bc0-8481-58e741fc9f86"),
                Title = "Напиток энергетический ADRENALINE Rush Энергия газированный, 0.449л, Россия, 0.449 L",
                Price = 120,
                Image = new BeverageImage
                {
                    Id = Guid.Parse("23f1955f-05ed-4836-91a0-fea1e31ab83d"),
                    Url = "https://lenta.servicecdn.ru/globalassets/1/-/50/14/39/249346_1.png?preset=fulllossywhite",
                },
                Storage = new StorageBeverage
                {
                    Id = Guid.Parse("3fcf0bd6-b7e7-4654-86d9-e6d6dfd7a575"),
                    Count = 5
                },
            });

            Add(new Beverage
            {
                Id = Guid.Parse("ac2b9500-e6e6-4d29-9899-1d3f4304ee29"),
                Title = "Напиток энергетический BURN сильногазированный, 0.449л, Россия, 0.449 L",
                Price = 95,
                Image = new BeverageImage
                {
                    Id = Guid.Parse("84129000-660a-4688-8320-87c34c44db63"),
                    Url = "https://lenta.servicecdn.ru/globalassets/1/-/53/41/25/251073_2.png?preset=fulllossywhite",
                },
                Storage = new StorageBeverage
                {
                    Id = Guid.Parse("a730bd9b-fb99-42db-96d3-58edaa93851d"),
                    Count = 4
                },
            });

            Add(new Beverage
            {
                Id = Guid.Parse("fca51e13-1875-46fd-9e25-4728f4f09962"),
                Title = "Напиток ДОБРЫЙ Кола сильногазированный, 0.33л, Россия, 0.33 L",
                Price = 80,
                Image = new BeverageImage
                {
                    Id = Guid.Parse("2e4d86ce-23c9-4c24-9245-92714841a99a"),
                    Url = "https://lenta.servicecdn.ru/globalassets/1/-/65/86/05/296384c1-bbb0-5ca5-8872-a3c5bdb00343_1.png?preset=fulllossywhite",
                },
                Storage = new StorageBeverage
                {
                    Id = Guid.Parse("421cfe57-f499-4ad8-a55d-51d394cd10aa"),
                    Count = 3
                },
            });

            Add(new Beverage
            {
                Id = Guid.Parse("fa681e9d-d304-4358-99e0-71244a6c0014"),
                Title = "Напиток энергетический ФЛЭШ АП Energy Ягодный микс с кофеином и таурином газированный, 0.45л, Россия, 0.45 L",
                Price = 60,
                Image = new BeverageImage
                {
                    Id = Guid.Parse("03fdfa86-05f2-4d1f-996d-188fae0b3829"),
                    Url = "https://lenta.servicecdn.ru/globalassets/1/-/50/86/69/13b74f22-2728-55ca-b284-ace48a86514c.png?preset=fulllossywhite",
                },
                Storage = new StorageBeverage
                {
                    Id = Guid.Parse("daa4b771-a079-45cd-b859-6d5bbf171502"),
                    Count = 2
                },
            });

            Add(new Beverage
            {
                Id = Guid.Parse("ab973cc1-0313-4324-ad63-b7572004de8d"),
                Title = "Напиток ДОБРЫЙ Кола без сахара сильногазированный, 0.33л, Россия, 0.33 L",
                Price = 80,
                Image = new BeverageImage
                {
                    Id = Guid.Parse("9956f5d9-07ab-4e60-942a-34171000f557"),
                    Url = "https://lenta.servicecdn.ru/globalassets/1/-/65/86/09/7c8f2be3-1270-56ee-839a-1e05fcb9a75b_1.png?preset=fulllossywhite",
                },
                Storage = new StorageBeverage
                {
                    Id = Guid.Parse("ffa5821e-edaa-498f-a132-d36fa7fd9937"),
                    Count = 1
                },
            });

            Add(new Beverage
            {
                Id = Guid.Parse("110cf5f8-9cfb-4bf4-98bb-c4d5e1bd286e"),
                Title = "Вода минеральная BORJOMI природная газированная, 0.33л, Грузия, 0.33 L",
                Price = 70,
                Image = new BeverageImage
                {
                    Id = Guid.Parse("cc13a760-f11f-4e89-91a9-f44df584ee79"),
                    Url = "https://lenta.servicecdn.ru/globalassets/1/-/44/93/94/283080_9.png?preset=fulllossywhite",
                },
                Storage = new StorageBeverage
                {
                    Id = Guid.Parse("3c6670e4-6a50-4b42-8e0c-8aac1429db11"),
                    Count = 0
                },
            });

            Add(new Beverage
            {
                Id = Guid.Parse("907dba77-8a18-4a69-9bc0-bb2a94b2c326"),
                Title = "Напиток CHUPA CHUPS Клубничный крем газированный, 0.345л, Корея, 0.345 L",
                Price = 150,
                Image = new BeverageImage
                {
                    Id = Guid.Parse("70361347-9d92-4e17-91fb-beb1c20cb1f3"),
                    Url = "https://lenta.servicecdn.ru/globalassets/1/-/48/48/76/a9ccd5a6-200f-5306-9d93-b5225719e483_1.png?preset=fulllossywhite",
                },
                Storage = new StorageBeverage
                {
                    Id = Guid.Parse("55c16d07-bff2-4fdc-a125-866eb4d56916"),
                    Count = 1
                },
            });

            Add(new Beverage
            {
                Id = Guid.Parse("2ae2f786-af31-4282-8796-0c6ab8540cec"),
                Title = "Напиток COOL COLA сильногазированный, 0.33л, Россия, 0.33 L",
                Price = 45,
                Image = new BeverageImage
                {
                    Id = Guid.Parse("a7c0fe12-8e24-4f80-98a6-89d9b457847a"),
                    Url = "https://lenta.servicecdn.ru/globalassets/1/-/65/90/48/442688.png?preset=fulllossywhite",
                },
                Storage = new StorageBeverage
                {
                    Id = Guid.Parse("16a32ef0-b43d-4371-a41c-ab3e29d0688c"),
                    Count = 2
                },
            });

            Add(new Beverage
            {
                Id = Guid.Parse("da310bc3-0e9e-4183-bb12-860675f22a75"),
                Title = "Напиток ДОБРЫЙ Апельсин сильногазированный, 0.33л, Россия, 0.33 L",
                Price = 80,
                Image = new BeverageImage
                {
                    Id = Guid.Parse("2e5c0935-5cff-4fa9-bea2-3b6218767236"),
                    Url = "https://lenta.servicecdn.ru/globalassets/1/-/65/86/06/18228960-e6b3-513d-b43b-f0df039eefc9_1.png?preset=fulllossywhite",
                },
                Storage = new StorageBeverage
                {
                    Id = Guid.Parse("9a60210e-297b-460b-b88b-e04763612694"),
                    Count = 3
                },
            });

            Add(new Beverage
            {
                Id = Guid.Parse("c5a455eb-4445-4e11-ac9f-6f6520a529da"),
                Title = "Напиток ДОБРЫЙ Лимон, лайм сильногазированный, 0.33л, Россия, 0.33 L",
                Price = 80,
                Image = new BeverageImage
                {
                    Id = Guid.Parse("8f1d40d7-ce08-4c7f-b087-382dff6d2496"),
                    Url = "https://lenta.servicecdn.ru/globalassets/1/-/65/86/08/437715_1.png?preset=fulllossywhite",
                },
                Storage = new StorageBeverage
                {
                    Id = Guid.Parse("b5c2073f-303c-4779-9812-34e1476d3351"),
                    Count = 4
                },
            });

            Add(new Beverage
            {
                Id = Guid.Parse("f2a6ea68-a33f-4ee8-8fc8-0532ef49c308"),
                Title = "Напиток сокосодержащий RICH Fleur из винограда с ароматом лаванды газированный, 0.33л",
                Price = 84,
                Image = new BeverageImage
                {
                    Id = Guid.Parse("fb91da02-864e-4f13-b61f-d3d69df11d52"),
                    Url = "https://lenta.servicecdn.ru/globalassets/1/-/63/68/75/4d18e191-6454-57e8-89ec-9716286140d5.png?preset=fulllossywhite",
                },
                Storage = new StorageBeverage
                {
                    Id = Guid.Parse("e1a5e1ea-6e6a-4a8b-bf54-0a5a5189b8a2"),
                    Count = 5
                },
            });

            Add(new Beverage
            {
                Id = Guid.Parse("d6c185da-e136-4e31-9d6c-440ce6d3ffa1"),
                Title = "Напиток ДОБРЫЙ Манго, маракуйя сильногазированный, 0.33л",
                Price = 80,
                Image = new BeverageImage
                {
                    Id = Guid.Parse("35dd0475-5acf-44d9-9d6c-e1591f89468c"),
                    Url = "https://lenta.servicecdn.ru/globalassets/1/-/65/86/07/437717_1.png?preset=fulllossywhite",
                },
                Storage = new StorageBeverage
                {
                    Id = Guid.Parse("fe47162d-e857-4a1a-b6ae-250f9f42a15e"),
                    Count = 4
                },
            });

            Add(new Beverage
            {
                Id = Guid.Parse("87576b72-e4b6-4194-a5e5-75cc391f0c93"),
                Title = "Напиток CHUPA CHUPS Апельсин газированный, 0.345л, Корея, 0.345 L",
                Price = 135,
                Image = new BeverageImage
                {
                    Id = Guid.Parse("d82cabdf-f1ff-4336-b2f5-541b1afca315"),
                    Url = "https://lenta.servicecdn.ru/globalassets/1/-/50/79/72/188132.png?preset=fulllossywhite",
                },
                Storage = new StorageBeverage
                {
                    Id = Guid.Parse("3fb2d4a5-7cc3-4d50-a800-282b8aaedf3a"),
                    Count = 3
                },
            });

            Add(new Beverage
            {
                Id = Guid.Parse("dd42b6a4-fb4e-4022-a34f-6a07e94cab8a"),
                Title = "Напиток ФРУСТАЙЛ Лимон, лайм газированный, 0.33л, Россия, 0.33 L",
                Price = 55,
                Image = new BeverageImage
                {
                    Id = Guid.Parse("2b91ef26-1232-4fb0-aab9-e373ac5a93d1"),
                    Url = "https://lenta.servicecdn.ru/globalassets/1/-/67/99/68/479519.png?preset=fulllossywhite",
                },
                Storage = new StorageBeverage
                {
                    Id = Guid.Parse("462094fa-e637-4434-a750-ac8c74b12004"),
                    Count = 2
                },
            });
        }
    }
}
