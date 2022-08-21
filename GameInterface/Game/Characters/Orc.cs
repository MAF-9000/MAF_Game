namespace LordOfTheRings.Characters
{
    public class Orc : Race
    {// Получают и наносят на 20 % больше урона

        public Orc(string name = "Неизвестный", int level = 1)
            : base(name, level)
        {
            Random r = new Random();
            _attack = r.Next(20, 35);
            _protection = r.Next(0, 5);
            _health = r.Next(110, 130);
            _raceName = "Орк";
        }

        public override int Attack
        {
            get
            {
                return base.Attack * 14 / 10;
                  
            }
        }

        public override void GetDamage(int damage)
        {
            base.GetDamage((int)(damage*1.2));
        }

    }
}

