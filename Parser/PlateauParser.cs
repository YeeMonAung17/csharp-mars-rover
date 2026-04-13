using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MarsRover
{
    public class PlateauParser
    {
        public static PlateauSize Parse (string input)
        {
            if (string.IsNullOrWhiteSpace(input))
            {
                throw new ArgumentException("Input cannot be null or empty");
            }


            var parts = input.Split(' ', StringSplitOptions.RemoveEmptyEntries);

            if (parts.Length != 2)
            {
                throw new ArgumentException("Input must contain exactly two parts: maxX and maxY");
            }

            if (!int.TryParse(parts[0], out int maxX) || !int.TryParse(parts[1], out int maxY))
            {
                throw new ArgumentException("Both maxX and maxY must be valid integers");
            }
            
            if (maxX < 0 || maxY < 0)
            {
                throw new ArgumentException("maxX and maxY must be non-negative integers");
            }

            return new PlateauSize(maxX, maxY);
        }
    }
}
