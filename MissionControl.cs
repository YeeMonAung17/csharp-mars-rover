using MarsRover.ENUM;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MarsRover
{
    public class MissionControl
    {
        private readonly Plateau plateau;
        private readonly List<Rover> rovers = new();

            public MissionControl(Plateau plateau)
            {
                this.plateau = plateau ?? throw new ArgumentNullException(nameof(plateau), "Plateau cannot be null.");
        }
        public void DeployRover(Rover rover)
        {

            if (rover == null)
            {
                throw new ArgumentNullException(nameof(rover), "Rover cannot be null.");
            }



            if (!plateau.IsWithinBounds(rover.Position))
            {
               
                           throw new InvalidOperationException("Position is out of bounds.");
            }


            if(!plateau.IsPositionEmpty(rover.Position,rovers))
            {
                throw new InvalidOperationException(" Position is already occupied.");
            }

            rovers.Add(rover);
        }

       
        public void ExecuteMoveCommand (Rover rover)
        {
            if (rover == null)
            {
                throw new ArgumentNullException(nameof(rover), "Rover cannot be null.");
            }

            Position current = rover.Position; 

            Position nextPosition = rover.GetNextPosition();
            

            bool canMove = plateau.IsWithinBounds(nextPosition) && plateau.IsPositionEmpty(nextPosition, rovers);


            if(!canMove)
            {
                throw new InvalidOperationException("Cannot move rover to the specified position.");
            }

            rover.GoStraight();


        }



    }
}
