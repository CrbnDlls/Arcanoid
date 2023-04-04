﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Arcanoid
{
    internal class UiController
    {
        public EventHandler OnRightPressed;
        public EventHandler OnLeftPressed;
        public EventHandler OnRestart;
        public EventHandler OnExit;

        private readonly GameSettings gameSettings;
        public UiController(GameSettings gameSettings) 
        {
            this.gameSettings = gameSettings;
        }

        public void StartListen()
        {
            while (true)
            {
                if (Console.KeyAvailable)
                {
                    ConsoleKey key = Console.ReadKey(true).Key;

                    switch (key)
                    {
                        case GameSettings.MoveRight:
                            OnRightPressed?.Invoke(this, EventArgs.Empty);
                            break;
                        case GameSettings.MoveLeft:
                            OnLeftPressed?.Invoke(this, EventArgs.Empty);
                            break;
                        case GameSettings.Restart:
                            OnRestart?.Invoke(this, EventArgs.Empty);
                            break;
                        case GameSettings.Exit:
                            OnExit?.Invoke(this, EventArgs.Empty);
                            break;
                    }
                }
            }
        }
    }
}