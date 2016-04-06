


DRIVER_SERIAL.RxEnter:

#setup, read status bus
MOV CS_SERIAL INTO CHIP_SELECT
MOV N_[0b1000] INTO STATUS_BUS

#check for ready flag
AND STATUS_BUS N_[0b0010] INTO DRIVER_SERIAL.RxGotData

#If no ready found, exit
LOD DRIVER_SERIAL.RxGotData
JMP DRIVER_SERIAL.Done

#grab first nibble of data
LOD DATA_BUS
STR DRIVER_SERIAL.RxByte[0]

#cycle write signal
MOV N_[0b0000] INTO STATUS_BUS
MOV N_[0b1000] INTO STATUS_BUS

#grab second nibble
LOD DATA_BUS
STR DRIVER_SERIAL.RxByte[1]

MOV N_[0b0000] INTO STATUS_BUS
LOD N_[0]
JMP DRIVER_SERIAL.Done

#--------------------------------------------


DRIVER_SERIAL.TxEnter:

#setup, read status bus
MOV CS_SERIAL INTO CHIP_SELECT
MOV N_[0b0100] INTO STATUS_BUS

#send first nibble of data
MOV DRIVER_SERIAL.TxByte[0] INTO DATA_BUS

#cycle write signal
MOV N_[0b0000] INTO STATUS_BUS
MOV N_[0b0100] INTO STATUS_BUS

#send second nibble
MOV DRIVER_SERIAL.TxByte[1] INTO DATA_BUS

MOV N_[0b0000] INTO STATUS_BUS
LOD N_[0]
JMP DRIVER_SERIAL.Done

#----------------------------------------------

DRIVER_SERIAL.Done:
MOV N_[F] INTO CHIP_SELECT
LOD N_[0]
DRIVER_SERIAL.Exit:
JMP 0x0000




DRIVER_SERIAL.TxByte:		.data 2
DRIVER_SERIAL.RxByte:		.data 2
DRIVER_SERIAL.RxGotData:	.data 1

