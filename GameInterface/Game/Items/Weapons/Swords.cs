using GameInterface.Game.Characters;

namespace GameInterface.Game.Items.Weapons
{
    internal class Sword : IWeapon
    {
        public string Name { get; private set; }

        public bool Disposable { get; private set; }

        public int Cost { get; private set; }

        public int Attack { get; private set; }

        public ItemRank Rank { get; private set; }

        public Sword()
        {
            Rank = ItemRank.Ordinary;
            Attack = 0;
            Cost = 0;
            Name = string.Empty;
        }

        public Sword(ItemRank rank)
        {
            Rank = rank;
            Attack = 4;
            Cost = 90;
            switch (rank)
            {
                case ItemRank.Ordinary:
                    {
                        Name = "Перочинный ножик";
                    }
                    break;
                case ItemRank.Rare:
                    {
                        Attack *= 3;
                        Cost *= 4;
                        Name = "Ржавый меч";
                    }
                    break;
                case ItemRank.Epic:
                    {
                        Attack *= 6;
                        Cost *= 8;
                        Name = "Стильный меч";
                    }
                    break;
                case ItemRank.Legendary:
                    {
                        Attack *= 12;
                        Cost *= 14;
                        Name = "Брутальный двуручный меч";
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
