namespace LordOfTheRings.Characters
{
    public class Orc : Race
    {
        public static string raceName = "Орк";

        public Orc(string name = "Неизвестный", int level = 1)
            : base(name, level)
        {
            Random r = new Random();
            _attack = r.Next(20, 35);
            _protection = r.Next(0, 5);
            _health = r.Next(110, 130);
            _raceName = "Орк";
        }
      

    }
}

