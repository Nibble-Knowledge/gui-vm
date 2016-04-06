INF 19

;Start of code from C:\Users\Bailey\Documents\GitHub\gui-vm\NK4VM2\NK4VM2\bin\Debug\Files\ASMs\SerialTest.txt

;Included serialdriver.s

LOD &(return[0])[0]
STR DRIVER_SERIAL.Exit[1]
LOD &(return[0])[1]
STR DRIVER_SERIAL.Exit[2]
LOD &(return[0])[2]
STR DRIVER_SERIAL.Exit[3]
LOD &(return[0])[3]
STR DRIVER_SERIAL.Exit[4]
LOD DAT[0]
STR DRIVER_SERIAL.TxByte[0]
LOD DAT[1]
STR DRIVER_SERIAL.TxByte[1]
LOD N_[0]
JMP DRIVER_SERIAL.TxEnter
return:
NOP 0


;End of code from C:\Users\Bailey\Documents\GitHub\gui-vm\NK4VM2\NK4VM2\bin\Debug\Files\ASMs\SerialTest.txt

;Start of code from serialdriver.s




DRIVER_SERIAL.RxEnter:

#setup, read status bus
LOD CS_SERIAL[0]
STR CHIP_SELECT[0]
LOD N_[8]
STR STATUS_BUS[0]

#check for ready flag
LOD STATUS_BUS[0]
NND N_[2]
NND N_[F]
STR DRIVER_SERIAL.RxGotData[0]

#If no ready found, exit
LOD DRIVER_SERIAL.RxGotData
JMP DRIVER_SERIAL.Done

#grab first nibble of data
LOD DATA_BUS
STR DRIVER_SERIAL.RxByte[0]

#cycle write signal
LOD N_[0]
STR STATUS_BUS[0]
LOD N_[8]
STR STATUS_BUS[0]

#grab second nibble
LOD DATA_BUS
STR DRIVER_SERIAL.RxByte[1]

LOD N_[0]
STR STATUS_BUS[0]
LOD N_[0]
JMP DRIVER_SERIAL.Done

#--------------------------------------------


DRIVER_SERIAL.TxEnter:

#setup, read status bus
LOD CS_SERIAL[0]
STR CHIP_SELECT[0]
LOD N_[4]
STR STATUS_BUS[0]

#send first nibble of data
LOD DRIVER_SERIAL.TxByte[0]
STR DATA_BUS[0]

#cycle write signal
LOD N_[0]
STR STATUS_BUS[0]
LOD N_[4]
STR STATUS_BUS[0]

#send second nibble
LOD DRIVER_SERIAL.TxByte[1]
STR DATA_BUS[0]

LOD N_[0]
STR STATUS_BUS[0]
LOD N_[0]
JMP DRIVER_SERIAL.Done

#----------------------------------------------

DRIVER_SERIAL.Done:
LOD N_[f]
STR CHIP_SELECT[0]
LOD N_[0]
DRIVER_SERIAL.Exit:
JMP 0x0000





;End of code from serialdriver.s
;Start of data sections
;Start of data from C:\Users\Bailey\Documents\GitHub\gui-vm\NK4VM2\NK4VM2\bin\Debug\Files\ASMs\SerialTest.txt

DAT: .data 2 0x41

;End of data from C:\Users\Bailey\Documents\GitHub\gui-vm\NK4VM2\NK4VM2\bin\Debug\Files\ASMs\SerialTest.txt

;Start of data from serialdriver.s

DRIVER_SERIAL.TxByte: .data 2
DRIVER_SERIAL.RxByte: .data 2
DRIVER_SERIAL.RxGotData: .data 1


;End of data from serialdriver.s
