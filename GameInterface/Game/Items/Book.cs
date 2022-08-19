using GameInterface.Game;
using GameInterface.Game.Characters;
using LordOfTheRings.Characters;

namespace LordOfTheRings.Items
{

    public class Book : IItem
    {
        private int randomExperience;

        public Book()
        {
            Name = "Книга знаний";
            Disposable = true;
            Cost = 500;
            Random random = new Random();
            randomExperience = random.Next(100, 300);

        }

        public string Name { get; private set;}

        public bool Disposable { get; private set; }

        public int Cost { get; private set; }

        public void Execute(IRace person)
        {
            Console.WriteLine($"{person.Name} прочел книгу {Name}.");

            person.GetExperience(randomExperience);
        }

        public string ItemInfo()
        {
            return $"{Name} повышает опыт({randomExperience}xp), цена({Cost})";
        }

        public void ItemState()
        {
            Cnsl.WriteLine($"{Name} повышает опыт на {randomExperience}, цена предмета - {Cost}");
        }
    }
}
