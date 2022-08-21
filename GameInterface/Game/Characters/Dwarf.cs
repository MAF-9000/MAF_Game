using LordOfTheRings.Characters;

namespace GameInterface.Game.Characters
{
    internal class Dwarf:Race
    {
        public Dwarf(string name = "Неизвестный", int level = 1)
           : base(name, level)
        {
            Random r = new Random();
            _attack = r.Next(15, 25);
            _protection = r.Next(2, 7);
            _health = r.Next(100, 110);
            _raceName = "Гном";
        }

        public override int Protection
        {
            get
            {
                return _protection * (9 + Level) / 10 + (int)(_armor.Protection*1.4);
            }
        }
    }
}
