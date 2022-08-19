using GameInterface.Game;
using GameInterface.Game.Characters;
using LordOfTheRings.Characters;

namespace LordOfTheRings.Items
{
    public class Inventary
    {
        public List<IItem> Items
        { get; private set; }

        public int Gold
        { get; private set; }

        public Inventary()
        {
            Items = new List<IItem>();
            Gold = 0;
        }

        public void AddGold(int gold)
        {
            Gold = Gold + gold;
        
        }

        public void AddItem(IItem item)
        {
            Items.Add(item);
        }

        public bool TryToBuyItem(IItem item)
        {
           if(Gold>=item.Cost)
            {
                Gold = Gold - item.Cost;
                Cnsl.WriteLine($"Вы купили товар {item.Name} за цену {item.Cost}, у Вас осталось денег - {Gold}");
                AddItem(item);
                return true;
            }
            else
            {
                Cnsl.WriteLine($"Вы не можете купить товар {item.Name} за цену {item.Cost}, у Вас осталось денег - {Gold}");
            }
            return false;
           
            // попытка купить товар если хватает денег
        }
        public void SaleItem(IItem item)
        {
            AddGold(item.Cost);
            Cnsl.WriteLine($"Вы продали товар {item.Name} за цену {item.Cost}, у Вас стало денег - {Gold}");
        }


        public async void InventaryMenu(IRace person)
        {

            int count = 1;
            Cnsl.WriteLine("Список предметов:");
            Cnsl.WriteLine($"Количество золота - {Gold}");
            foreach (IItem item in Items)
            {
                Cnsl.Write($"{count}. ");
                item.ItemState();
                count++;
            }

            string comand = string.Empty;
            do
            {
                Cnsl.WriteLine($"1 - {Items.Count}  - Использовать предмет № ");
                Cnsl.WriteLine("b - Выход");
                comand = await Cnsl.ReadLine();
                int comandNum = 0;
                if(int.TryParse(comand, out comandNum)&&comandNum<= Items.Count)
                {
                    Items[comandNum - 1].Execute(person);
                    if (Items[comandNum - 1].Disposable )
                    {
                        Items.Remove(Items[comandNum - 1]);
                    }
                }
            }
            while (comand != "b");
        }
    }
}
