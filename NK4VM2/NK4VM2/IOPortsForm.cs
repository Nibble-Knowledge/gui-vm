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
    public partial class IOPortsForm : Form
    {
        /// <summary>
        /// Local refence to main memory
        /// </summary>
        private UInt16[] memory;


        /// <summary>
        /// Used for cross threaded access to the IO window
        /// </summary>
        delegate void UpdateIOCallback();

        public IOPortsForm(UInt16 [] mem)
        {
            InitializeComponent();
            memory = mem;

            Update_IO();
        }

        /// <summary>
        /// Updates the contents of the IO window
        /// </summary>
        public void Update_IO()
        {
            if (this.ioPortsListView.InvokeRequired)
            {
                UpdateIOCallback d = new UpdateIOCallback(Update_IO);
                this.Invoke(d, new object[] { });
            }
            else
            {
                ioPortsListView.Items.Clear();
                ioPortsListView.Items.Add("Chip Select");
                ioPortsListView.Items.Add("Status Bus");
                ioPortsListView.Items.Add("Data Bus");
                ioPortsListView.Items[0].SubItems.Add(memory[0].ToString());
                ioPortsListView.Items[1].SubItems.Add(memory[1].ToString());
                ioPortsListView.Items[2].SubItems.Add(memory[2].ToString());
            }

        }

    }
}
