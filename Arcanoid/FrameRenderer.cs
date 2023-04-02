﻿using Arcanoid.Objects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Arcanoid
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
            
           

            Console.ForegroundColor = frame.Ball.Color;
            
            Console.SetCursorPosition(frame.Ball.Left, frame.Ball.Top);
            
            Console.Write(frame.Ball.Symbol);

            Console.ResetColor();

            Console.SetCursorPosition(0, 0);
        }
    }
}