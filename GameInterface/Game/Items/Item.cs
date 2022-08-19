using GameInterface.Game.Characters;
using LordOfTheRings.Armors;
using LordOfTheRings.Characters;
using LordOfTheRings.Potions;
using LordOfTheRings.Weapons;

namespace LordOfTheRings.Items
{
    public interface IItem
    {
        public string Name
        { get;  }
        public bool Disposable
        { get;  }
        public int Cost
        { get; }

       
        public void Execute(IRace person);
        public void ItemState();
        public string ItemInfo();
        


    }
	
}
