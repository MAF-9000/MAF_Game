using LordOfTheRings.Items;

namespace GameInterface.Game.Items.Armors
{
    public interface IShield : IItem
    {
        public int Protection { get; }
    }
}
