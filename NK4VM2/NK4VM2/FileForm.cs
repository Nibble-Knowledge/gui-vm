using System;
using System.IO;
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
    public partial class FileForm : Form
    {

        /// <summary>
        /// Tells the form that the file has been modified since open
        /// </summary>
        private bool fileChanged;

        /// <summary>
        /// Local reference to the messages text box in main window
        /// </summary>
        private TextBox messages;

        private UInt16[] mainMemory;

        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="text"></param>
        public FileForm(String text, TextBox textBox, UInt16[] mainMemory)
        {
            InitializeComponent();
            fileFormTextBox.Text = text;
            messages = textBox;
            this.mainMemory = mainMemory;
            messages.Text = "File opened!\r\n";
            fileChanged = false;
        }



        //--------------------------MENU BUTTONS-------------------------//

        private void openToolStripMenuItem_Click(object sender, EventArgs e)
        {
            DialogResult result = openFileDialog.ShowDialog(); // Show the dialog.
            if (result == DialogResult.OK) // Test result.
            {
                string file = openFileDialog.FileName;
                try
                {
                    string text = File.ReadAllText(file);
                    fileFormTextBox.Text = text;
                    this.Name = openFileDialog.FileName;
                    this.Text = openFileDialog.FileName;
                    fileChanged = false;
                }
                catch (IOException)
                {
                }
            }
        }

        private void saveToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Save_File();
        }

        private void macroToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Assemble_File(2);          
        }

        private void saveAsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            // Displays a SaveFileDialog so the user can save the file
            SaveFileDialog saveFileDialog = new SaveFileDialog();
            saveFileDialog.Filter = "Text|*.txt|Assembly|*.asm";
            saveFileDialog.Title = "Save File";
            saveFileDialog.FileName = this.Name;
            saveFileDialog.ShowDialog();

            // If the file name is not an empty string open it for saving.
            if (saveFileDialog.FileName != "")
            {
                File.WriteAllText(saveFileDialog.FileName, fileFormTextBox.Text);

            }
        }

        private void closeToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void lowLevelAssemblerToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Assemble_File(0);
        }





        //------------------------TEXT CHANGED LISTENERS------------------//

        private void fileFormTextBox_TextChanged(object sender, EventArgs e)
        {
            fileChanged = true;
        }






        //--------------------------------- FILE IO METHODS---------------------------------//

        /// <summary>
        /// Imports a binary file into the main memory array
        /// </summary>
        /// <param name="fileName"> The name of the binary file to import</param>
        public void Import_Binary(String fileName)
        {
            if (File.Exists(fileName))
            {
                using (BinaryReader reader = new BinaryReader(File.Open(fileName, FileMode.Open)))
                {
                    int count = int.Parse(baseAddressToolStripTextBox.Text);
                    byte temp;
                    while (reader.BaseStream.Position != reader.BaseStream.Length)
                    {
                        temp = reader.ReadByte();
                        mainMemory[count++] = (UInt16)((temp & 0xF0) >> 4);
                        mainMemory[count++] = (UInt16)(temp & 0xF);
                    }
                }
            }
        }

        public void Assemble_File(int level)
        {
            if (fileChanged)
            {
                DialogResult dialogResult = MessageBox.Show("Save File Before Assembling?", this.Name, MessageBoxButtons.YesNo);
                if (dialogResult == DialogResult.Yes)
                {
                    Save_File();
                }
            }

            try
            {
                if (this.Name == "")
                {
                    messages.Text = "Please enter a filename before assembling.\r\n";
                    return;
                }
                if (int.Parse(baseAddressToolStripTextBox.Text) < 0 || int.Parse(baseAddressToolStripTextBox.Text) > 65535)
                {
                    messages.Text = "Invalid base address.\r\n";
                }

                String fileName = this.Name;
                string fileOut;

                if (level > 1)
                {
                    //Use macro assembler:

                    fileOut = "Files/Cache/" + Path.GetFileNameWithoutExtension(fileName) + "MacroOut.asm";
                    var p = new System.Diagnostics.Process();
                    p.StartInfo.FileName = "_macro/mac4.exe";
                    p.StartInfo.Arguments = " " + fileName + " " + fileOut;
                    p.StartInfo.UseShellExecute = false;
                    p.StartInfo.CreateNoWindow = true;
                    p.Start();
                    p.WaitForExit();

                    //Use label replacer:
                    fileName = fileOut;
                    fileOut = "Files/Cache/" + Path.GetFileNameWithoutExtension(fileName) + "LROut.asm";
                    var q = new System.Diagnostics.Process();
                    q.StartInfo.FileName = "_lr4/lr4.exe";
                    q.StartInfo.Arguments = " " + "standard.def " + fileName + " " + fileOut;
                    q.StartInfo.UseShellExecute = false;
                    q.StartInfo.CreateNoWindow = true;
                    q.Start();
                    q.WaitForExit();

                    fileName = fileOut;
                }

                //Use low level assembler:
                fileOut = "Files/Bins/" + Path.GetFileNameWithoutExtension(this.Name) + ".bin";
                var s = new System.Diagnostics.Process();
                s.StartInfo.FileName = "as4.exe";
                s.StartInfo.Arguments = "-b " + baseAddressToolStripTextBox.Text + " " + fileName + " " + fileOut;
                s.StartInfo.UseShellExecute = false;
                s.StartInfo.CreateNoWindow = true;
                s.Start();
                s.WaitForExit();

                messages.Text = "";
                fileChanged = false;
                Import_Binary(fileOut);
                messages.Text = "Assembly Successful!\r\n";
            }
            catch (ArgumentException)
            {
                messages.Text = "Error while assembling please check your inputs.\r\n";
                return;
            }
            catch (Win32Exception)
            {
                messages.Text = "Cannot find one of the assembly files, please make sure they are all in the program directory.";
            }
        }

        public void Save_File()
        {
            File.WriteAllText(this.Name, fileFormTextBox.Text);
        }




    }

}
