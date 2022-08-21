using GameInterface.Game.Characters;

namespace GameInterface.Game.Items.Armors
{
    internal class Helmet : IHelmet
    {
        public string Name { get; private set; }

        public bool Disposable { get; private set; }

        public int Cost { get; private set; }

        public int Protection { get; private set; }

        public ItemRank Rank { get; private set; }

        public Helmet()
        {
            Rank = ItemRank.Ordinary;
            Protection = 0;
            Cost = 0;
            Name = string.Empty;
        }

        public Helmet(ItemRank rank)
        {
            Rank = rank;
            Protection = 5;
            Cost = 150;
            switch (rank)
            {
                case ItemRank.Ordinary:
                    {
                        Name = "Шапка из бобра";
                    }
                    break;
                case ItemRank.Rare:
                    {
                        Protection *= 2;
                        Cost *= 2;
                        Name = "Кожаный шлем";
                    }
                    break;
                case ItemRank.Epic:
                    {
                        Protection *= 6;
                        Cost *= 6;
                        Name = "Стильный шлем";
                    }
                    break;
                case ItemRank.Legendary:
                    {
                        Protection *= 10;
                        Cost *= 9;
                        Name = "Прочный гномий шлем";
                    }
                    break;
            }
            Disposable = false;
        }

        public void Execute(IRace person)
        {
            person.Helmet = this;
        }

        public void ItemState()
        {
            Cnsl.WriteLine($"Шлем: {Name} с защитой - {Protection}, цена предмета - {Cost} ");
        }
        public string ItemInfo()
        {
            return $"{Name}, защита({Protection}), цена({Cost})";
        }
    }
}
