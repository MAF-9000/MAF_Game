using GameInterface.Game.Characters;

namespace GameInterface.Game.Items.Armors
{
    internal class Shield : IShield
    {
        public string Name { get; private set; }

        public bool Disposable { get; private set; }

        public int Cost { get; private set; }

        public int Protection { get; private set; }

        public ItemRank Rank { get; private set; }

        public Shield()
        {
            Rank = ItemRank.Ordinary;
            Protection = 0;
            Cost = 0;
            Name = string.Empty;
        }
        public Shield(ItemRank rank)
        {
            Rank = rank;
            Protection = 7;
            Cost = 200;
            switch (rank)
            {
                case ItemRank.Ordinary:
                    {
                        Name = "Картонный щит";
                    }
                    break;
                case ItemRank.Rare:
                    {
                        Protection *= 2;
                        Cost *= 2;
                        Name = "Деревянный щит";
                    }
                    break;
                case ItemRank.Epic:
                    {
                        Protection *= 4;
                        Cost *= 4;
                        Name = "Стальный щит";
                    }
                    break;
                case ItemRank.Legendary:
                    {
                        Protection *= 8;
                        Cost *= 8;
                        Name = "Тяжелый щит из чешуи дракона";
                    }
                    break;
            }
            Disposable = false;
        }

        public void Execute(IRace person)
        {
            person.Shield = this;
        }

        public void ItemState()
        {
            Cnsl.WriteLine($"Щит: {Name} с защитой - {Protection}, цена предмета - {Cost} ");
        }
        public string ItemInfo()
        {
            return $"{Name}, защита({Protection}), цена({Cost})";
        }
    }
}
