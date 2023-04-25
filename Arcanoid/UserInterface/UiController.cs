using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Arkanoid
{
    internal class UiController
    {
        public EventHandler OnRightPressed;
        public EventHandler OnLeftPressed;
        public EventHandler OnEnterPressed;
        public EventHandler OnEscapePressed;
        public EventHandler OnF2Pressed;
        public EventHandler OnF12Pressed;
        public EventHandler OnPPressed;

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
                        case ConsoleKey.RightArrow:
                            OnRightPressed?.Invoke(this, EventArgs.Empty);
                            break;
                        case ConsoleKey.LeftArrow:
                            OnLeftPressed?.Invoke(this, EventArgs.Empty);
                            break;
                        case ConsoleKey.Enter:
                            OnEnterPressed?.Invoke(this, EventArgs.Empty);
                            break;
                        case ConsoleKey.Escape:
                            OnEscapePressed?.Invoke(this, EventArgs.Empty);
                            break;
                        case ConsoleKey.F2:
                            OnF2Pressed?.Invoke(this, EventArgs.Empty);
                            break;
                        case ConsoleKey.F12:
                            OnF12Pressed?.Invoke(this, EventArgs.Empty);
                            break;
                        case ConsoleKey.P:
                            OnPPressed?.Invoke(this, EventArgs.Empty);
                            break;
                    }
                }
            }
        }
    }
}
