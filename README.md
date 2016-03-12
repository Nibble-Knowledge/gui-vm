# Nibble Knowledge CPU GUI

GUI of Nibble Knowledge CPU Virtual Machine

Features:
 - Write, edit, and assemble NK4 Assembly and Macro Assembly
 - Step through the code at your own pace
 - See the CPU Registers, and Main Memory update as you step through the code
 - Simulate the NK4 CPU running through code with a given period
 - Attach a virtual hard drive that can be written to, and read from (Currently only 1000 sectors in size)

Notes:
 - To make a BREAKPOINT you can add a NOP 1000 which will cause the simulation to stop 
 - Currently Macro Assembly is the highest language supported, cute-basic will not compile. 

Warnings:
 - Right now the minimum recommended simulating speed is a period of 1 when using the HD peripheral. Beyond this could have unintentional    side-effects. This will hopefully be resolved soon.
