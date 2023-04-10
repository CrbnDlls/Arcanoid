using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Arcanoid
{
    internal class Point
    {
        readonly int top;
        readonly int left;

        public int Top { get => top; }

        public int Left { get => left; }

        public Point(int top, int left)
        {
            this.top = top;
            this.left = left;
        }
    }
}
