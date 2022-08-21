using GameInterface.Game.Characters;
using GameInterface.Game.Items;

namespace LordOfTheRings.Items
{
    public interface IItem
    {
        public string Name
        { get; }
        public bool Disposable
        { get; }
        public int Cost
        { get; }
        public ItemRank Rank {get;}

        public void Execute(IRace person);
        public void ItemState();
        public string ItemInfo();
        


    }
	
}
