using MarsRover.ENUM;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata.Ecma335;
using System.Text;
using System.Threading.Tasks;

namespace MarsRover
{
    public class Rover
    {

        public Position Position { get; private set; }

        public Rover(Position initialPosition)
        {
            Position = initialPosition ?? throw new ArgumentNullException(nameof(initialPosition), "Initial position cannot be null.");
        }


        public Position GetNextPosition()
        {
                       return Position.Direction switch
            {
                Direction.North => new Position(Position.X, Position.Y + 1, Position.Direction),
                Direction.East => new Position(Position.X + 1, Position.Y, Position.Direction),
                Direction.South => new Position(Position.X, Position.Y - 1, Position.Direction),
                Direction.West => new Position(Position.X - 1, Position.Y, Position.Direction),
                _ => throw new InvalidOperationException("Invalid direction")
            };
        }


        public void GoStraight()
        {
            Position = GetNextPosition();
        }

        public void RotateLeft()
        {
            Direction newDirection = Position.Direction switch
            {
                Direction.North => Direction.West,
                Direction.West => Direction.South,
                Direction.South => Direction.East,
                Direction.East => Direction.North,
                _ => throw new InvalidOperationException("Invalid direction")
            };

            Position = new Position(Position.X, Position.Y, newDirection);

        }

        public void RotateRight()
        {
            Direction newDirection = Position.Direction switch
            {
                Direction.North => Direction.East,
                Direction.East => Direction.South,
                Direction.South => Direction.West,
                Direction.West => Direction.North,
                _ => throw new InvalidOperationException("Invalid direction")
            };
            Position = new Position(Position.X, Position.Y, newDirection);
        }

       

        public string TakePhoto() => "Photo taken";
        public string CollectSample() => "Sample collected";


    }
}
