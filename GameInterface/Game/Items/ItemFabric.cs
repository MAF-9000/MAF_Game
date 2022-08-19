using LordOfTheRings.Armors;
using LordOfTheRings.Potions;
using LordOfTheRings.Weapons;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LordOfTheRings.Items
{
    public static class ItemFabric
    {
        public static IItem CreateRandomItem()
        {
            Random random = new Random();
            var type = random.Next(0, 99);
            IItem item = null;
            if (type % 4 == 0)
            {
                item = HealingPotion.CreateRandom();
            }
            else if (type % 4 == 1)
            {
                item = Armor.CreateRandom();
            }
            else if (type % 4 == 2)
            {
                item = Weapon.CreateRandom();
            }
            else
            {
                item = new Book();
            }
            return item;
        }
       
    }
}
