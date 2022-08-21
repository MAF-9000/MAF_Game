using LordOfTheRings.Items;

namespace GameInterface.Game.Items.Armors
{
    public interface IHelmet : IItem
    {
        public int Protection { get; }
    }
}
