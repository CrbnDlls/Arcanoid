using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Arcanoid
{
    internal class CollisionPoints
    {
        private readonly Point[] points;

        public CollisionPoints(int size) 
        {
            points = new Point[size];
        }

        public Point this[int index]
        { 
            get 
            { 
                return points[index]; 
            } 
        }

        public void Add(Point point) 
        {
            for (int i = 0; i < points.Length; i++)
            {
                if (points[i] == null)
                {
                    points[i] = point;
                }
            }
        }
    }
}
