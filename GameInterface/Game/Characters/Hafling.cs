namespace LordOfTheRings.Characters
{
    public class Hafling : RaceHafling
    {
        /// <summary>
        /// Конструктор
        /// </summary>
        public Hafling(string name = "Неизвестный", int level = 1)
            :base(name,level)
        {
            Random r = new Random();
            _attack = r.Next(20, 30);
            _protection = r.Next(5, 15);
            _health = r.Next(90, 110);
            _raceName = "Гном";
        }
       
    }
}
