using Arkanoid;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Arcanoid.UserInterface
{
    public class Gui
    {
        public Status Status { get; set; }

        private GameEngine gameEngine;

        public void DisplayStartMenu()
        {
            Status = Status.StartMenuDisplayed;

            Console.Clear();
            Console.ResetColor();

            Console.SetCursorPosition(35, 6);
            Console.Write("A R C A N O I D");

            Console.SetCursorPosition(35, 8);
            Console.Write("Press \"F2\" to start new game");

            Console.SetCursorPosition(35, 10);
            Console.Write("Press \"F12\" to display help");

            Console.SetCursorPosition(35, 12);
            Console.Write("Press \"Escape\" to exit");

        }

        public void DisplayHelp()
        {
            Status = Status.HelpDisplayed;

            Console.Clear();
            Console.ResetColor();

            Console.SetCursorPosition(35, 6);
            Console.Write("A R C A N O I D");

            Console.SetCursorPosition(35, 8);
            Console.Write("Press \"F2\" to start new game");

            Console.SetCursorPosition(35, 10);
            Console.Write("Press \"F12\" to display help");

            Console.SetCursorPosition(35, 12);
            Console.Write("Press \"Escape\" to return to start menu");

        }

        public void Show(GuiAction guiAction)
        {
            switch (guiAction)
            {
                case GuiAction.DisplayStartMenu:
                    DisplayStartMenu();
                    break;
                case GuiAction.DisplayHelp:
                    DisplayHelp();
                    break;
                case GuiAction.StartGame:
                    StartGame();
                    break;
            }
        }
        public void SetGameEngine(GameEngine gameEngine) 
        {
            this.gameEngine = gameEngine;
        }

        private void StartGame()
        {
            Status = Status.GameRunning;
            gameEngine.Run();
        }
    }
}
