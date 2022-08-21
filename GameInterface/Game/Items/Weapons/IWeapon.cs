using LordOfTheRings.Items;

namespace GameInterface.Game.Items.Weapons
{
    public interface IWeapon: IItem
    {
        public int Attack { get; }
    }
}
