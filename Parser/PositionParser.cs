using MarsRover.ENUM;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MarsRover
{
    public class PositionParser
    {
        public static Position Parse(string input)
        {

            if (string.IsNullOrWhiteSpace(input))
            {
                throw new ArgumentException("Input cannot be null or empty");
            }


            var parts = input.Split(' ',StringSplitOptions.RemoveEmptyEntries);

            if (parts.Length != 3)
            {
                throw new ArgumentException("Input must consist of three parts: X Y Direction");
            }


            if(!int.TryParse(parts[0], out int x) || !int.TryParse(parts[1], out int y))
            {
                throw new ArgumentException("X and Y coordinates must be integers");
            }

            if (x < 0 || y < 0)
            {
                throw new ArgumentException("X and Y coordinates must be non-negative integers");
            }


            Direction direction = parts[2].ToUpper() switch
            {
                "N" => Direction.North,
                "E" => Direction.East,
                "S" => Direction.South,
                "W" => Direction.West,
                _ => throw new ArgumentException("Invalid direction")
            };





            return new Position(x, y, direction);
        }
    }
}
