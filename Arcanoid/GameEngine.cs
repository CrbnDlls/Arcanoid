using Arcanoid.Objects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Arcanoid
{
    internal class GameEngine
    {
        private Frame frame;
        private readonly GameSettings gameSettings;
        private bool isRunning;
        public GameEngine(GameSettings gameSettings) 
        {
            this.gameSettings = gameSettings;

            frame = new Frame(gameSettings);

            isRunning = true;
        }

        public void Run()
        {
            FrameRenderer frameRenderer = new FrameRenderer(frame);
            frameRenderer.InitialDraw();
            while(isRunning)
            {
                Thread.Sleep(100);
            }
        }
    }
}
