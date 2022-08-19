using GameInterface.Game.Characters.Interfaces;

namespace LordOfTheRings.Characters
{
    internal class Monster : Creature
    {
        public Monster(string name = "Неизвестный", int level = 1)
            : base(name, level)
        {
            Random r = new Random();
            Attack = r.Next(30, 40);
            Protection = r.Next(0, 10);
            Health = r.Next(75, 100);
        }
    }
}



