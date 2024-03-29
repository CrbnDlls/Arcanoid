﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Arkanoid.Objects
{
    internal class Block : GameObject
    {
        public int QuantityHitsToDestroy { get; set; }
        public Block(int top, int left, bool isDestructable, ConsoleColor color, int length, int lines, char symbol)
            : base(top, left, isDestructable, color, length, lines, symbol)
        {
        }
    }
}
