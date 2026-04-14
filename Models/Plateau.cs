using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MarsRover
{
    public class Plateau
    {
        public int MaxX { get; set; }
        public int MaxY { get; set; }



        public Plateau(int maxX, int maxY)
        {
            MaxX = maxX;
            MaxY = maxY;
        }


        public bool IsWithinBounds(Position position)
        {
            return position.X >= 0 && position.X <= MaxX 
                && position.Y >= 0 && position.Y <= MaxY;
        }


        public bool IsPositionEmpty(Position targetPosition,List<Rover> rovers)
        {
            return !rovers.Any(r => 
            r.Position.X == targetPosition.X 
            && r.Position.Y == targetPosition.Y);
        }
    }
}
