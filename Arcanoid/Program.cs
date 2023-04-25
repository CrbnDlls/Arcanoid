using Arcanoid.UserInterface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Arkanoid
{
    internal class Program
    {
        static GameEngine gameEngine;
        static GameSettings gameSettings;
        static Gui gui;
        static GuiAction guiAction;
        static bool gameRunning;
        static AutoResetEvent autoResetEvent;
        static void Main(string[] args)
        {
            gameSettings = new GameSettings();
            UiController uiController = new UiController(gameSettings);
            uiController.OnLeftPressed += LeftClick;
            uiController.OnRightPressed += RightClick;
            uiController.OnEscapePressed += GoBackOrExit;
            uiController.OnEnterPressed += RestartGame;
            uiController.OnF2Pressed += RestartGame;
            uiController.OnF12Pressed += DisplayHelp;
            uiController.OnPPressed += Pause;

            Task uiThread = new Task(uiController.StartListen);
            uiThread.Start();

            autoResetEvent = new AutoResetEvent(false);

            gui = new Gui();
            guiAction = GuiAction.DisplayStartMenu;
            gameRunning = true;

            do
            {
                if (gameRunning)
                {
                    gui.Show(guiAction);
                    autoResetEvent.WaitOne();
                }

            } while (gameRunning);
        }

        static void GoBackOrExit(object sender, EventArgs e)
        {
            switch (gui.Status)
            {
                case Status.StartMenuDisplayed:
                    gameRunning = false;
                    break;
                case Status.HelpDisplayed:
                    guiAction = GuiAction.DisplayStartMenu;
                    break;
                case Status.GameRunning:
                    gameEngine.Exit();
                    guiAction = GuiAction.DisplayStartMenu;
                    break;
            }
            autoResetEvent.Set();
        }

        static void RightClick(object sender, EventArgs e)
        {
           gameEngine.PlatformMove(Direction.Right);
        }

        static void LeftClick(object sender, EventArgs e)
        {
            gameEngine.PlatformMove(Direction.Left);
        }

        static void Pause(object sender, EventArgs e)
        {
            gameEngine.Pause();
        }

        static void RestartGame(object sender, EventArgs e)
        {
            gameEngine = new GameEngine(gameSettings);
            gui.SetGameEngine(gameEngine);
            guiAction = GuiAction.StartGame;
            autoResetEvent.Set();
        }

        static void DisplayHelp(object sender, EventArgs e)
        {
            guiAction = GuiAction.DisplayHelp;
            autoResetEvent.Set();
        }
    }
}
