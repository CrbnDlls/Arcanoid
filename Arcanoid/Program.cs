using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Arkanoid
{
    internal class Program
    {
        static GameEngine gameEngine;
        static GameSettings gameSettings;
        static void Main(string[] args)
        {
            gameSettings = new GameSettings();
            UiController uiController = new UiController(gameSettings);
            uiController.OnLeftPressed += LeftClick;
            uiController.OnRightPressed += RightClick;
            uiController.OnEscapePressed += Exit;
            uiController.OnEnterPressed += RestartGame;

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

        static void RestartGame(object sender, EventArgs e)
        {
            gameEngine = new GameEngine(gameSettings);
            gameEngine.Run();
        }
    }
}
