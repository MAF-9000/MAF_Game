using GameInterface.Game;
using GameInterface.Game.Characters;
using LordOfTheRings.Items;

namespace LordOfTheRings.Characters
{
    internal class Merchant
    {
        public string Name = "Торговец";
        public List<IItem> Goods;

        public Merchant()
        {
            Random random = new Random();
            var lootcount = random.Next(3, 5);
            Goods = new List<IItem>();
            for (int i = 0; i < lootcount; i++)
            {
                Goods.Add(ItemFabric.CreateRandomItem());
            }

        }
        public async Task MerchantMenu(IRace person)
        {
            Cnsl.WriteLine("Вы случайно встретили торговца на тракте");
            string comand = string.Empty;
            do
            {
                Cnsl.WriteLine("");
                Cnsl.WriteAction($"1 - Посмотреть товары");
                Cnsl.WriteAction("2 - Продать из инвентаря");
                Cnsl.WriteAction($"3 - Послушать истории");
                Cnsl.WriteAction("4 - Идти дальше");

                comand = await Cnsl.ReadLine();
                switch (comand)
                {
                    case "1":
                        {
                            await ShoppingMenu(person);
                        }
                        break;
                    case "2":
                        {
                            await SaleMenu(person);
                        }
                        break;
                    case "3":
                        {
                            TolkHistory();
                        }
                        break;

                }
            }
            while (comand != "4");
        }

        private async Task ShoppingMenu(IRace person)
        {
            string comand = string.Empty;
            do
            {
                Cnsl.WriteLine($"Ваше количество золота - {person.Inventary.Gold}");
                Cnsl.WriteLine("Список товаров:");
                int count = 1;
                foreach (IItem item in Goods)
                {
                    Cnsl.Write($"{count}. ");
                    item.ItemState();
                    count++;
                }


                for (int i = 0; i < Goods.Count; i++)
                {
                    Cnsl.WriteAction($"{i + 1} - Купить {Goods[i].Name}");

                }
                Cnsl.WriteAction("b - Выход");
                comand = await Cnsl.ReadLine();
                int comandNum = 0;
                if (int.TryParse(comand, out comandNum) && comandNum <= Goods.Count)
                {
                    if (person.Inventary.TryToBuyItem(Goods[comandNum - 1]))
                    {
                        Goods.Remove(Goods[comandNum - 1]);
                    }
                }
            }
            while (comand != "b");

        }
        private async Task SaleMenu(IRace person)
        {
            string comand = string.Empty;
            do
            {
                Cnsl.WriteLine($"Ваше количество золота - {person.Inventary.Gold}");
            Cnsl.WriteLine("Список ваших товаров:");
            int count = 1;
            foreach (IItem item in person.Inventary.Items)
            {
                Cnsl.Write($"{count}. ");
                item.ItemState();
                count++;
            }
                for (int i = 0; i < person.Inventary.Items.Count; i++)
                {
                    Cnsl.WriteAction($"{i + 1} - Продать {person.Inventary.Items[i].Name}");

                }
                Cnsl.WriteAction("b - Выход");
                comand = await Cnsl.ReadLine();
                int comandNum = 0;
                if (int.TryParse(comand, out comandNum) && comandNum <= person.Inventary.Items.Count)
                {
                    person.Inventary.SaleItem(person.Inventary.Items[comandNum - 1]);
                    Goods.Add(person.Inventary.Items[comandNum - 1]);
                    person.Inventary.Items.Remove(person.Inventary.Items[comandNum - 1]);

                }
            }
            while (comand != "b");
        }
        private void TolkHistory()
        {
            var path = "History.txt";
            string history = File.ReadAllText(path);
            Random r = new Random();
            var pieces = history.Split('/');
            foreach (var piece in pieces)
            {
                var words = piece.Split('|');
                int preIndex = r.Next(0, 1000);
                int index = preIndex % words.Length;
                Cnsl.Write(words[index]);
            }
        }
    }
}
