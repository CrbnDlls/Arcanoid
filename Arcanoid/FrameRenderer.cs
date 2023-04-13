using Arkanoid.Objects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Arkanoid
{
    internal class FrameRenderer
    {
        private readonly Frame frame;

        private readonly object key;

        public FrameRenderer(Frame frame)
        {
            this.frame = frame;
            key = new object();
        }

        public void InitialDraw()
        {
            Console.Clear();

            DrawBlocks();

            DrawPlatform();

            DrawBall();

            DrawTotalScore();

            DrawTemporaryScore();

            DrawPlayerLives();
           
            Console.ResetColor();

            Console.SetCursorPosition(0, 0);
        }

        private void DrawBlocks()
        {
            foreach (var block in frame.Blocks)
            {
                StringBuilder stringBuilder = new StringBuilder();

                Console.ForegroundColor = block.Color;

                Console.SetCursorPosition(block.Left, block.Top);

                for (int i = 0; i < block.Length; i++)
                {
                    stringBuilder.Append(block.Symbol);
                }

                Console.Write(stringBuilder.ToString());
            }
        }

        public void DestroyBlock(GameObject block)
        {
            StringBuilder stringBuilder = new StringBuilder();
            
            for (int i = 0; i < block.Length; i++)
            {
                stringBuilder.Append(' ');
            }
            
            lock (key)
            {
                Console.SetCursorPosition(block.Left, block.Top);

                Console.Write(stringBuilder.ToString());
            }
            
            Console.SetCursorPosition(0, 0);
        }

        public void DestroyBall()
        {
            lock (key)
            {
                Console.SetCursorPosition(frame.Ball.Left, frame.Ball.Top);

                Console.Write(' ');
            }
        }

        public void DrawBall()
        {
            lock (key)
            {
                Console.ForegroundColor = frame.Ball.Color;

                Console.SetCursorPosition(frame.Ball.Left, frame.Ball.Top);

                Console.Write(frame.Ball.Symbol);
            }
        }

        public void DestroyPlatform()
        {
            for (int j = 0; j < frame.PlayerPlatform.Lines; j++)
            {
                
                StringBuilder sb = new StringBuilder();
                for (int i = 0; i < frame.PlayerPlatform.Length; i++)
                {
                    sb.Append(' ');
                }

                lock (key)
                {
                    Console.SetCursorPosition(frame.PlayerPlatform.Left, frame.PlayerPlatform.Top + j);

                    Console.Write(sb.ToString());
                }
            }
        }

        public void DrawPlatform()
        {
            

            for (int j = 0; j < frame.PlayerPlatform.Lines; j++)
            {
                
                StringBuilder sb = new StringBuilder();
                for (int i = 0; i < frame.PlayerPlatform.Length; i++)
                {
                    sb.Append(frame.PlayerPlatform.Symbol);
                }
                
                lock (key)
                {
                    Console.ForegroundColor = frame.PlayerPlatform.Color;

                    Console.SetCursorPosition(frame.PlayerPlatform.Left, frame.PlayerPlatform.Top + j);

                    Console.Write(sb.ToString());
                }
            }
        }

        public void DrawTemporaryScore()
        {
            lock (key)
            {
                Console.SetCursorPosition(45, 22);

                Console.ForegroundColor = ConsoleColor.DarkMagenta;

                Console.Write($@"{(frame.TemporaryScore.ToString().Length == 1 ? " " +  frame.TemporaryScore :
                                                                                 frame.TemporaryScore.ToString())}");
            }
        }

        public void DrawTotalScore()
        {
            lock (key)
            {
                Console.SetCursorPosition(2, 22);

                Console.ForegroundColor = ConsoleColor.DarkMagenta;

                Console.Write($"Total score: {frame.TotalScore}");
            }
        }

        public void DrawGameOver()
        {
            lock (key)
            {
                Console.SetCursorPosition(33, 12);

                Console.ForegroundColor = ConsoleColor.Red;

                Console.Write("Game OVER !!!");
            }
        }

        public void DrawPlayerLives()
        {
            lock (key)
            {
                Console.SetCursorPosition(20, 22);

                Console.ForegroundColor = ConsoleColor.DarkMagenta;

                Console.Write($"Lives: {frame.PlayerLives}");
            }
        }

        public void DrawPlayTime()
        {
            lock (key)
            {
                Console.SetCursorPosition(30, 22);

                Console.ForegroundColor = ConsoleColor.DarkMagenta;

                Console.Write($"Time: {frame.PlayTime.TotalSeconds:N0} sec.");
            }
        }
    }
}
