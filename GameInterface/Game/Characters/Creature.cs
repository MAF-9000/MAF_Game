using GameInterface.Game;
using GameInterface.Game.Characters.Interfaces;

namespace LordOfTheRings.Characters
{
    public abstract class Creature:ICreature
    {
        //Поля класса______________________________

        protected int _attack;
        protected int _protection;
        protected int _health;
        protected int _damage;

        //Свойства_________________________________

        public string Name
        {
            get; protected set;
        }
        public int Level
        {
            get; protected set;
        }
        public virtual int Attack
        {
            get
            {
                return _attack * (9 + Level) / 10;
            }
            protected set { _attack = value; }
        }
        public virtual int Protection
        {
            get
            {
                return _protection * (9 + Level) / 10;
            }
            protected set { _protection = value; }
        }
        public int Health
        {
            get
            {
                return _health * (9 + Level) / 10 - _damage;
            }
            protected set { _health = value; }
        }
        public bool IsAlive
        {
            get
            {
                return Health > 0;

            }
        }
        // Конструктор-----------------------------------------
        public Creature(string name = "Неизвестный", int level = 1)
        {
            Level = level;
            _damage = 0;
            Name = name;

        }
        //Методы______________________________________________

        public virtual void GetDamage(int damage)
        {
            _damage = _damage + damage - Protection;
            Cnsl.WriteLine($"{Name} получает урон равный: {damage - Protection}");
            Cnsl.WriteLine($"У {Name} осталось здоровья: {Health}");
        }

        public void LevelUp()
        {
            Level = Level + 1;
            Cnsl.WriteLine($"{Name} получает уровень. Текущий уровень:{Level} ");
        }
       public virtual void GetExperience(int randomExperience)
        {

        }

        public bool Battle(ICreature enemy)
        {
            if (!IsAlive)
            {
                Cnsl.WriteLine($"{Name} мёртв. Он не может атаковать.");
                return false;
            }
            if (!enemy.IsAlive)
            {
                Cnsl.WriteLine($"{enemy.Name} мёртв. Бессмысленно атаковать, оставь труп в покое.");
                return true;
            }
            Cnsl.WriteLine($"Началась битва между {Name} и {enemy.Name} ");
            do
            {
                enemy.GetDamage(Attack);// Враг получает урон
                if (enemy.IsAlive)
                {
                    GetDamage(enemy.Attack);// Персонаж получает урон
                }

            }
            while (IsAlive && enemy.IsAlive);
            if (IsAlive)
            {
                Cnsl.WriteLine("В битве победил: " + Name + ".");
                Random random = new Random();
                int randomExperience = random.Next(30, 70)*enemy.Level;
                GetExperience(randomExperience);
            }
            else
            {
                Cnsl.WriteLine("В битве победил: " + enemy.Name + ".");
                enemy.LevelUp();
            }
            return IsAlive;
        }
        public virtual void CharacterState()
        {
            Cnsl.WriteLine($"Параметры существа \"{Name}\" : ");
            Cnsl.WriteLine($"Уровень - {Level}");
            Cnsl.WriteLine($"Здоровье - {Health}");
            Cnsl.WriteLine($"Атака - {Attack}");
            Cnsl.WriteLine($"Блокирование урона - {Protection}");
        }
    }
}
