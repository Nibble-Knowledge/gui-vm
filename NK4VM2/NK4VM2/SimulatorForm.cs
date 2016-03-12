using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Threading;

namespace NK4VM2
{
    public partial class SimulatorForm : Form
    {
        /// <summary>
        /// Local reference to main memory
        /// </summary>
        private static UInt16[] mainMemory;

        /// <summary>
        /// Local reference to registers
        /// </summary>
        private static int[] registers; //A = 0, MEM = 1, STAT = 2, PC = 3 

        /// <summary>
        /// Next instruction to be run
        /// </summary>
        private static String nextInstruction;

        /// <summary>
        /// Instruction just run
        /// </summary>
        private static String currentInstruction;

        /// <summary>
        /// Used to reset PC on startup
        /// </summary>
        private static bool firstTime;

        /// <summary>
        /// Thread to run a program in the background
        /// </summary>
        private static Thread thread;

        /// <summary>
        /// Used to terminate thread
        /// </summary>
        private static bool shouldStop;

        /// <summary>
        /// Period for  program speed, Max = 15000, Min = 10
        /// </summary>
        private static int period;

        /// <summary>
        /// Local reference to messages view
        /// </summary>
        private TextBox messages;

        /// <summary>
        /// Local reference to IO form
        /// </summary>
        private IOPortsForm ioPortsForm;

        /// <summary>
        /// Local reference to Register form
        /// </summary>
        private RegisterForm registerForm;

        /// <summary>
        /// Local reference to memory form
        /// </summary>
        private MemoryForm memoryForm;

		/// <summary>
		/// Local reference to the bus form
		/// </summary>
		private BusForm busForm;

        /// <summary>
        /// Handles decoding and fetching of instructions
        /// </summary>
        private Instruction instructionWorker;

        /// <summary>
        /// Allows for cross threaded use of a text box
        /// </summary>
        /// <param name="text"></param>
        /// <param name="textBox"></param>
        delegate void SetTextCallback(string text, TextBox textBox);

        /// <summary>
        /// Allows for cross threaded use of adjusting the scroll bar on text box
        /// </summary>
        /// <param name="textBox"></param>
        delegate void SetScrollCallback(TextBox textBox);

        /// <summary>
        /// Class that handles instruction decoding and execution
        /// </summary>
        public class Instruction
        {
            public void Decode_Instruction(String inst, int address)
            {

                switch (inst)
                {
                    case "HLT":
                        registers[2] |= 0x2;
                        break;
                    case "LOD":
						if (registers[1] == 2)
						{
							registers[0] = (Bus.Get_Values())[0];
						}
						else
						{
							registers[0] = mainMemory[registers[1]];
						}
                        
                        break;
                    case "STR":

                        if (registers[1] == 1)
                        {
							mainMemory[registers[1]] &= 0x3;
							mainMemory[registers[1]]= (UInt16)(((UInt16)registers[0] & 0xC) | mainMemory[registers[1]]);
                        }
                        else
                        {
                            mainMemory[registers[1]] = (UInt16) registers[0];
                        }
						if (registers[1] < 3)
						{
							Bus.Update_Bus(mainMemory[2], mainMemory[1], mainMemory[0], 16);
							
						}

                        break;
                    case "ADD":
                        int temp1 = registers[0];
                        int temp2 = mainMemory[registers[1]];
                        int result = temp1 + temp2;
                        result += (registers[2] & 0x1);
                        registers[0] = result & 0xF;

                        //Set overflow bit
                        if (((temp1 & 0x8) == 0x8) && ((temp2 & 0x8) == 0x8) && ((result & 0x8) != 0x8))
                        {
                            registers[2] |= 0x8;
                            registers[2] ^= (result & 0x8);
                        }
                        else if (((temp1 & 0x8) != 0x8) && ((temp2 & 0x8) != 0x8) && ((result & 0x8) == 0x8))
                        {
                            registers[2] |= 0x8;
                            registers[2] ^= (result & 0x8);
                        }
                        else
                        {
                            registers[2] &= 0x7;
                            registers[2] ^= (result & 0x8);
                        }

                        //If there was a carry out
                        if ((result & 0x10) == 0x10)
                        {
                            registers[2] |= 0x1;
                        }
                        else
                        {
                            registers[2] &= 0xE;
                        }
                        break;
                    case "NOP":
                        break;
                    case "NND":
                        registers[0] &= mainMemory[registers[1]];
                        registers[0] = ~registers[0];
                        registers[0] &= 0xF;
                        break;
                    case "JMP":
                        if (registers[0] == 0)
                        {
                            registers[3] = registers[1];
                        }
                        break;
                    case "CXA":
                        registers[0] = registers[2];
                        break;
                    default:
                        registers[2] |= 0x2;
                        break;

                }
            }

            public void Fetch_Instruction()
            {
                if ((registers[2] & 0x2) == 0x2)
                {
                    return;
                }
                int currentInstructionCode = mainMemory[registers[3]++];
                String OPCode;
                String OPCodeNext;

                registers[1] = 0;
                registers[1] = (UInt16)(mainMemory[registers[3]++] << 12) | ((UInt16)registers[1]);
                registers[1] = (UInt16)(mainMemory[registers[3]++] << 8) | ((UInt16)registers[1]);
                registers[1] = (UInt16)(mainMemory[registers[3]++] << 4) | ((UInt16)registers[1]);
                registers[1] = (UInt16)(mainMemory[registers[3]++]) | ((UInt16)registers[1]);

                int nextInstructionCode = mainMemory[registers[3]];

                switch (currentInstructionCode)
                {
                    case 0:
                        OPCode = "HLT";
                        break;
                    case 1:
                        OPCode = "LOD";
                        break;
                    case 2:
                        OPCode = "STR";
                        break;
                    case 3:
                        OPCode = "ADD";
                        break;
                    case 4:
                        OPCode = "NOP";
                        break;
                    case 5:
                        OPCode = "NND";
                        break;
                    case 6:
                        OPCode = "JMP";
                        break;
                    case 7:
                        OPCode = "CXA";
                        break;
                    default:
                        OPCode = "HLT";
                        break;
                }

                int temp = 0;
                if (OPCode != "JMP" || ((OPCode == "JMP") && (registers[0] != 0)))
                {
                    temp = (UInt16)(mainMemory[registers[3] + 1] << 12) | (UInt16)temp;
                    temp = (UInt16)(mainMemory[registers[3] + 2] << 8) | (UInt16)temp;
                    temp = (UInt16)(mainMemory[registers[3] + 3] << 4) | (UInt16)temp;
                    temp = (UInt16)(mainMemory[registers[3] + 4]) | (UInt16)temp;
                }
                else
                {
                    nextInstructionCode = mainMemory[registers[1]];
                    temp = (UInt16)(mainMemory[registers[1] + 1] << 12) | (UInt16)temp;
                    temp = (UInt16)(mainMemory[registers[1] + 2] << 8) | (UInt16)temp;
                    temp = (UInt16)(mainMemory[registers[1] + 3] << 4) | (UInt16)temp;
                    temp = (UInt16)(mainMemory[registers[1] + 4]) | (UInt16)temp;
                }

                switch (nextInstructionCode)
                {
                    case 0:
                        OPCodeNext = "HLT";
                        break;
                    case 1:
                        OPCodeNext = "LOD";
                        break;
                    case 2:
                        OPCodeNext = "STR";
                        break;
                    case 3:
                        OPCodeNext = "ADD";
                        break;
                    case 4:
                        OPCodeNext = "NOP";
                        break;
                    case 5:
                        OPCodeNext = "NND";
                        break;
                    case 6:
                        OPCodeNext = "JMP";
                        break;
                    case 7:
                        OPCodeNext = "CXA";
                        break;
                    default:
                        OPCodeNext = "HLT";
                        break;
                }

                nextInstruction = OPCodeNext + "\t";
                nextInstruction += temp.ToString();
                currentInstruction = OPCode + "\t";
                currentInstruction += registers[1].ToString();
                Decode_Instruction(OPCode, registers[1]);

            }

        }

        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="mem"></param>
        /// <param name="regs"></param>
        /// <param name="mes"></param>
        /// <param name="ioPortsForm"></param>
        /// <param name="registerForm"></param>
        /// <param name="memoryForm"></param>
        public SimulatorForm(UInt16[] mem, int[] regs, TextBox mes, IOPortsForm ioPortsForm, RegisterForm registerForm, MemoryForm memoryForm, BusForm busForm)
        {
            InitializeComponent();
			Update_References(ioPortsForm, registerForm, memoryForm, busForm);
            instructionWorker = new Instruction();
            messages = mes;
            mainMemory = mem;
            registers = regs;
            firstTime = true;
            shouldStop = false;
            period = int.Parse(periodToolStripTextBox.Text);
        }




        //----------------------------MENU LISTENERS-----------------------//


        private void restartToolStripButton_Click(object sender, EventArgs e)
        {
            shouldStop = true;
            if (thread != null)
            {
                thread.Join();
            }
            SetText("", previousInstructionTextBox);
            SetText("", nextInstructionTextBox);
            firstTime = true;
            registers[0] = 0;
            registers[1] = 0;
            registers[2] = 0;
            registers[3] = int.Parse(startToolStripTextBox.Text);
            if (ioPortsForm != null)
            {
                ioPortsForm.Update_IO();
            }
            if (registerForm != null)
            {
                registerForm.Update_Registers();
            }

        }

        private void runToolStripButton_Click(object sender, EventArgs e)
        {
            if (firstTime)
            {
                registers[3] = int.Parse(startToolStripTextBox.Text);
                firstTime = false;
            }
            thread = new Thread(run);
            try
            {
                if (int.Parse(startToolStripTextBox.Text) > 65535 || int.Parse(startToolStripTextBox.Text) < 19)
                {
                    messages.Text = "Invalid starting location. \r\n";
                    return;
                }
            }
            catch (OverflowException)
            {
                messages.Text = "Invalid starting location.\r\n";
                return;
            }
            catch (Exception)
            {
                messages.Text = "Invalid starting location";
                return;
            }
            thread.Start();
        }

        private void stopToolStripButton_Click(object sender, EventArgs e)
        {
            shouldStop = true;
        }

        private void stepToolStripButton_Click(object sender, EventArgs e)
        {
            try
            {
                //Make sure a program is not already running
                if (thread != null && thread.IsAlive)
                {
                    SetText(messages.Text + "CANNOT STEP WHILE RUNNING\r\n", messages);
                    return;
                }
                if (int.Parse(startToolStripTextBox.Text) > 65535 || int.Parse(startToolStripTextBox.Text) < 19)
                {
                    messages.Text = "Invalid starting location. \r\n";
                    return;
                }

                //Only set the PC on the first time the program is loaded
                if (firstTime)
                {
                    registers[3] = int.Parse(startToolStripTextBox.Text);
                    firstTime = false;
                }
                instructionWorker.Fetch_Instruction();
                if (ioPortsForm != null)
                {
                    ioPortsForm.Update_IO();
                }
                if (registerForm != null)
                {
                    registerForm.Update_Registers();
                }
				if (busForm != null)
				{
					busForm.Update_View();
				}
                SetText(currentInstruction, previousInstructionTextBox);
                SetText(nextInstruction, nextInstructionTextBox);
                Update_Messages();

            }
            catch (OverflowException)
            {
                messages.Text = "Invalid starting location.\r\n";
                return;
            }
 /*           catch (Exception ex)
            {
                messages.Text = ex.Message;
                return;
            }*/
        }

        private void periodToolStripTextBox_TextChanged(object sender, EventArgs e)
        {
            try
            {
                if (int.Parse(periodToolStripTextBox.Text) > 15000 || int.Parse(periodToolStripTextBox.Text) < 10)
                {
                    return;
                }
                period = int.Parse(periodToolStripTextBox.Text);
            }
            catch (Exception)
            {
            }


        }



        //-----------------------THREAD METHODS------------------------//

        /// <summary>
        /// Used to run program in background
        /// </summary>
        public void run()
        {
            
            shouldStop = false;
			Bus.Update_Bus(mainMemory[2], mainMemory[1], mainMemory[0], 16);

            while (!shouldStop && ((registers[2] & 0x2) != 0x2))
            {
                //Fetch instruction
                instructionWorker.Fetch_Instruction();
                Thread.Sleep(period);

				/*
                //Update the forms that are currently open
                if (ioPortsForm != null)
                {
                    ioPortsForm.Update_IO();
                }
                if (registerForm != null)
                {
                    registerForm.Update_Registers();
                }
				if (busForm != null)
				{
					busForm.Update_View();
				}
				 */
                //Update message window and instruction windows
                SetText(currentInstruction, previousInstructionTextBox);
                SetText(nextInstruction, nextInstructionTextBox);
                //Update_Messages();
				
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

        /// <summary>
        /// Allows for cross threaded access to auto scroll features of a textbox
        /// </summary>
        /// <param name="textBox"></param>
        private void SetScroll(TextBox textBox)
        {
            // InvokeRequired required compares the thread ID of the
            // calling thread to the thread ID of the creating thread.
            // If these threads are different, it returns true.
            if (textBox.InvokeRequired)
            {
                SetScrollCallback d = new SetScrollCallback(SetScroll);
                this.Invoke(d, new object[] { textBox });
            }
            else
            {
                messages.SelectionStart = messages.Text.Length;
                messages.ScrollToCaret();
            }
        }

        /// <summary>
        /// Prints new messages to the messages window
        /// </summary>
        private void Update_Messages()
        {
            if ((registers[2] & 0x2) == 0x2)
            {
                SetText(messages.Text + "COMPUTER HALTED\r\n", messages);
            }
            if (currentInstruction.Substring(0, 3) == "STR")
            {
                SetText(messages.Text + "Memory at Address: " + registers[1].ToString() + " changed to: 0x" + registers[0].ToString("X") + "\r\n", messages);
            }
            if ((currentInstruction.Substring(0, 3) == "NOP") && (registers[1] == 1000))
            {
                SetText(messages.Text + "BREAKPOINT at Address: " + registers[3] + "\r\n", messages);
                shouldStop = true;
            }
            SetScroll(messages);
        }


          /// <summary> 
         /// Updates local references incase new windows have been opened 
         /// </summary> 
         /// <param name="ioPortsForm"></param> 
         /// <param name="registerForm"></param> 
         /// <param name="memoryForm"></param> 
         public void Update_References(IOPortsForm ioPortsForm, RegisterForm registerForm, MemoryForm memoryForm, BusForm busForm) 
         { 
             this.ioPortsForm = ioPortsForm; 
             this.registerForm = registerForm; 
             this.memoryForm = memoryForm;
			 this.busForm = busForm;
         } 



    }
}
