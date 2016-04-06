

#---------------------------------Print Char-------------------------------
#Regular entry point, for printing a character
VGA_DRIVER.Entry:

MOV N_[0b0000] INTO STATUS_BUS
#Subject to change when chip select addresses finalized
MOV CS_VGA INTO CHIP_SELECT

#Print the character
MOV N_[0b0100] INTO STATUS_BUS
MOV VGA_DRIVER.Char[0] INTO DATA_BUS
MOV N_[0b0000] INTO STATUS_BUS

MOV N_[0b0100] INTO STATUS_BUS
MOV VGA_DRIVER.Char[1] INTO DATA_BUS
MOV N_[0b0000] INTO STATUS_BUS

MOV N_[0b0100] INTO STATUS_BUS
MOV N_[0b0000] INTO STATUS_BUS

MOV N_[0b0100] INTO STATUS_BUS
MOV N_[0b0000] INTO STATUS_BUS

#Housekeeping; keep track of where we are on the screen
INC8 VGA_DRIVER.ColumnCount

#If we passed into a new line, reset column count, and increment line count
JMPNE8 VGA_DRIVER.ColumnCount VGA_DRIVER.ColumnMax TO VGA_DRIVER.DoneChar

MOV N_[0] INTO VGA_DRIVER.ColumnCount[0]
MOV N_[0] INTO VGA_DRIVER.ColumnCount[1]

INC8 VGA_DRIVER.LineCount

#If we rolled over the end of the screen, reset row count as well.
JMPNE8 VGA_DRIVER.LineCount VGA_DRIVER.LineMax TO VGA_DRIVER.DoneChar

MOV N_[0] INTO VGA_DRIVER.LineCount[0]
MOV N_[0] INTO VGA_DRIVER.LineCount[1]

#Done housekeeping
VGA_DRIVER.DoneChar:
LOD N_[0]

#Internally managed jump point - always reset to point to
#the actual exit when done.
VGA_DRIVER.CharExit:
JMP VGA_DRIVER.Done




#-----------------------------------------Newline------------------

#Adding additional functions for newline and clear screen functions
#These call the function above.

VGA_DRIVER.EntryNewline:

MOV8 VGA_DRIVER.SpaceChar INTO VGA_DRIVER.Char
MOVADDR VGA_DRIVER.NLRet1 INTO VGA_DRIVER.CharExit[1]

#print one space unconditionally, so this works even on a fresh line
#This is basically a do-while loop
#DO
VGA_DRIVER.NLLoop:

LOD N_[0]
JMP VGA_DRIVER.Entry

#WHILE (columnCount != 0)
VGA_DRIVER.NLRet1:
JMPNE8 VGA_DRIVER.ColumnCount VGA_DRIVER.ZeroByte TO VGA_DRIVER.NLLoop

#Return
LOD N_[0]
VGA_DRIVER.NLExit:
JMP VGA_DRIVER.NLDone
 


#--------------------------------------Clear Screen------------------
VGA_DRIVER.EntryClearScreen:

MOVADDR VGA_DRIVER.CSRet1 INTO VGA_DRIVER.NLExit[1]

#While lineCount != 0
#	NewLine;
VGA_DRIVER.CSLoop1:
JMPEQ8 VGA_DRIVER.LineCount VGA_DRIVER.ZeroByte TO VGA_DRIVER.CSDoneLoop1

LOD N_[0]
JMP VGA_DRIVER.EntryNewline

VGA_DRIVER.CSRet1:
LOD N_[0]
JMP VGA_DRIVER.CSLoop1

VGA_DRIVER.CSDoneLoop1:
MOVADDR VGA_DRIVER.CSRet2 INTO VGA_DRIVER.NLExit[1]

#DO
VGA_DRIVER.CSLoop2:

LOD N_[0]
JMP VGA_DRIVER.EntryNewline

#WHILE
VGA_DRIVER.CSRet2:
JMPNE8 VGA_DRIVER.LineCount VGA_DRIVER.ZeroByte TO VGA_DRIVER.CSLoop2

#Control falls through when this loop exits

#--------------------------------------Cleanup & Return-------------

#Clean up the second modifiable jump point, if we fell through
#from clearing the screen.
MOVADDR VGA_DRIVER.NLDone INTO VGA_DRIVER.NLExit[1]

#clean up our first modifiable jump point, if we used the newline at all.
VGA_DRIVER.NLDone:
MOVADDR VGA_DRIVER.Done INTO VGA_DRIVER.CharExit[1]
LOD N_[0]

VGA_DRIVER.Done:

MOV N_[F] INTO CHIP_SELECT
LOD N_[0]
VGA_DRIVER.Exit:
JMP 0x0000



VGA_DRIVER.Char:		.data 2
VGA_DRIVER.LineCount:	.data 2 0x00
VGA_DRIVER.ColumnCount:	.data 2 0x00

VGA_DRIVER.LineMax:		.data 2 0d30
VGA_DRIVER.ColumnMax:	.data 2 0d40

VGA_DRIVER.ZeroByte:	.data 2 0x00
VGA_DRIVER.SpaceChar:	.data 2 0x20


