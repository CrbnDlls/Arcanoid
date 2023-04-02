using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Arcanoid
{
    internal class Program
    {
        static void Main(string[] args)
        {
            GameSettings gameSettings = new GameSettings();

            GameEngine gameEngine = new GameEngine(gameSettings);
            gameEngine.Run();
        }
    }
}
