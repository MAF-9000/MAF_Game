using GameInterface.Game.Characters.Interfaces;
using GameInterface.Game.Items.Armors;
using GameInterface.Game.Items.Weapons;
using LordOfTheRings.Items;

namespace GameInterface.Game.Characters
{
    public interface IRace:ICreature
    {
        public string RaceName { get; }
        public int Attack { get; }
        public int Protection { get; }
        public IWeapon Weapon { get; set; }
        public IArmor Armor { get; set; }
        public IShield Shield { get; set; }
        public IHelmet Helmet { get; set; }
        public Inventary Inventary { get; }
        public int Experience { get; }
        public int ExperienceLimit { get; }
        public void Heal(int healDamage);
        public void CharacterState();
        public void GetExperience(int randomExperience);
    }
}
