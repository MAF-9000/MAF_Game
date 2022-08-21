using GameInterface.Game.Characters;
using LordOfTheRings.Characters;

namespace LordOfTheRings
{
    public static class Game
    {
        public static void Start()
        {
            //form.Print("Создание персонажа ");
            //Race hero = CreatePerson();
            //form.Print($"Создан персонаж: {hero.Name} . Раса: {hero.RaceName}");
            //hero.CharacterState();
            //Tract tract = new Tract();
            //tract.GoToTract(hero);
        }

        public static IRace CreatePerson()
        {
            string comand = string.Empty;
            do
            {
                Console.WriteLine("Выберите расу ");
                Console.WriteLine("1 - Человек");
                Console.WriteLine("2 - Орк");
                Console.WriteLine("3 - Эльф");

                comand = Console.ReadLine();
            }
            while (comand != "1" && comand != "2" && comand != "3");
            Console.WriteLine("Введите имя персонажа");
            string Name = Console.ReadLine();
            Race hero = null;
            
            switch (comand)
            {
                case "1":
                    {
                        hero = new Human(Name);
                    }
                    break;
                case "2":
                    {
                        hero = new Orc(Name);

                    }
                    break;
                case "3":
                    {
                        hero = new Elf(Name);
                    }
                    break;

            }
            return hero;
        }
    }
}

