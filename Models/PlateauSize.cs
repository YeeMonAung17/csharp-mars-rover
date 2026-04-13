using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MarsRover
{
    internal class PlateauSize
    {
        public int MaxX { get; set; }
        public int MaxY { get; set; }

        public PlateauSize(int maxX, int maxY)
        {
            MaxX = maxX;
            MaxY = maxY;
        }

        public bool IsWithinBounds(Position position)
        {
            return position.X >= 0 && position.X <= MaxX && position.Y >= 0 && position.Y <= MaxY;
        }
    }
}
