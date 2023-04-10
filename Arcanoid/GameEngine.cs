using Arkanoid.Objects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Arkanoid
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
            if (direction == Direction.Left)
            {
                if (frame.PlayerPlatform.Left > 0)
                {
                    frameRenderer.DestroyPlatform();
                    frame.PlayerPlatform.Left -= 1;
                    frameRenderer.DrawPlatform();
                }
            }
            else if (direction == Direction.Right && frame.PlayerPlatform.Left < gameSettings.ConsoleWidth - frame.PlayerPlatform.Length - 1)
            {
                frameRenderer.DestroyPlatform();
                frame.PlayerPlatform.Left += 1;
                frameRenderer.DrawPlatform();
            }
        }

        private void BallMove()
        {
            
            Ball ball = frame.Ball as Ball;

            CheckBlocksHit(ball);

            CheckPlatformHit(ball);

            CheckWallHit(ball);

            frameRenderer.DestroyBall();

            ball.Left += ball.XDirection;
            ball.Top += ball.YDirection;

            frameRenderer.DrawBall();
        }

        private void CheckWallHit(Ball ball)
        {
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

        private void CheckBlocksHit(Ball ball)
        {
            for (int i = 0; i < frame.Blocks.Count; i++)
            {
                if (frame.Blocks[i].Top != ball.Top + ball.YDirection)
                {
                    continue;
                }

                if (frame.Blocks[i].Left <= ball.Left + ball.XDirection &&
                    frame.Blocks[i].Left + frame.Blocks[i].Length >= ball.Left + ball.XDirection)
                {
                    ball.YDirection = -ball.YDirection;
                    
                    if (frame.Blocks[i].IsDestructable)
                    {
                        frameRenderer.DestroyBlock(frame.Blocks[i]);
                        frame.Blocks.RemoveAt(i);
                    }
                }

            }
        }
    }
}
