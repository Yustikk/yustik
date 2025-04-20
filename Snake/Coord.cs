using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Snake
{
    internal class Coord
    {
        public int x, y;
        public int X { get { return x; } }
        public int Y { get { return y; } }
        public Coord(int x, int y)
        {
            this.x = x;
            this.y = y;
        }
        public override bool Equals(object? obj)
        {
            if ((obj == null) || !GetType().Equals(obj.GetType()))   //????????????????????
                return false;

            Coord other = (Coord)obj;
            return x == other.x && y == other.y;
        }

        public void ApplyMovement(Direction direction)
        {
            switch (direction)
            {
                case (Direction.left):
                    { x--; break;}
                case (Direction.right):
                    { x++; break; }
                case (Direction.up): 
                    { y--; break; }
                case (Direction.down): 
                    { y++; break; }
            }
        }
    }
}
