INF 19

;Start of code from C:\Users\Bailey\Documents\GitHub\gui-vm\NK4VM2\NK4VM2\bin\Debug\Files\ASMs\KeyboardSound.txt

;Included ps2driver.s
LOD &(return[0])[0]
STR PS2_DRIVER.Exit[1]
LOD &(return[0])[1]
STR PS2_DRIVER.Exit[2]
LOD &(return[0])[2]
STR PS2_DRIVER.Exit[3]
LOD &(return[0])[3]
STR PS2_DRIVER.Exit[4]
Start:
LOD N_[0]
JMP PS2_DRIVER.Enter
return:
LOD PS2_DRIVER.GotKey
JMP Start
LOD PS2_DRIVER.Keystroke[1]
STR macro[0]
LOD N_[F]
STR CHIP_SELECT
LOD N_[4]
STR STATUS_BUS
LOD N_[0]
STR STATUS_BUS
LOD N_[0b0000]
STR STATUS_BUS
LOD CS_AUDIO
STR CHIP_SELECT
LOD macro[0]
STR DATA_BUS
LOD N_[0b0100]
STR STATUS_BUS
LOD N_[0b0000]
STR STATUS_BUS
LOD N_[F]
STR CHIP_SELECT
LOD macro[0]
LOD N_[0]
JMP Start

;End of code from C:\Users\Bailey\Documents\GitHub\gui-vm\NK4VM2\NK4VM2\bin\Debug\Files\ASMs\KeyboardSound.txt

;Start of code from ps2driver.s

#driver for ps2 keyboard controller

PS2_DRIVER.Enter:

#Change when final chip select assignments made
LOD CS_KEYBOARD[0]
STR CHIP_SELECT[0]

#Check for ready signal - if not given, note this and return.
#If given, note this and continue

LOD STATUS_BUS[0]
NND N_[2]
NND N_[F]
STR PS2_DRIVER.GotKey[0]
LOD PS2_DRIVER.GotKey
JMP PS2_DRIVER.Done

#If a key was found, read it.

LOD N_[8]
STR STATUS_BUS[0]
LOD DATA_BUS[0]
STR PS2_DRIVER.Keystroke[0]
LOD N_[0]
STR STATUS_BUS[0]

LOD N_[8]
STR STATUS_BUS[0]
LOD DATA_BUS[0]
STR PS2_DRIVER.Keystroke[1]
LOD N_[0]
STR STATUS_BUS[0]

#Return
PS2_DRIVER.Done:

LOD N_[f]
STR CHIP_SELECT[0]
LOD N_[0]

PS2_DRIVER.Exit:
JMP 0x0000



;End of code from ps2driver.s
;Start of data sections
;Start of data from C:\Users\Bailey\Documents\GitHub\gui-vm\NK4VM2\NK4VM2\bin\Debug\Files\ASMs\KeyboardSound.txt


;End of data from C:\Users\Bailey\Documents\GitHub\gui-vm\NK4VM2\NK4VM2\bin\Debug\Files\ASMs\KeyboardSound.txt

;Start of data from ps2driver.s

PS2_DRIVER.GotKey: .data 1
PS2_DRIVER.Keystroke: .data 2

;End of data from ps2driver.s

;memory space used by macros
macro: .data 1

