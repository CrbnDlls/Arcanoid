using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Arcanoid
{
    internal class Program
    {
        static GameEngine gameEngine;
        static void Main(string[] args)
        {
            GameSettings gameSettings = new GameSettings();
            UiController uiController = new UiController(gameSettings);
            uiController.OnLeftPressed += LeftClick;
            uiController.OnRightPressed += RightClick;
            uiController.OnExit += Exit;

            Task uiThread = new Task(uiController.StartListen);
            uiThread.Start();

            gameEngine = new GameEngine(gameSettings);
            gameEngine.Run();
        }

        static void Exit(object sender, EventArgs e)
        {
            gameEngine.Exit();
        }

        static void RightClick(object sender, EventArgs e)
        {
           gameEngine.PlatformMove(Direction.Right);
        }

        static void LeftClick(object sender, EventArgs e)
        {
            gameEngine.PlatformMove(Direction.Left);
        }
    }
}
