using System;
using System.Collections.Generic;

namespace func.brainfuck
{
	public class VirtualMachine : IVirtualMachine
	{
		public string Instructions { get; }
		public int InstructionPointer { get; set; }
		public byte[] Memory { get; }
		public int MemoryPointer { get; set; }
        private readonly Dictionary<char, Action<IVirtualMachine>> commands = new();

        public VirtualMachine(string program, int memorySize)
		{
			this.Instructions = program;
			this.Memory = new byte[memorySize];
			this.MemoryPointer = 0;
			this.InstructionPointer = 0;
		}

		public void RegisterCommand(char symbol, Action<IVirtualMachine> execute)
		{
			commands.Add(symbol, execute);
		}

		public void Run()
		{
			while(InstructionPointer < Instructions.Length)
			{
				if (commands.ContainsKey(Instructions[InstructionPointer]))
				{
                    var comand = commands[Instructions[InstructionPointer]];
                    comand(this);
                }
                InstructionPointer++;
            }
		}
	}
}