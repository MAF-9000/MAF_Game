using GameInterface.Game;
using GameInterface.Game.Characters;
using LordOfTheRings.Armors;
using LordOfTheRings.Items;
using LordOfTheRings.Weapons;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LordOfTheRings.Characters
{
    public abstract class RaceHafling: Creature, IRace
    {
        // Поля класса----------------------------------
       
        protected string _raceName;
        protected Weapon _weapon;
        protected Armor _armor;
        protected int _experienceLimit;

        // Свойства-------------------------------------

        public string RaceName
        {
            get 
            {
                return _raceName;
            }
        }
        public override int Attack
        {
            get
            {
                return _attack * (9 + Level) / 10 + _weapon.Attack;
            }
        }
        public override int Protection
        {
            get
            {
                return _protection * (9 + Level) / 10 + _armor.Protection;
            }
        }

        public Weapon Weapon
        {
            get
            {
                return _weapon;
            }
            set
            {
                _weapon = value;
                Cnsl.WriteLine($"{Name} взял оружие {value.Name} в руку ");
            }
        }
        public Armor Armor
        {
            get
            {
                return _armor;
            }
            set
            {
                _armor = value;
                Cnsl.WriteLine($"{Name} надел  броню {value.Name} ");
            }
        }
        public Inventary Inventary
        {
            get; private set;
        }
        public int Experience
        {
            get; private set;
        }

        public int ExperienceLimit
        {
            get
            {
                return _experienceLimit*Level;
            }
           private set
            {
                _experienceLimit = value;
            }

        }

        // Конструктор-----------------------------------------
        public RaceHafling(string name = "Неизвестный", int level = 1)
            :base(name, level)
        {
            _weapon = new Weapon(WeaponType.Empty);
            _armor = new Armor(ArmorType.Empty);
            Inventary = new Inventary();
            Inventary.AddGold(50);
            ExperienceLimit = 100;
        }
        // Методы----------------------------------------------
       
        public void Heal(int healDamage)
        {
            if (IsAlive)
            {
                _damage = _damage - healDamage*2;
                if (_damage < 0)
                {
                    _damage = 0;
                }
                Cnsl.WriteLine($"{Name} восстановил {healDamage} HР.");
                Cnsl.WriteLine($"У {Name} осталось здоровья: {Health}.");
            }
            else
            {
                Cnsl.WriteLine($"{Name} мёртв. Он не может пить зелье.");
            }
        }
        public override void CharacterState()
        {
            Cnsl.WriteLine($"Раса - {RaceName}");
            base.CharacterState();
            Weapon.ItemState();
            Armor.ItemState();
        }
        public override void GetExperience(int randomExperience)
        {
            
            Experience = Experience + randomExperience/2;
            Cnsl.WriteLine($"{Name} получает {randomExperience}XP");
            Cnsl.WriteLine($"Текущий опыт {Name} = {Experience}XP/{ExperienceLimit}XP");
            if (Experience>=ExperienceLimit)
            {
                Experience = Experience - ExperienceLimit;
                LevelUp();
                Cnsl.WriteLine($"Текущий опыт {Name} = {Experience}XP/{ExperienceLimit}XP");
            }
        }
    }
   
}
