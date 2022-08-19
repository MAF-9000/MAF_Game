using GameInterface.Game;
using LordOfTheRings;
using LordOfTheRings.Characters;
using LordOfTheRings.Locations;

namespace GameInterface
{
    internal static class Program
    {
        /// <summary>
        ///  The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            // To customize application configuration such as set high DPI settings or default font,
            // see https://aka.ms/applicationconfiguration.
            ApplicationConfiguration.Initialize();

            Application.Run(new GameI());
        }
    }
}