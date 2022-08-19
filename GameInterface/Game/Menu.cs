namespace LordOfTheRings
{
    internal class Menu
    {
        public static void ShowMenu()
        {
            string comand = string.Empty;
            do
            {
                Console.Clear();
                Console.WriteLine("1 - Новая игра ");
                Console.WriteLine("2 - Загрузить игру");
                Console.WriteLine("3 - Выход");

                comand = Console.ReadLine();
                switch (comand)
                {
                    case "1":
                        {

                        }
                        break;
                    case "2":
                        {


                        }
                        break;


                }
            }
            while (comand != "3");
        }
        public static void ABV()
        {
        }

    }
}
