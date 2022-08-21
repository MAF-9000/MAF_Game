using GameInterface.Game;

namespace LordOfTheRings.Characters
{
    public class Elf : Race
    {
        private int _agility;//перевод ловкость


        public int Agility
        {
            get
            {
                return _agility * (9 + Level) / 10;
            }
        }


        public Elf(string name = "Неизвестный", int level = 1)
            : base(name, level)
        {
            Random r = new Random();
            _attack = r.Next(20, 30);
            _protection = r.Next(5, 10);
            _health = r.Next(90, 100);
            _agility = r.Next(5, 10);
            _raceName = "Эльф";
        }

        public override void GetDamage(int damage)
        {
            Random r = new Random();
            int chance = r.Next(0, 100);
            if (_agility > chance)// Персонаж увернулся
            {
                Cnsl.WriteLine($"{Name} увернулся от урона");
            }
            else
            {
                _damage = _damage + damage - Protection;
                Cnsl.WriteLine($"{Name} получает урон равный: {damage - Protection}");

            }
            Cnsl.WriteLine($"У {Name} осталось здоровья: {Health}");
        }
        public override void CharacterState()
        {
            base.CharacterState();
            Cnsl.WriteLine($"Ловкость - {Agility}");
        }
       
    }
}

