using System;
using System.Collections.Generic;
using System.Linq;

namespace func.brainfuck
{
	public class BrainfuckBasicCommands
	{
		public static void RegisterTo(IVirtualMachine vm, Func<int> read, Action<char> write)
		{
			vm.RegisterCommand('.', b => { write((char)b.Memory[b.MemoryPointer]); });
			vm.RegisterCommand('+', b => { unchecked { b.Memory[b.MemoryPointer] += 1; } });
			vm.RegisterCommand('-', b => { unchecked { b.Memory[b.MemoryPointer] -= 1; } });
            vm.RegisterCommand(',', b => { b.Memory[b.MemoryPointer] = (byte)read(); });
            vm.RegisterCommand('>', b => { b.MemoryPointer++; if (b.MemoryPointer >= b.Memory.Length) { b.MemoryPointer = 0; } });
            vm.RegisterCommand('<', b => { b.MemoryPointer--; if (b.MemoryPointer < 0) { b.MemoryPointer = b.Memory.Length - 1; } });
			for (char i = '0'; i <= '9';  i++)
			{
				char temp = i;
				vm.RegisterCommand(i, b => { b.Memory[b.MemoryPointer] = (byte)temp; });
            }
			for (char c = 'a'; c <= 'z';  c++)
			{
				char temp = c;
				vm.RegisterCommand(c, b => { b.Memory[b.MemoryPointer] = (byte)temp; });
                vm.RegisterCommand(char.ToUpper(c), b => { b.Memory[b.MemoryPointer] = (byte)char.ToUpper(temp); });
            }
        }
	}
}