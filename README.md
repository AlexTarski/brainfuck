# Brainfuck


This project is a representation of an interpreter for the Brainfuck-like programming language.

VirtualMachine class is the basic class for its initialization, command registration and running interpreter.

This class consists of memory array (one cell stores 1 byte); memory pointer (default = 0); program instructions (stores into string; each symbol equals to one instruction); instruction pointer (points to instruction(command) in instructions string; increases by 1 after every command execution; execution of commands ends when pointer reach instructions length).

Correlation between char from instruction string and command itself is stored in dictionary.

Commands list:

.             Write byte pointed by a memory pointer as a character according to ASCII;

+             Increase memory byte pointed by memory pointer;

-             Decrease memory byte pointed by memory pointer;

,             Read character and store its ASCII-code into memory byte pointed by memory pointer;

>             Move memory pointer right;

<             Move memory pointer left;

A-Z, a-z,
0-9           store ASCII-code of that character into memory byte pointed by memory pointer;

[             (Cycle begin) see Brainfuck cycle documentation for more details;

]             (Cycle end) see Brainfuck cycle documentation for more details;
