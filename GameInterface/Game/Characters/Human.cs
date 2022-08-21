namespace LordOfTheRings.Characters
{
    public class Human:Race
    {
        /// <summary>
        /// Конструктор
        /// </summary>
        public Human(string name = "Неизвестный", int level = 1)
            :base(name,level)
        {
            Random r = new Random();
            _attack = r.Next(20, 30);
            _protection = r.Next(5, 15);
            _health = r.Next(90, 110);
            _raceName = "Человек";
        }

        public override void Heal(int healDamage)
        {
            base.Heal((int)(healDamage * 1.4));
        }

    }
}
