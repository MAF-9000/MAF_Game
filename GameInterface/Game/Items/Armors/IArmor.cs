using LordOfTheRings.Items;

namespace GameInterface.Game.Items.Armors
{
    public interface IArmor : IItem
    {
        public int Protection { get; }
    }
}
