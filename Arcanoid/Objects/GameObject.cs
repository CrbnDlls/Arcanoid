﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Arcanoid.Objects
{
    internal abstract class GameObject
    {
        int top;
        int left;
        bool isDestructable;
        ConsoleColor color;
        int length;
        int lines;
        char symbol;

        public int Top { get => top; }
        public int Left { get => left; }
        public bool IsDestructable { get => isDestructable; }
        public ConsoleColor Color { get => color; }
        public int Length { get => length; }
        public int Lines { get => lines; }
        public char Symbol { get => symbol; }

        public GameObject(int top, int left, bool isDestructable, ConsoleColor color, int length, int lines, char symbol)
        {
            this.top = top;
            this.left = left;
            this.isDestructable = isDestructable;
            this.color = color;
            this.length = length;
            this.lines = lines;
            this.symbol = symbol;
        }
    }
}
