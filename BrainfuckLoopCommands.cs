using System;
using System.Collections.Generic;

namespace func.brainfuck
{
    public class BrainfuckLoopCommands
    {
        public static void RegisterTo(IVirtualMachine vm)
        {
            int[] bracketIndices = FindBracketIndices(vm.Instructions);

            vm.RegisterCommand('[', b =>
            {
                if (b.Memory[b.MemoryPointer] == 0)
                {
                    b.InstructionPointer = bracketIndices[b.InstructionPointer];
                }
            });

            vm.RegisterCommand(']', b =>
            {
                if (b.Memory[b.MemoryPointer] != 0)
                {
                    b.InstructionPointer = bracketIndices[b.InstructionPointer];
                }
            });
        }

        private static int[] FindBracketIndices(string instructions)
        {
            int[] indices = new int[instructions.Length];
            Stack<int> stack = new Stack<int>();

            for (int i = 0; i < instructions.Length; i++)
            {
                if (instructions[i] == '[')
                {
                    stack.Push(i);
                }
                else if (instructions[i] == ']')
                {
                    int openingBracket = stack.Pop();
                    indices[openingBracket] = i;
                    indices[i] = openingBracket;
                }
            }

            return indices;
        }
    }
}
