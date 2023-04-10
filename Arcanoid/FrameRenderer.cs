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

        public FrameRenderer(Frame frame)
        {
            this.frame = frame;
        }

        public void InitialDraw()
        {
            DrawBlocks();

            DrawPlatform();

            DrawBall();
           
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

            Console.SetCursorPosition(block.Left, block.Top);

            for (int i = 0; i < block.Length; i++)
            {
                stringBuilder.Append(' ');
            }

            Console.Write(stringBuilder.ToString());

            Console.SetCursorPosition(0, 0);
        }

        public void DestroyBall()
        {
            Console.SetCursorPosition(frame.Ball.Left, frame.Ball.Top);

            Console.Write(' ');
        }

        public void DrawBall()
        {
            Console.ForegroundColor = frame.Ball.Color;

            Console.SetCursorPosition(frame.Ball.Left, frame.Ball.Top);

            Console.Write(frame.Ball.Symbol);
        }

        public void DestroyPlatform()
        {
            for (int j = 0; j < frame.PlayerPlatform.Lines; j++)
            {
                Console.SetCursorPosition(frame.PlayerPlatform.Left, frame.PlayerPlatform.Top + j);
                StringBuilder sb = new StringBuilder();
                for (int i = 0; i < frame.PlayerPlatform.Length; i++)
                {
                    sb.Append(' ');
                }
                Console.Write(sb.ToString());
            }
        }

        public void DrawPlatform()
        {
            Console.ForegroundColor = frame.PlayerPlatform.Color;

            for (int j = 0; j < frame.PlayerPlatform.Lines; j++)
            {
                Console.SetCursorPosition(frame.PlayerPlatform.Left, frame.PlayerPlatform.Top + j);
                StringBuilder sb = new StringBuilder();
                for (int i = 0; i < frame.PlayerPlatform.Length; i++)
                {
                    sb.Append(frame.PlayerPlatform.Symbol);
                }
                Console.Write(sb.ToString());
            }
        }
    }
}
