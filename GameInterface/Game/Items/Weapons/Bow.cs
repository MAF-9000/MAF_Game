using GameInterface.Game.Characters;

namespace GameInterface.Game.Items.Weapons
{
    internal class Bow:IWeapon
    {

        public string Name { get; private set; }

        public bool Disposable { get; private set; }

        public int Cost { get; private set; }

        public int Attack { get; private set; }

        public ItemRank Rank { get; private set; }

        public Bow()
        {
            Rank = ItemRank.Ordinary;
            Attack = 0;
            Cost = 0;
            Name = string.Empty;
        }

        public Bow(ItemRank rank)
        {
            Rank = rank;
            Attack = 3;
            Cost = 80;
            switch (rank)
            {
                case ItemRank.Ordinary:
                    {
                        Name = "Рогатка";
                    }
                    break;
                case ItemRank.Rare:
                    {
                        Attack *= 4;
                        Cost *= 4;
                        Name = "Короткий лук";
                    }
                    break;
                case ItemRank.Epic:
                    {
                        Attack *= 6;
                        Cost *= 6;
                        Name = "Копье";
                    }
                    break;
                case ItemRank.Legendary:
                    {
                        Attack *= 16;
                        Cost *= 16;
                        Name = "Арбалет";
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

