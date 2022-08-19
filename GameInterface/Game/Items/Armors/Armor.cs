using GameInterface.Game;
using GameInterface.Game.Characters;
using LordOfTheRings.Characters;
using LordOfTheRings.Items;

namespace LordOfTheRings.Armors
{
    public class Armor : IItem
    {
        public int Protection
        { get; private set; }
        public string Name { get; private set; }
        public bool Disposable { get; private set; }
        public int Cost { get; private set; }

        public Armor(ArmorType armorType)
        {
            switch (armorType)
            {
                case ArmorType.shield:
                    {
                        Protection = 13;
                        Name = "щит";
                        Cost = 150;
                    }
                    break;
                case ArmorType.helmet:
                    {
                        Protection = 10;
                        Name = "шлем";
                        Cost = 130;
                    }
                    break;
                case ArmorType.cuirass:
                    {
                        Protection = 15;
                        Name = "кираса";
                        Cost = 250;
                    }
                    break;
                case ArmorType.Empty:
                    {
                        Protection = 0;
                        Name = "Без брони";
                    }
                    break;
            }
            Disposable = false;
        }
        public static IItem CreateRandom()
        {
            Random random = new Random();
            var type = random.Next(0, 99);
            ArmorType armorType = (ArmorType)(type % 3);
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

    public enum ArmorType
    {
        shield = 0,//щит
        helmet = 1,//шлем
        cuirass = 2,//кираса
        Empty = 10
    }
}
