using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.IO;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;



namespace NK4VM2
{



    public partial class MainWindow : Form
    {

        public static TextBox messages;
        public static UInt16[] mainMemory;
        public static int[] registers; //A = 0, MEM = 1, STAT = 2, PC = 3
        public FileForm fileForm;
        public IOPortsForm ioPortsForm;
        public MemoryForm memoryForm;
        public RegisterForm registerForm;
        public SimulatorForm simulatorForm;

        public MainWindow()
        {
            InitializeComponent();

            messages = messagesTextBox;
            messagesTextBox.Height = this.ClientSize.Height / 4;
            mainMemory = new UInt16[65536];
            Reset_Memory();
            registers = new int[4];

            for (int i =  0; i <  4; i++)
            {
                registers[i] = 0;
            }

        }



        /// <summary>
        /// Resets memory to zeros, except for 0-15 at 3-18
        /// </summary>
        private void Reset_Memory()
        {
            for (int i = 0; i < 65536; i++)
            {
                if (i > 2 && i < 20)
                {
                    mainMemory[i] = (UInt16)(i -3);
                }
                else
                {
                    mainMemory[i] = 0;
                }
            }
        }



        //------------------------------ MENU OPTIONS-----------------------------//

        /// <summary>
        ///  Click listener for "Open" menu button
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void openToolStripMenuItem_Click(object sender, EventArgs e)
        {

            DialogResult result = openFileDialog.ShowDialog(); // Show the dialog.
            if (result == DialogResult.OK) // Test result.
            {
                string file = openFileDialog.FileName;
                try
                {
                    string text = File.ReadAllText(file);
                    if (fileForm == null)
                    {
                        fileForm = new FileForm(text, messages, mainMemory);
                        // Set the parent form of the child window.
                        fileForm.MdiParent = this;
                        // Display the new form.
                        fileForm.Text = openFileDialog.FileName;
                        fileForm.Name = openFileDialog.FileName;
                    }

                    fileForm.Show();
                }
                catch (IOException)
                {
                }
            }

        }

        private void memoryToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (memoryForm == null)
            {
                memoryForm = new MemoryForm();
                // Set the parent form of the child window.
                memoryForm.MdiParent = this;
                // Display the new form.
            }
            memoryForm.Show();

            //Show memory contents
            memoryForm.Update_Memory(mainMemory);
            if (simulatorForm != null)
            {
                simulatorForm.Update_References(ioPortsForm, registerForm, memoryForm);
            }
        }

        private void registersToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (registerForm == null)
            {
                registerForm = new RegisterForm(registers);

                // Set the parent form of the child window.
                registerForm.MdiParent = this;
                // Display the new form.
                registerForm.Text = "Registers";
            }

            registerForm.Show();

            if (simulatorForm != null)
            {
                simulatorForm.Update_References(ioPortsForm, registerForm, memoryForm);
            }

        }

        private void iOPortsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (ioPortsForm == null)
            {
                ioPortsForm = new IOPortsForm(mainMemory);

                // Set the parent form of the child window.
                ioPortsForm.MdiParent = this;
                // Display the new form.
                ioPortsForm.Text = "IO Ports";
            }

            ioPortsForm.Show();

            if (simulatorForm != null)
            {
                simulatorForm.Update_References(ioPortsForm, registerForm, memoryForm);
            }
        }

        private void simulatorToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (simulatorForm == null)
            {
                simulatorForm = new SimulatorForm(mainMemory, registers, messages, ioPortsForm, registerForm, memoryForm);

                // Set the parent form of the child window.
                simulatorForm.MdiParent = this;
                // Display the new form.
                simulatorForm.Text = "Simulator";
            }

            simulatorForm.Show();
        }

        private void openAllToolStripMenuItem_Click(object sender, EventArgs e)
        {
            memoryToolStripMenuItem_Click(sender, e);
            registersToolStripMenuItem_Click(sender, e);
            iOPortsToolStripMenuItem_Click(sender, e);
            simulatorToolStripMenuItem_Click(sender, e);
        }



        //--------------------------- RESIZE LISTENERS---------------------------//

        /// <summary>
        /// Updates Layout size of elements in main screen
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void MainWindow_ClientSizeChanged(object sender, EventArgs e)
        {
            messagesTextBox.Height = this.ClientSize.Height / 4;
        }



    }
}

