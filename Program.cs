using MarsRover.ENUM;

namespace MarsRover
{
    public static class Program
    {
         
        public static List<string> RunMission(List<string> input)
        {
            // 1. Validation
            if (input == null)
            {
                throw new ArgumentNullException(nameof(input), "Input cannot be null.");
            }
            if (input.Count != 5)
            {
                throw new ArgumentException("Input must contain exactly 5 lines.");
            }
            if (input.Any(string.IsNullOrWhiteSpace))
            {
                throw new ArgumentException("Input cannot contain empty lines.");
            }

            // 2. Parsing the Plateau
            Plateau plateau = PlateauParser.Parse(input[0]);
            var mission = new MissionControl(plateau);

            // 3. Parsing Rovers and Instructions
            Position pos1 = PositionParser.Parse(input[1]);
            List<Instruction> inst1 = InstructionParser.Parse(input[2]);

            Position pos2 = PositionParser.Parse(input[3]);
            List<Instruction> inst2 = InstructionParser.Parse(input[4]);

            // 4. Initializing Rovers
            var rover1 = new Rover(pos1);
            var rover2 = new Rover(pos2);

            // 5. Deployment & Execution
            mission.DeployRover(rover1);
            mission.DeployRover(rover2);

            ExecuteRoverCommands(mission, rover1, inst1);
            ExecuteRoverCommands(mission, rover2, inst2);

            return new List<string>
            {
                $"{rover1.Position.X} {rover1.Position.Y} {rover1.Position.Direction}",
                $"{rover2.Position.X} {rover2.Position.Y} {rover2.Position.Direction}"
            };
        }

        static void ExecuteRoverCommands(MissionControl mission, Rover rover, List<Instruction> instructions)
        {
            foreach (var instruction in instructions)
            {
                switch (instruction)
                {
                    case Instruction.MoveForward:
                        mission.ExecuteMoveCommand(rover);
                        break;
                    case Instruction.TurnLeft:
                        rover.RotateLeft();
                        break;
                    case Instruction.TurnRight:
                        rover.RotateRight();
                        break;
                    default:
                        throw new InvalidOperationException("Invalid instruction");
                }
            }
        }
    }
}
