using GameInterface.Game;
using GameInterface.Game.Characters;
using GameInterface.Game.Items;
using LordOfTheRings.Items;

namespace LordOfTheRings.Potions
{
    public class HealingPotion : IItem
    {

        public int Heal
        {
            get; private set;
        }

        public string Name { get; private set; }

        public bool Disposable { get; private set; }

        public int Cost { get; private set; }

        public ItemRank Rank { get; private set; }

        public HealingPotion(ItemRank potionType)
        {
            Name = "зелье исцеления";
            switch (potionType)
            {
                case ItemRank.Ordinary:
                    {
                        Heal = 10;
                        Name = "Обычное " + Name;
                        Cost = 25;
                    }
                    break;
                case ItemRank.Rare:
                    {
                        Heal = 25;
                        Name = "Редкое " + Name;
                        Cost = 50;
                    }
                    break;
                case ItemRank.Epic:
                    {
                        Heal = 50;
                        Name = "Эпическое " + Name;
                        Cost = 100;
                    }
                    break;
                case ItemRank.Legendary:
                    {
                        Heal = 100;
                        Name = "Легендарное " + Name;
                        Cost = 200;
                    }
                    break;
            }
            Disposable = true;
        }
        public void Execute(IRace person)
        {
            Cnsl.WriteLine($"{person.Name} выпил {Name}");
            person.Heal(Heal);
        }

        public void ItemState()
        {
            Cnsl.WriteLine($"Зелье: {Name} с восстановлением - {Heal}, цена предмета - {Cost}");
        }
        public string ItemInfo()
        {
            return $"{Name}, восстановление({Heal}), цена({Cost})";
        }
        public static IItem CreateRandom()
        {
            Random random = new Random();
            var type = random.Next(0, 99);
            ItemRank potionType = (ItemRank)(type % 4);
            return new HealingPotion(potionType);
        }
    }
    public enum HealingPotionType
    {
        /// <summary>
        /// Обычное
        /// </summary>
        Ordinary = 0,
        /// <summary>
        /// Редкое
        /// </summary>
        Rare = 1,
        /// <summary>
        /// Эпическое
        /// </summary>
        Epic = 2,
        /// <summary>
        /// Легендарное 
        /// </summary>
        Legendary = 3
    }
}
