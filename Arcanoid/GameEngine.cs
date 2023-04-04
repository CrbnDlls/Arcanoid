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
        private readonly FrameRenderer frameRenderer;
        private bool isRunning;
        public GameEngine(GameSettings gameSettings) 
        {
            this.gameSettings = gameSettings;

            frame = new Frame(gameSettings);

            this.frameRenderer = new FrameRenderer(frame);

            isRunning = true;
        }

        public void Run()
        {
            
            frameRenderer.InitialDraw();
            while(isRunning)
            {
                BallMove();
                Thread.Sleep(100);
            }
        }

        public void Exit() 
        {
            isRunning = false;
        }

        public void PlatformMove(Direction direction)
        {
            if(direction == Direction.Left)
            {
                if (frame.PlayerPlatform.Left > 0)
                {
                    frameRenderer.DestroyPlatform();
                    frame.PlayerPlatform.Left -= 1;
                    frameRenderer.DrawPlatform();
                }
            }
            else if(direction == Direction.Right) 
            {
                if (frame.PlayerPlatform.Left < gameSettings.ConsoleWidth - frame.PlayerPlatform.Length - 1)
                {
                    frameRenderer.DestroyPlatform();
                    frame.PlayerPlatform.Left += 1;
                    frameRenderer.DrawPlatform();
                }
            }
        }

        private void BallMove()
        {
            
            Ball ball = frame.Ball as Ball;
            
            if (ball.Top == 0 && ball.YDirection < 0)
            {
                ball.YDirection = -ball.YDirection;
            }
            else if (ball.Left == 0 && ball.XDirection < 0)
            {
                ball.XDirection = -ball.XDirection;
            }
            else if (ball.Left == gameSettings.ConsoleWidth - 1 && ball.XDirection > 0)
            {
                ball.XDirection = -ball.XDirection;
            }
            else if (ball.Top == gameSettings.ConsoleHeight - 1 && ball.YDirection > 0)
            {
                ball.YDirection = -ball.YDirection;
            }

            CheckPlatformHit(ball);

            frameRenderer.DestroyBall();

            ball.Left += ball.XDirection;
            ball.Top += ball.YDirection;

            frameRenderer.DrawBall();
        }

        private void CheckPlatformHit(Ball ball) 
        {
            if (ball.Top == gameSettings.PlayerPlatformStartTop - 1 &&
                ball.YDirection > 0 &&
                ball.Left >= frame.PlayerPlatform.Left &&
                ball.Left <= frame.PlayerPlatform.Left + frame.PlayerPlatform.Length)
            {
                ball.YDirection = -ball.YDirection;
            }
        }
    }
}
