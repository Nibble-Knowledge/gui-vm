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
    public partial class RegisterForm : Form
    {
        /// <summary>
        /// Local reference to the register array
        /// </summary>
        private int[] registers; //A = 0, MEM = 1, STAT = 2, PC = 3 

        /// <summary>
        /// Allows for cross threaded use of updating the register views
        /// </summary>
        delegate void UpdateRegistersCallback();

        public RegisterForm(int [] reg)
        {
            InitializeComponent();
            registers = reg;
            Update_Registers();
        }

        public void Update_Registers(){

            if (this.registerListView.InvokeRequired)
            {
                UpdateRegistersCallback d = new UpdateRegistersCallback(Update_Registers);
                this.Invoke(d, new object[] { });
            }
            else
            {
                registerListView.Items.Clear();
                registerListView.Items.Add("A");
                registerListView.Items.Add("MEM");
                registerListView.Items.Add("STAT");
                registerListView.Items.Add("PC");
                registerListView.Items[0].SubItems.Add(registers[0].ToString());
                registerListView.Items[1].SubItems.Add(registers[1].ToString());
                registerListView.Items[2].SubItems.Add(registers[2].ToString());
                registerListView.Items[3].SubItems.Add(registers[3].ToString());
            }




        }

    }
}
