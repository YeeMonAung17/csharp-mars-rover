using MarsRover.ENUM;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MarsRover
{
    public class InstructionParser
    {
        public static List<Instruction> Parse (string input)
        {
            if(string.IsNullOrWhiteSpace(input))
                            {
                throw new ArgumentException("Input cannot be null or whitespace.");
            }

            List<Instruction> instructions = new List<Instruction>();

            foreach (char c in input)
            {
                switch (char.ToUpper(c))
                {
                    case 'L':
                        instructions.Add(Instruction.TurnLeft);
                        break;
                    case 'R':
                        instructions.Add(Instruction.TurnRight);
                        break;
                    case 'M':
                        instructions.Add(Instruction.MoveForward);
                        break;
                    default:
                        throw new ArgumentException($"Invalid instruction character: {c}");
                }
            }

            return instructions;
        }
    }
}
