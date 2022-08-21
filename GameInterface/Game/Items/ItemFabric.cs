using GameInterface.Game.Items;
using GameInterface.Game.Items.Armors;
using GameInterface.Game.Items.Weapons;
using LordOfTheRings.Armors;
using LordOfTheRings.Potions;

namespace LordOfTheRings.Items
{
    public static class ItemFabric
    {
        public static IItem CreateRandomItem()
        {
            Random random = new Random();
            var type = random.Next(0, 99) % 8;
            var rank = (ItemRank)(random.Next(0, 99)%4);
            IItem item = null;
            switch(type)
            {
                case 0:
                    {
                        item = new Armor(rank);
                    }
                    break;
                case 1:
                    {
                        item = new Helmet(rank);
                    }
                    break;
                case 2:
                    {
                        item = new Shield(rank);
                    }
                    break;
                case 3:
                    {
                        item = new Bow(rank);
                    }
                    break;
                case 4:
                    {
                        item = new Clubs(rank);
                    }
                    break;
                case 5:
                    {
                        item = new Sword(rank);
                    }
                    break;
                case 6:
                    {
                        item = new Book();
                    }
                    break;
                case 7:
                    {
                        item = new HealingPotion(rank);
                    }
                    break;
            }     
            return item;
        }
       
    }
}
