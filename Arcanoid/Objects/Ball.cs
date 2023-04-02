using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Arcanoid.Objects
{
    internal class Ball : GameObject
    {
        public Ball(int top, int left, bool isDestructable, ConsoleColor color, int length, int lines, char symbol)
            : base(top, left, isDestructable, color, length, lines, symbol)
        {

        }
    }
}
