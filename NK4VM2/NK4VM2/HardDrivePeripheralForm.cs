using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace NK4VM2
{

    public partial class HardDrivePeripheralForm : Form
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
		private static int id = 0;
		private static bool shouldStop;
		private FAT32HardDrive hd;


		/// <summary>
		/// Allows for cross threaded use of a text box
		/// </summary>
		/// <param name="text"></param>
		/// <param name="textBox"></param>
		delegate void SetTextCallback(string text, TextBox textBox);

		/// <summary>
		/// Allows for cross threaded use of updating the hd views
		/// </summary>
		delegate void UpdateViewCallback(ListView view);

		/// <summary>
		/// Inner class that contains the hard drive array
		/// </summary>
		private class FAT32HardDrive
		{
			public int[,]contents;

			public FAT32HardDrive()
			{
				contents = new int[1000,256];

				for (int i = 0; i < 1000; i++)
				{
					for (int j = 0; j < 256; j++)
					{
						contents[i, j] = 15;
					}
				}
			}
		}

        public HardDrivePeripheralForm()
        {
            InitializeComponent();
			hd = new FAT32HardDrive();
			
			hdRegisters = new int[16];
			interfaceRegisters = new int[5];

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

			hardDriveStateTextBox.Text = state.ToString();
			Update_View(hdRegisterListView);
			Update_View(interfaceRegisterListView);

			Thread thread = new Thread(run);
			thread.Start();
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
                if (CS == false)
                {
                    //While peripheral not selected, keep state at  2
                    state = 1;
					DIOR = true;
					DIOW = true;
                }
                switch (state)
                {
                    case 2:
                        interfaceRegisters[0] = dataIn;
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
                         
                        }
                        else if (!DIOW) //Writing to a hard drive register;
                        {
                            data = (interfaceRegisters[1] << 12) | (interfaceRegisters[2] << 8) | (interfaceRegisters[3] << 4) | interfaceRegisters[4];

                            //if the register being written to is the status register, don't overwrite it, just update values based on command
                            if (interfaceRegisters[0] == 0xF)
                            {
								data &= 0xFF;
                                if ((data == 0x0030) || (data == 0x0020))
                                {
                                    //This is a hard drive write/read command
                                    hdRegisters[0xF] |= 0x8;
                                    dataLeft = 256 * hdRegisters[0xA]; //There are 512 bytes of data in each sector, reg A is how many registers to transfer, each transfer
									dataLeft--; 						                     //sends 2 bytes at a time, therefore 256 transfers required per sector
                                }

                            } //A write to a sector has been started based on the 0x8 bit in status being on, and the data register is selected
                            else if(((hdRegisters[0xF] & 0x8) == 0x8) && (interfaceRegisters[0] == 0x8)) //Data is being written to a sector
                            {
								hdRegisters[interfaceRegisters[0]] = data;
								AccessHD(dataLeft, true);
                                dataLeft--;

                                //If all the data has been transfered to the sector, update the data ready flag in status
                                if (dataLeft == -1)
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

                        break;
                    case 9:

                        break;
                    case 10:

						DIOR = true;
						DIOW = true;
                        break;
                    default:
                        break;
                }
                state++;
            }
            else //Rising edge
            {
                //State 7 is when the transfer actually happens, update the DIOR/DIOW to initiate transfer with hard drive
                if (state == 7)
                {
                    DIOR = !read;
                    DIOW = !write;

					if (!DIOR)
					{
						if (((hdRegisters[0xF] & 0x8) == 0x8) && (interfaceRegisters[0] == 0x8)) //Data is being read from a sector
						{
							AccessHD(dataLeft, false);
							dataLeft--;

							//If all the data has been transfered, turn off the data ready flag
							if (dataLeft == -1)
							{
								hdRegisters[0xF] &= 0x00F0;
							}
						}
						Bus.Update_Bus((hdRegisters[interfaceRegisters[0]] & 0xF000) >> 12, Bus.Get_Values()[1], Bus.Get_Values()[0], id);
					}
                }
				else if (state == 8)
				{
					if (!DIOR)
					{
						Bus.Update_Bus((hdRegisters[interfaceRegisters[0]] & 0x0F00) >> 8, Bus.Get_Values()[1], Bus.Get_Values()[0], id);   //Send the next 4 bits of data from the hard drive back to CPU
					}
				}
				else if (state == 9)
				{
					if (!DIOR)
					{
						Bus.Update_Bus((hdRegisters[interfaceRegisters[0]] & 0x00F0) >> 4, Bus.Get_Values()[1], Bus.Get_Values()[0], id);   //Send the next 4 bits of data from the hard drive back to CPU
					}
				}
				else if (state == 10)
				{
					if (!DIOR)
					{
						Bus.Update_Bus((hdRegisters[interfaceRegisters[0]] & 0x000F), Bus.Get_Values()[1], Bus.Get_Values()[0], id);  //Send the next 4 bits of data from the hard drive back to CPU
					}
					state = 1;
				}
            }

			Update_View(hdRegisterListView);
			Update_View(interfaceRegisterListView);
			SetText(state.ToString(), hardDriveStateTextBox);
        }

		/// <summary>
		/// Accesses the hard drive array and sets the data reg in the HD to the correct value
		/// </summary>
		/// <param name="address"></param>
		/// <param name="write"></param>
        public void AccessHD(int address, bool write)
        {
			int LBA = 0;
			LBA |= hdRegisters[0xB];
			LBA |= (hdRegisters[0xC] << 8);
			LBA |= (hdRegisters[0xD] << 16);
			LBA |= ((hdRegisters[0xE] & 0xF) << 24);

			if (write)
			{
				hd.contents[LBA, (256 - address)] = hdRegisters[0x8];
			}
			else
			{
				hdRegisters[0x8] = hd.contents[LBA, (255 - address)];
			}
        }


		//---------------------------------- THREADING METHODS------------------------------------//


		/// <summary>
		/// Basically attaches the hard drive to the bus and updates when needed
		/// </summary>
		public void run()
		{
			int [] prevValues = Bus.Get_Values();
			int[] newValues;
			shouldStop = false;
			bool r, w, cs;

			while (!shouldStop)
			{
				newValues = Bus.Get_Values(); 
				if (newValues[1] != prevValues[1])
				{
					if((newValues[1] & 0x8) != 0){
						r = true;
					}
					else
					{
						r = false;
					}
					if((newValues[1] & 0x4) != 0)
					{
						w = true;
					}
					else
					{
						w = false;
					}
					if ((newValues[2]) == id)
					{
						cs = true;
					}
					else
					{
						cs = false;
					}

					Thread.Sleep(1);
					prevValues = newValues;
					edgeDetector(r, w, cs, newValues[0]);
				}
			}
		}

		/// <summary>
		/// Allows for cross threaded access to a text box
		/// </summary>
		/// <param name="text"></param>
		/// <param name="textBox"></param>
		private void SetText(string text, TextBox textBox)
		{
			// InvokeRequired required compares the thread ID of the
			// calling thread to the thread ID of the creating thread.
			// If these threads are different, it returns true.
			if (textBox.InvokeRequired)
			{
				SetTextCallback d = new SetTextCallback(SetText);
				this.Invoke(d, new object[] { text, textBox });
			}
			else
			{
				textBox.Text = text;
			}
		}

		private void stopThreadButton_Click(object sender, EventArgs e)
		{
			shouldStop = true;
		}

		public void Stop_Thread()
		{
			shouldStop = true;
		}

		/// <summary>
		/// Updates the views to show current information
		/// </summary>
		/// <param name="view"></param>
		public void Update_View(ListView view)
		{
			if (view.InvokeRequired)
			{
				UpdateViewCallback d = new UpdateViewCallback(Update_View);
				this.Invoke(d, new object[] {view});
			}
			else
			{
				if (view == hdRegisterListView)
				{
					view.Items.Clear();
					view.Items.Add("0x8: Data");
					view.Items.Add("0x9: Error");
					view.Items.Add("0xA: Sector Count");
					view.Items.Add("0xB: Sector Number");
					view.Items.Add("0xC: Cylinder Low");
					view.Items.Add("0xD: Cylinder High");
					view.Items.Add("0xE: Drive/Head");
					view.Items.Add("0xF: Status/Command");
					view.Items[0].SubItems.Add("0x" + hdRegisters[0x8].ToString("X"));
					view.Items[1].SubItems.Add("0x" + hdRegisters[0x9].ToString("X"));
					view.Items[2].SubItems.Add("0x" + hdRegisters[0xA].ToString("X"));
					view.Items[3].SubItems.Add("0x" + hdRegisters[0xB].ToString("X"));
					view.Items[4].SubItems.Add("0x" + hdRegisters[0xC].ToString("X"));
					view.Items[5].SubItems.Add("0x" + hdRegisters[0xD].ToString("X"));
					view.Items[6].SubItems.Add("0x" + hdRegisters[0xE].ToString("X"));
					view.Items[7].SubItems.Add("0x" + hdRegisters[0xF].ToString("X"));

				}
				else if (view == interfaceRegisterListView)
				{
					view.Items.Clear();
					view.Items.Add("Address");
					view.Items.Add("Data High");
					view.Items.Add("Data Mid High");
					view.Items.Add("Data Mid Low");
					view.Items.Add("Data Low");
					view.Items.Add("DIOR");
					view.Items.Add("DIOW");
					view.Items[0].SubItems.Add("0x" + interfaceRegisters[0].ToString("X"));
					view.Items[1].SubItems.Add("0x" + interfaceRegisters[1].ToString("X"));
					view.Items[2].SubItems.Add("0x" + interfaceRegisters[2].ToString("X"));
					view.Items[3].SubItems.Add("0x" + interfaceRegisters[3].ToString("X"));
					view.Items[4].SubItems.Add("0x" + interfaceRegisters[4].ToString("X"));
					view.Items[5].SubItems.Add(DIOR.ToString());
					view.Items[6].SubItems.Add(DIOW.ToString());
				}
			}
		}

    }
}
