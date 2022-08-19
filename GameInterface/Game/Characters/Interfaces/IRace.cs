using GameInterface.Game.Characters.Interfaces;
using LordOfTheRings.Armors;
using LordOfTheRings.Items;
using LordOfTheRings.Weapons;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameInterface.Game.Characters
{
    public interface IRace:ICreature
    {
        public string RaceName { get; }
        public int Attack { get; }
        public int Protection { get; }
        public Weapon Weapon { get; set; }
        public Armor Armor { get; set; }
        public Inventary Inventary { get; }
        public int Experience { get; }
        public int ExperienceLimit { get; }
        public void Heal(int healDamage);
        public void CharacterState();
        public void GetExperience(int randomExperience);
    }
}
