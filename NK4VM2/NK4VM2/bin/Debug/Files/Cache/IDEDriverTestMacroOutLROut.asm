INF
PINF
BADR 19
EPINF
DSEC D_SEC
DNUM 1
DSIZE 4
DNUM 1
DSIZE 2
DNUM 1
DSIZE 4
DNUM 1
DSIZE 1
DNUM 1
DSIZE 2
DNUM 1
DSIZE 4
DNUM 1
DSIZE 1
DNUM 1
DSIZE 5
DNUM 5
DSIZE 2
DNUM 1
DSIZE 4
DNUM 1
DSIZE 2
DNUM 1
DSIZE 1
DNUM 1
DSIZE 2
DNUM 1
DSIZE 1
NSTART 3
EINF
NOP 1000
LOD 18
STR 0
LOD 7
STR 1
LOD 3
STR 1
LOD ADDRESS[0]
STR IDE_DRIVER.DataPtr[0]
LOD ADDRESS[1]
STR IDE_DRIVER.DataPtr[1]
LOD ADDRESS[2]
STR IDE_DRIVER.DataPtr[2]
LOD ADDRESS[3]
STR IDE_DRIVER.DataPtr[3]
LOD SEC[0]
STR IDE_DRIVER.SecNum[0]
LOD SEC[1]
STR IDE_DRIVER.SecNum[1]
LOD CYL[0]
STR IDE_DRIVER.Cyl[0]
LOD CYL[1]
STR IDE_DRIVER.Cyl[1]
LOD CYL[2]
STR IDE_DRIVER.Cyl[2]
LOD CYL[3]
STR IDE_DRIVER.Cyl[3]
LOD READ[0]
STR IDE_DRIVER.ZeroToWrite[0]
LOD &(RETURN[0])[0]
STR IDE_DRIVER.Exit[1]
LOD &(RETURN[0])[1]
STR IDE_DRIVER.Exit[2]
LOD &(RETURN[0])[2]
STR IDE_DRIVER.Exit[3]
LOD &(RETURN[0])[3]
STR IDE_DRIVER.Exit[4]
LOD 0
NOP 1000
JMP IDE_DRIVER.Enter
RETURN:
LOD IDE_DRIVER.Status[0]
STR STAT[0]
LOD IDE_DRIVER.Status[1]
STR STAT[1]
LOD 3
JMP 0xC350
HLT
IDE_DRIVER.Enter:
LOD 4
STR 0
LOD IDE_DRIVER.Cyl[2]
STR IDE_DRIVER.Cyl23[0]
LOD IDE_DRIVER.Cyl[3]
STR IDE_DRIVER.Cyl23[1]
LOD IDE_DRIVER.Cyl[0]
STR IDE_DRIVER.Cyl01[0]
LOD IDE_DRIVER.Cyl[1]
STR IDE_DRIVER.Cyl01[1]
LOD &(IDE_DRIVER.RegTable[0])[0]
STR IDE_DRIVER.RegPtr[1]
LOD &(IDE_DRIVER.RegTable[0])[1]
STR IDE_DRIVER.RegPtr[2]
LOD &(IDE_DRIVER.RegTable[0])[2]
STR IDE_DRIVER.RegPtr[3]
LOD &(IDE_DRIVER.RegTable[0])[3]
STR IDE_DRIVER.RegPtr[4]
LOD &(IDE_DRIVER.LocTable[0])[0]
STR IDE_DRIVER.LocPtr1[1]
LOD &(IDE_DRIVER.LocTable[0])[1]
STR IDE_DRIVER.LocPtr1[2]
LOD &(IDE_DRIVER.LocTable[0])[2]
STR IDE_DRIVER.LocPtr1[3]
LOD &(IDE_DRIVER.LocTable[0])[3]
STR IDE_DRIVER.LocPtr1[4]
LOD 3
STR IDE_DRIVER.LocationLoop[0]
IDE_DRIVER.SetupLoop:
LOD 7
STR 1
IDE_DRIVER.RegPtr:
LOD 0x0000
STR 2
LOD 3
STR 1
LOD 7
STR 1
LOD 3
STR 1
LOD 7
STR 1
LOD 3
STR 1
LOD 7
STR 1
IDE_DRIVER.LocPtr1:
LOD 0x0000
STR 2
LOD 3
STR 1
LOD 11
ADD 11
LOD 3
ADD IDE_DRIVER.LocPtr1[4]
STR IDE_DRIVER.LocPtr2[4]
LOD 3
ADD IDE_DRIVER.LocPtr1[3]
STR IDE_DRIVER.LocPtr2[3]
LOD 3
ADD IDE_DRIVER.LocPtr1[2]
STR IDE_DRIVER.LocPtr2[2]
LOD 3
ADD IDE_DRIVER.LocPtr1[1]
STR IDE_DRIVER.LocPtr2[1]
LOD 7
STR 1
IDE_DRIVER.LocPtr2:
LOD 0x0000
STR 2
LOD 3
STR 1
LOD 11
ADD 11
LOD 3
ADD IDE_DRIVER.LocPtr2[4]
STR IDE_DRIVER.LocPtr1[4]
LOD 3
ADD IDE_DRIVER.LocPtr2[3]
STR IDE_DRIVER.LocPtr1[3]
LOD 3
ADD IDE_DRIVER.LocPtr2[2]
STR IDE_DRIVER.LocPtr1[2]
LOD 3
ADD IDE_DRIVER.LocPtr2[1]
STR IDE_DRIVER.LocPtr1[1]
LOD 7
STR 1
LOD 3
STR 1
LOD 7
STR 1
LOD 3
STR 1
LOD 7
STR 1
LOD 3
STR 1
LOD 7
STR 1
LOD 3
STR 1
LOD 11
ADD 11
LOD 3
ADD IDE_DRIVER.RegPtr[4]
STR IDE_DRIVER.RegPtr[4]
LOD 3
ADD IDE_DRIVER.RegPtr[3]
STR IDE_DRIVER.RegPtr[3]
LOD 3
ADD IDE_DRIVER.RegPtr[2]
STR IDE_DRIVER.RegPtr[2]
LOD 3
ADD IDE_DRIVER.RegPtr[1]
STR IDE_DRIVER.RegPtr[1]
LOD 3
ADD 3
LOD 4
ADD IDE_DRIVER.LocationLoop[0]
STR IDE_DRIVER.LocationLoop[0]
ADD 14
STR macro[0]
LOD 3
ADD 3
LOD macro[0]
ADD 18
CXA 0
NND 4
NND 4
NND 18
JMP IDE_DRIVER.SetupLoop
LOD 3
STR IDE_DRIVER.LoopCount[0]
LOD 3
STR IDE_DRIVER.LoopCount[1]
LOD 3
STR IDE_DRIVER.LoopCount[2]
LOD 3
STR IDE_DRIVER.LoopCount[3]
LOD IDE_DRIVER.ZeroToWrite
JMP IDE_DRIVER.Write
LOD 7
STR 1
LOD 18
STR 2
LOD 3
STR 1
LOD 7
STR 1
LOD 3
STR 1
LOD 7
STR 1
LOD 3
STR 1
LOD 7
STR 1
LOD 5
STR 2
LOD 3
STR 1
LOD 7
STR 1
LOD 3
STR 2
LOD 3
STR 1
LOD 7
STR 1
LOD 3
STR 1
LOD 7
STR 1
LOD 3
STR 1
LOD 7
STR 1
LOD 3
STR 1
LOD 7
STR 1
LOD 3
STR 1
IDE_DRIVER.CheckReadLoop:
LOD 7
STR 1
LOD 18
STR 2
LOD 3
STR 1
LOD 11
STR 1
LOD 3
STR 1
LOD 11
STR 1
LOD 3
STR 1
LOD 11
STR 1
LOD 3
STR 1
LOD 11
STR 1
LOD 3
STR 1
LOD 11
STR 1
LOD 3
STR 1
LOD 11
STR 1
LOD 3
STR 1
LOD 11
STR 1
LOD 2
STR IDE_DRIVER.Status[0]
LOD 3
STR 1
LOD 11
STR 1
LOD 2
STR IDE_DRIVER.Status[1]
LOD 3
STR 1
LOD IDE_DRIVER.Status[1]
ADD 11
LOD 3
ADD 3
JMP IDE_DRIVER.CheckReadLoop
LOD IDE_DRIVER.DataPtr[0]
STR IDE_DRIVER.RPtr4[1]
LOD IDE_DRIVER.DataPtr[1]
STR IDE_DRIVER.RPtr4[2]
LOD IDE_DRIVER.DataPtr[2]
STR IDE_DRIVER.RPtr4[3]
LOD IDE_DRIVER.DataPtr[3]
STR IDE_DRIVER.RPtr4[4]
IDE_DRIVER.ReadLoop:
LOD 7
STR 1
LOD 11
STR 2
LOD 3
STR 1
LOD 11
STR 1
LOD 3
STR 1
LOD 11
STR 1
LOD 3
STR 1
LOD 11
STR 1
LOD 3
STR 1
LOD 11
STR 1
LOD 3
STR 1
LOD 11
ADD 11
LOD 3
ADD IDE_DRIVER.RPtr4[4]
STR IDE_DRIVER.RPtr3[4]
LOD 3
ADD IDE_DRIVER.RPtr4[3]
STR IDE_DRIVER.RPtr3[3]
LOD 3
ADD IDE_DRIVER.RPtr4[2]
STR IDE_DRIVER.RPtr3[2]
LOD 3
ADD IDE_DRIVER.RPtr4[1]
STR IDE_DRIVER.RPtr3[1]
LOD 11
ADD 11
LOD 3
ADD IDE_DRIVER.RPtr3[4]
STR IDE_DRIVER.RPtr2[4]
LOD 3
ADD IDE_DRIVER.RPtr3[3]
STR IDE_DRIVER.RPtr2[3]
LOD 3
ADD IDE_DRIVER.RPtr3[2]
STR IDE_DRIVER.RPtr2[2]
LOD 3
ADD IDE_DRIVER.RPtr3[1]
STR IDE_DRIVER.RPtr2[1]
LOD 11
ADD 11
LOD 3
ADD IDE_DRIVER.RPtr2[4]
STR IDE_DRIVER.RPtr1[4]
LOD 3
ADD IDE_DRIVER.RPtr2[3]
STR IDE_DRIVER.RPtr1[3]
LOD 3
ADD IDE_DRIVER.RPtr2[2]
STR IDE_DRIVER.RPtr1[2]
LOD 3
ADD IDE_DRIVER.RPtr2[1]
STR IDE_DRIVER.RPtr1[1]
LOD 11
STR 1
LOD 2
IDE_DRIVER.RPtr1:
STR 0x0000
LOD 3
STR 1
LOD 11
STR 1
LOD 2
IDE_DRIVER.RPtr2:
STR 0x0000
LOD 3
STR 1
LOD 11
STR 1
LOD 2
IDE_DRIVER.RPtr3:
STR 0x0000
LOD 3
STR 1
LOD 11
STR 1
LOD 2
IDE_DRIVER.RPtr4:
STR 0x0000
LOD 3
STR 1
LOD 11
ADD 11
LOD 3
ADD IDE_DRIVER.RPtr1[4]
STR IDE_DRIVER.RPtr4[4]
LOD 3
ADD IDE_DRIVER.RPtr1[3]
STR IDE_DRIVER.RPtr4[3]
LOD 3
ADD IDE_DRIVER.RPtr1[2]
STR IDE_DRIVER.RPtr4[2]
LOD 3
ADD IDE_DRIVER.RPtr1[1]
STR IDE_DRIVER.RPtr4[1]
LOD 11
ADD 11
LOD 3
ADD IDE_DRIVER.LoopCount[1]
STR IDE_DRIVER.LoopCount[1]
LOD 3
ADD IDE_DRIVER.LoopCount[0]
STR IDE_DRIVER.LoopCount[0]
LOD 3
ADD 3
STR macro[0]
LOD 3
ADD 3
LOD macro[0]
ADD 18
CXA 0
NND 4
NND 4
NND 18
JMP IDE_DRIVER.DoneReadLoop
LOD 3
JMP IDE_DRIVER.ReadLoop
IDE_DRIVER.DoneReadLoop:
LOD 3
JMP IDE_DRIVER.Done
IDE_DRIVER.Write:
LOD 7
STR 1
LOD 18
STR 2
LOD 3
STR 1
LOD 7
STR 1
LOD 3
STR 1
LOD 7
STR 1
LOD 3
STR 1
LOD 7
STR 1
LOD 6
STR 2
LOD 3
STR 1
LOD 7
STR 1
LOD 3
STR 2
LOD 3
STR 1
LOD 7
STR 1
LOD 3
STR 1
LOD 7
STR 1
LOD 3
STR 1
LOD 7
STR 1
LOD 3
STR 1
LOD 7
STR 1
LOD 3
STR 1
LOD IDE_DRIVER.DataPtr[0]
STR IDE_DRIVER.WPtr4[1]
LOD IDE_DRIVER.DataPtr[1]
STR IDE_DRIVER.WPtr4[2]
LOD IDE_DRIVER.DataPtr[2]
STR IDE_DRIVER.WPtr4[3]
LOD IDE_DRIVER.DataPtr[3]
STR IDE_DRIVER.WPtr4[4]
IDE_DRIVER.WriteLoop:
LOD 7
STR 1
LOD 11
STR 2
LOD 3
STR 1
LOD 11
ADD 11
LOD 3
ADD IDE_DRIVER.WPtr4[4]
STR IDE_DRIVER.WPtr3[4]
LOD 3
ADD IDE_DRIVER.WPtr4[3]
STR IDE_DRIVER.WPtr3[3]
LOD 3
ADD IDE_DRIVER.WPtr4[2]
STR IDE_DRIVER.WPtr3[2]
LOD 3
ADD IDE_DRIVER.WPtr4[1]
STR IDE_DRIVER.WPtr3[1]
LOD 11
ADD 11
LOD 3
ADD IDE_DRIVER.WPtr3[4]
STR IDE_DRIVER.WPtr2[4]
LOD 3
ADD IDE_DRIVER.WPtr3[3]
STR IDE_DRIVER.WPtr2[3]
LOD 3
ADD IDE_DRIVER.WPtr3[2]
STR IDE_DRIVER.WPtr2[2]
LOD 3
ADD IDE_DRIVER.WPtr3[1]
STR IDE_DRIVER.WPtr2[1]
LOD 11
ADD 11
LOD 3
ADD IDE_DRIVER.WPtr2[4]
STR IDE_DRIVER.WPtr1[4]
LOD 3
ADD IDE_DRIVER.WPtr2[3]
STR IDE_DRIVER.WPtr1[3]
LOD 3
ADD IDE_DRIVER.WPtr2[2]
STR IDE_DRIVER.WPtr1[2]
LOD 3
ADD IDE_DRIVER.WPtr2[1]
STR IDE_DRIVER.WPtr1[1]
LOD 7
STR 1
IDE_DRIVER.WPtr1:
LOD 0x0000
STR 2
LOD 3
STR 1
LOD 7
STR 1
IDE_DRIVER.WPtr2:
LOD 0x0000
STR 2
LOD 3
STR 1
LOD 7
STR 1
IDE_DRIVER.WPtr3:
LOD 0x0000
STR 2
LOD 3
STR 1
LOD 7
STR 1
IDE_DRIVER.WPtr4:
LOD 0x0000
STR 2
LOD 3
STR 1
LOD 11
ADD 11
LOD 3
ADD IDE_DRIVER.WPtr1[4]
STR IDE_DRIVER.WPtr4[4]
LOD 3
ADD IDE_DRIVER.WPtr1[3]
STR IDE_DRIVER.WPtr4[3]
LOD 3
ADD IDE_DRIVER.WPtr1[2]
STR IDE_DRIVER.WPtr4[2]
LOD 3
ADD IDE_DRIVER.WPtr1[1]
STR IDE_DRIVER.WPtr4[1]
LOD 7
STR 1
LOD 3
STR 1
LOD 7
STR 1
LOD 3
STR 1
LOD 7
STR 1
LOD 3
STR 1
LOD 7
STR 1
LOD 3
STR 1
LOD 11
ADD 11
LOD 3
ADD IDE_DRIVER.LoopCount[1]
STR IDE_DRIVER.LoopCount[1]
LOD 3
ADD IDE_DRIVER.LoopCount[0]
STR IDE_DRIVER.LoopCount[0]
LOD 3
ADD 3
STR macro[0]
LOD 3
ADD 3
LOD macro[0]
ADD 18
CXA 0
NND 4
NND 4
NND 18
JMP IDE_DRIVER.DoneWriteLoop
LOD 3
JMP IDE_DRIVER.WriteLoop
IDE_DRIVER.DoneWriteLoop:
IDE_DRIVER.CheckWriteLoop:
LOD 7
STR 1
LOD 18
STR 2
LOD 3
STR 1
LOD 11
STR 1
LOD 3
STR 1
LOD 11
STR 1
LOD 3
STR 1
LOD 11
STR 1
LOD 3
STR 1
LOD 11
STR 1
LOD 3
STR 1
LOD 11
STR 1
LOD 3
STR 1
LOD 11
STR 1
LOD 3
STR 1
LOD 11
STR 1
LOD 2
STR IDE_DRIVER.Status[0]
LOD 3
STR 1
LOD 11
STR 1
LOD 2
STR IDE_DRIVER.Status[1]
LOD 3
STR 1
LOD IDE_DRIVER.Status[1]
ADD 11
LOD 3
ADD 3
STR macro[0]
LOD 3
ADD 3
LOD macro[0]
ADD 18
CXA 0
NND 4
NND 4
NND 18
JMP IDE_DRIVER.CheckWriteLoop
LOD 7
STR 1
LOD 18
STR 2
LOD 3
STR 1
LOD 11
STR 1
LOD 3
STR 1
LOD 11
STR 1
LOD 3
STR 1
LOD 11
STR 1
LOD 3
STR 1
LOD 11
STR 1
LOD 3
STR 1
LOD 11
STR 1
LOD 3
STR 1
LOD 11
STR 1
LOD 3
STR 1
LOD 11
STR 1
LOD 2
STR IDE_DRIVER.Status[0]
LOD 3
STR 1
LOD 11
STR 1
LOD 2
STR IDE_DRIVER.Status[1]
LOD 3
STR 1
IDE_DRIVER.Done:
LOD 3
STR 0
LOD 3
IDE_DRIVER.Exit:
JMP 0x0000
ADDRESS: D_SEC: .data 4 0d50000
SEC: .data 2 0x01
CYL: .data 4 0x0000
READ: .data 1 0x1
STAT: .data 2
IDE_DRIVER.Cyl: .data 4
IDE_DRIVER.ZeroToWrite: .data 1
IDE_DRIVER.RegTable: .data 5 0xABCDE
IDE_DRIVER.LocTable:
IDE_DRIVER.SecCount: .data 2 0x01
IDE_DRIVER.SecNum: .data 2
IDE_DRIVER.Cyl23: .data 2
IDE_DRIVER.Cyl01: .data 2
IDE_DRIVER.Head: .data 2 0xE0
IDE_DRIVER.DataPtr: .data 4
IDE_DRIVER.LoopCount: .data 2 0x0
IDE_DRIVER.LocationLoop: .data 1 0x0
IDE_DRIVER.Status: .data 2
macro: .data 1
