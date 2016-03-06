using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace NK4VM2
{

    public partial class HardDrivePeripheral : Form
    {
        /// <summary>
        /// These are accessed with the same numbering as the real registers on hard drives: 
        /// Assuming a layout of: CS1FX CS3FX DA2 DA1 DA0:
        /// 0x8 - 16 bit Data transfer register
        /// 0x9 - 8 bit Error register
        /// 0xA -  8 bit Sector Count register
        /// 0xB - 8 bit Sector Number register (LBA 0 - 7)
        /// 0xC - 8 bit Cylinder Low register (LBA 8 - 15)
        /// 0xD - 8 bit Cylinder High register (LBA 16 - 23)
        /// 0xE - 8 bit Drive/Head register (LBA 24 - 27)
        /// 0xF - 8 bit Status/Command register
        /// </summary>
        private static int[] hdRegisters;

        private static int[] interfaceRegisters; // 0 is addr, 1 is data high, 2 is data mid high, 3 is data mid low, 4 is data low
        private static bool DIOR;
        private static bool DIOW;
        private static int state; // 2 is loading addr, 3 -6 is loading data, 7-10 is sending to HD
        private static int dataLeft;

        public HardDrivePeripheral()
        {
            InitializeComponent();

            ///Set all registers to 0, even though this may not be the case in real life
            for (int i = 8; i < 16; i++)
            {
                hdRegisters[i] = 0;
            }
            hdRegisters[15] = 0xFF50;
            for (int i = 0; i < 5; i++)
            {
                interfaceRegisters[i] = 0;
            }
            DIOR = true;
            DIOW = true;

            dataLeft = 0;
            //Start at a random state so that the programmer must reset before using
            state = 6;
        }

        /// <summary>
        /// Processes a falling/rising edge of read or write from the CPU bus. Simulates the IDE interface hardware
        /// </summary>
        public void edgeDetector(bool read, bool write, bool CS, int dataIn)
        {
            int data = 0;

            //If it is a falling edge
            if (!read && !write)
            {
                if (CS == true)
                {
                    //While peripheral not selected, keep state at  2
                    state = 2;
                }
                switch (state)
                {
                    case 2:
                        interfaceRegisters[0] = dataIn;
                        DIOR = true;
                        DIOR = true;
                        break;
                    case 3:
                        interfaceRegisters[1] = dataIn;
                        break;
                    case 4:
                        interfaceRegisters[2] = dataIn;
                        break;
                    case 5:
                        interfaceRegisters[3] = dataIn;
                        break;
                    case 6:
                        interfaceRegisters[4] = dataIn;
                        break;
                    case 7:
                        if (!DIOR)
                        {
                            dataIn = hdRegisters[interfaceRegisters[0]] & 0xF000;   //Send the first 4 bits of data from the hard drive back to CPU

                            if(((hdRegisters[0xF] & 0x8) == 0x8) && (interfaceRegisters[0] == 0x8)) //Data is being read from a sector
                            {
                                dataLeft--;

                                //If all the data has been transfered, turn off the data ready flag
                                if (dataLeft == 0)
                                {
                                    hdRegisters[0xF] &= 0x00F0;
                                }
                            }
                        }
                        else if (!DIOW) //Writing to a hard drive register;
                        {
                            data = (interfaceRegisters[1] << 12) & (interfaceRegisters[2] << 8) & (interfaceRegisters[3] << 4) & interfaceRegisters[4];

                            //if the register being written to is the status register, don't overwrite it, just update values based on command
                            if (interfaceRegisters[0] == 0xF)
                            {
                                if ((data == 0x0030) || (data == 0x0020))
                                {
                                    //This is a hard drive write/read command
                                    hdRegisters[0xF] |= 0x8;
                                    dataLeft = 256 * hdRegisters[0xA]; //There are 512 bytes of data in each sector, reg A is how many registers to transfer, each transfer
                                                                                                    //sends 2 bytes at a time, therefore 256 transfers required per sector
                                }

                            } //A write to a sector has been started based on the 0x8 bit in status being on, and the data register is selected
                            else if(((hdRegisters[0xF] & 0x8) == 0x8) && (interfaceRegisters[0] == 0x8)) //Data is being written to a sector
                            {
                                dataLeft--;
                                hdRegisters[interfaceRegisters[0]] = data;

                                //If all the data has been transfered to the sector, update the data ready flag in status
                                if (dataLeft == 0)
                                {
                                    hdRegisters[0xF] &= 0x00F0;
                                }
                            }
                            else
                            {
                                // Update the register that is requested with the data sent
                                hdRegisters[interfaceRegisters[0]] = data;
                            }
                            
                           
                        }
                        break;
                    case 8:
                        if (!DIOR)
                        {
                            dataIn = hdRegisters[interfaceRegisters[0]] & 0x0F00;    //Send the next 4 bits of data from the hard drive back to CPU
                        }
                        break;
                    case 9:
                        if (!DIOR)
                        {
                            dataIn = hdRegisters[interfaceRegisters[0]] & 0x00F0;   //Send the next 4 bits of data from the hard drive back to CPU
                        }
                        break;
                    case 10:
                        if (!DIOR)
                        {
                            dataIn = hdRegisters[interfaceRegisters[0]] & 0x000F;   //Send the next 4 bits of data from the hard drive back to CPU
                        }
                            state = 2;
                        break;
                    default:
                        break;
                }
                state++;
            }
            else
            {
                //State 7 is when the transfer actually happens, update the DIOR/DIOW to initiate transfer with hard drive
                if (state == 7)
                {
                    DIOR = !read;
                    DIOW = !write;
                }
            }
            

        }


        public void accessHD()
        {

        }
    }
}
