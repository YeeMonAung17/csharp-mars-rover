using MarsRover.ENUM;

namespace MarsRover
{
    internal class Program
    {
        static void Main()
        {
            string plateauSizeInput = "5 5";
            string positionInput = "1 2 N";
            string instructionsInput = "LMLMLMLMM";

            try
            {
                PlateauSize plateauSize = PlateauParser.Parse(plateauSizeInput);
                Position position = PositionParser.Parse(positionInput);
                List<Instruction> instructions = InstructionParser.Parse(instructionsInput);

                if (!plateauSize.IsWithinBounds(position))
                {
                    Console.WriteLine("Initial position is out of bounds.");
                    return;
                }

                Console.WriteLine("--- Mission Control Loaded ---");
                Console.WriteLine($"Plateau Size: {plateauSize.MaxX} {plateauSize.MaxY}");
                Console.WriteLine($"Rover Start: {position.X} {position.Y} {position.Direction}");
                Console.WriteLine($"Instructions Loaded: {instructions.Count} commands");

            }

            catch (Exception ex)
            {
                Console.WriteLine($"Error: {ex.Message}");
            }
        }
    }
}
