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
	public partial class BusForm : Form
	{
		private ListView view;

		/// <summary>
		/// Allows for cross threaded use of updating the bus views
		/// </summary>
		delegate void UpdateViewCallback();

		public BusForm()
		{
			InitializeComponent();
			view = busFormListView;
			Update_View();
		}


		public void Update_View()
		{
			if (this.view.InvokeRequired)
			{
				UpdateViewCallback ca = new UpdateViewCallback(Update_View);
				this.Invoke(ca, new object[] {});
			}
			else
			{
				int[] values =	Bus.Get_Values();
				view.Items.Clear();
				view.Items.Add("Chip Select");
				view.Items.Add("Status");
				view.Items.Add("Data");
				view.Items[0].SubItems.Add(values[2].ToString());
				view.Items[1].SubItems.Add(values[1].ToString());
				view.Items[2].SubItems.Add(values[0].ToString());

			}
		}

		private void BusForm_FormClosed(object sender, FormClosedEventArgs e)
		{
			this.Dispose();
		}
	}
}
