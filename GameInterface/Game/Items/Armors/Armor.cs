using GameInterface.Game;
using GameInterface.Game.Characters;
using GameInterface.Game.Items;
using GameInterface.Game.Items.Armors;
using LordOfTheRings.Items;

namespace LordOfTheRings.Armors
{
    public class Armor : IArmor
    {
        public string Name { get; private set; }

        public bool Disposable { get; private set; }

        public int Cost { get; private set; }

        public int Protection { get; private set; }

        public ItemRank Rank { get; private set; }

        public Armor()
        {
            Rank = ItemRank.Ordinary;
            Protection = 0;
            Cost = 0;
            Name = string.Empty;
        }

        public Armor(ItemRank rank)
        {
            Rank = rank;
            Protection = 5;
            Cost = 150;
            switch (rank)
            {
                case ItemRank.Ordinary:
                    {
                        Name = "Рубаха из соломы";
                    }
                    break;
                case ItemRank.Rare:
                    {
                        Protection *= 2;
                        Cost *= 2;
                        Name = "Стеганый дуплет";
                    }
                    break;
                case ItemRank.Epic:
                    {
                        Protection *= 4;
                        Cost *= 4;
                        Name = "Кольчуга";
                    }
                    break;
                case ItemRank.Legendary:
                    {
                        Protection *= 8;
                        Cost *= 8;
                        Name = "Золотой латный доспех ";
                    }
                    break;
            }
            Disposable = false;
        }
        public static IItem CreateRandom()
        {
            Random random = new Random();
            var type = random.Next(0, 99);
            ItemRank armorType = (ItemRank)(type % 3);
            return new Armor(armorType);
        }

        public void Execute(IRace person)
        {
            person.Armor = this;
        }
        public void ItemState()
        {
            Cnsl.WriteLine($"Броня: {Name} с защитой - {Protection}, цена предмета - {Cost} ");
        }
        public string ItemInfo()
        {
            return $"{Name}, защита({Protection}), цена({Cost})";
        }
    }  
}
