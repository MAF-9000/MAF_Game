using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameInterface.Game
{
    public static class Cnsl
    {
        static GameI _gameI;
        public static void init(GameI gameI)
        {
            _gameI = gameI;
        }

        public static void WriteLine(string text)
        {
            _gameI.PrintLine(text);
        }

        public static void WriteAction(string text)
        {
            _gameI.PrintAction(text);
        }

        public static void ClearActions()
        {
            _gameI.ClearAction();
        }

        public static void Write(string text)
        {
            _gameI.Print(text);
        }
        public static async Task<string> ReadLine()
        {
            var text = "";
            text = await _gameI.Read();
            
            return text;
        }

        

    }
}
