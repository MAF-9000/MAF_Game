using GameInterface.Game.Characters;

namespace GameInterface.Game.Items.Weapons
{
    internal class Clubs : IWeapon
    {

        public string Name { get; private set; }

        public bool Disposable { get; private set; }

        public int Cost { get; private set; }

        public int Attack { get; private set; }

        public ItemRank Rank { get; private set; }

        public Clubs()
        {
            Rank = ItemRank.Ordinary;
            Attack = 0;
            Cost = 0;
            Name = string.Empty;
        }

        public Clubs(ItemRank rank)
        {
            Rank = rank;
            Attack = 6;
            Cost = 100;
            switch (rank)
            {
                case ItemRank.Ordinary:
                    {
                        Name = "Деревянная дубина";
                    }
                    break;
                case ItemRank.Rare:
                    {
                        Attack *= 4;
                        Cost *= 6;
                        Name = "Кистень";
                    }
                    break;
                case ItemRank.Epic:
                    {
                        Attack *= 8;
                        Cost *= 10;
                        Name = "Стальная булава";
                    }
                    break;
                case ItemRank.Legendary:
                    {
                        Attack *= 10;
                        Cost *= 15;
                        Name = "Болевой молот";
                    }
                    break;
            }
            Disposable = false;
        }

        public void Execute(IRace person)
        {
            person.Weapon = this;
        }

        public void ItemState()
        {
            Cnsl.WriteLine($"Оружие: {Name} с атакой - {Attack}, цена предмета - {Cost} ");
        }
        public string ItemInfo()
        {
            return $"{Name}, атака({Attack}), цена({Cost})";
        }
    }
}

    

