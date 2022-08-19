using GameInterface.Game;
using GameInterface.Game.Characters;
using LordOfTheRings.Characters;
using LordOfTheRings.Items;

namespace LordOfTheRings.Weapons
{
    public class Weapon : IItem
    {
        public int Attack { get; private set; }

        public WeaponType WeaponType { get; private set; }

        public string Name { get; private set; }

        public bool Disposable { get; private set; }

        public int Cost { get; private set; }

        public Weapon(WeaponType weapon)
        {
            switch (weapon)
            {
                case WeaponType.Sword:
                    {
                        Attack = 12;
                        Name = "Меч";
                        Cost = 150;
                    }
                    break;
                case WeaponType.Bow:
                    {
                        Attack = 8;
                        Name = "Лук";
                        Cost = 100;
                    }
                    break;
                case WeaponType.Axe:
                    {
                        Attack = 18;
                        Name = "Топор";
                        Cost = 300;
                    }
                    break;
                case WeaponType.Empty:
                    {
                        Attack = 0;
                        Name = "Без оружия";
                    }
                    break;
                case WeaponType.Knife:
                    {
                        Attack = 5;
                        Name = "Кинжал";
                        Cost = 50;
                    }
                    break;
                case WeaponType.Axe2:
                    {
                        Attack = 23;
                        Name = "Секира";
                        Cost = 500;
                    }
                    break;
                case WeaponType.Mace:
                    {
                        Attack = 20;
                        Name = "Булава";
                        Cost = 450;
                    }
                    break;
                case WeaponType.Flail:
                    {
                        Attack = 14;
                        Name = "Кистень";
                        Cost = 250;
                    }
                    break;
                case WeaponType.Hammer:
                    {
                        Attack = 25;
                        Name = "Молот";
                        Cost = 600;
                    }
                    break;
            }

            Disposable = false;

        }
        public static IItem CreateRandom()
        {
            Random random = new Random();
            var type = random.Next(0, 99);
            WeaponType weaponType = (WeaponType)(type % 8);
            return new Weapon(weaponType);
        }
        public void Execute(IRace person)
        {
            person.Weapon = this;
        }
        public string ItemInfo()
        {
            return $"{Name}, атака({Attack}), цена({Cost})";
        }
        public void ItemState()
        {
            Cnsl.WriteLine($"Оружие: {Name} с уроном - {Attack}, цена предмета - {Cost}");
        }
    }
    public enum WeaponType
    {
        Sword = 0,
        Bow = 1,
        Axe = 2,
        Knife = 3,
        Axe2 = 4,
        Mace = 5,
        Flail = 6,
        Hammer = 7,
        Empty = 10

    }
}
