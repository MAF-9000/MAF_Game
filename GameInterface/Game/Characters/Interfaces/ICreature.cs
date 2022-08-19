using LordOfTheRings.Characters;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameInterface.Game.Characters.Interfaces
{
    public interface ICreature
    {
        public string Name { get; }
        public int Level { get; }
        public  int Attack { get; }
        public  int Protection { get; }
        public int Health { get; }
        public bool IsAlive { get; }
        public  void GetDamage(int damage);
        public void GetExperience(int randomExperience);
        public void LevelUp();
        public bool Battle(ICreature enemy);
        public void CharacterState();
    }
}
