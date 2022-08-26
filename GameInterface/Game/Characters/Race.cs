using GameInterface.Game;
using GameInterface.Game.Characters;
using GameInterface.Game.Items.Armors;
using GameInterface.Game.Items.Weapons;
using LordOfTheRings.Armors;
using LordOfTheRings.Items;

namespace LordOfTheRings.Characters
{
    public abstract class Race:Creature, IRace
    {
        // Поля класса----------------------------------
       
        protected string _raceName;
        protected IWeapon _weapon;
        protected IArmor _armor;
        protected IHelmet _helmet;
        protected IShield _shield;
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

        public IWeapon Weapon
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

        public IArmor Armor {
            get
            {
                return _armor;
            }
            set
            {
                _armor = value;
                Cnsl.WriteLine($"{Name} надел {value.Name} ");
            }
        }
        public IShield Shield {
            get
            {
                return _shield;
            }
            set
            {
                _shield = value;
                Cnsl.WriteLine($"{Name} взял {value.Name} ");
            }
        }
        public IHelmet Helmet {
            get
            {
                return _helmet;
            }
            set
            {
                _helmet = value;
                Cnsl.WriteLine($"{Name} надел {value.Name} ");
            }
        }

        // Конструктор-----------------------------------------
        public Race(string name = "Неизвестный", int level = 1)
            :base(name, level)
        {
            _weapon = new Sword();
            _armor = new Armor();
            _shield = new Shield();
            _helmet = new Helmet();
            Inventary = new Inventary();
            Inventary.AddGold(50);
            ExperienceLimit = 100;
        }
        // Методы----------------------------------------------
       
        public virtual void Heal(int healDamage)
        {
            if (IsAlive)
            {
                _damage = _damage - healDamage;
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
            
            Experience = Experience + randomExperience;
            Cnsl.WriteLine($"{Name} получает {randomExperience}XP");
            Cnsl.WriteLine($"Текущий опыт {Name} = {Experience}XP/{ExperienceLimit}XP");
            if (Experience>=ExperienceLimit)
            {
                Experience = Experience - ExperienceLimit;
                LevelUp();
                Cnsl.WriteLine($"Текущий опыт {Name} = {Experience}XP/{ExperienceLimit}XP");
            }
        }
        //можно сделать сущность временного эффекта, который живет 1-Н боев и оказывает влияние на игрока. Например - эффект повышенного на 20проц урона на 3 боя
        // 1 бой проходит и счетчик уменьшается до 2х
    }
    public enum RaceType
    {
        Human,
        Elf,
        Orc,
        Hafling

    }
}
