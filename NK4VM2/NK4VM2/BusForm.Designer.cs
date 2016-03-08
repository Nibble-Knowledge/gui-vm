namespace NK4VM2
{
	partial class BusForm
	{
		/// <summary>
		/// Required designer variable.
		/// </summary>
		private System.ComponentModel.IContainer components = null;

		/// <summary>
		/// Clean up any resources being used.
		/// </summary>
		/// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
		protected override void Dispose(bool disposing)
		{
			if (disposing && (components != null))
			{
				components.Dispose();
			}
			base.Dispose(disposing);
		}

		#region Windows Form Designer generated code

		/// <summary>
		/// Required method for Designer support - do not modify
		/// the contents of this method with the code editor.
		/// </summary>
		private void InitializeComponent()
		{
			this.busFormListView = new System.Windows.Forms.ListView();
			this.busHeader = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
			this.columnHeader1 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
			this.SuspendLayout();
			// 
			// busFormListView
			// 
			this.busFormListView.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.busHeader,
            this.columnHeader1});
			this.busFormListView.Location = new System.Drawing.Point(42, 51);
			this.busFormListView.Name = "busFormListView";
			this.busFormListView.Size = new System.Drawing.Size(248, 232);
			this.busFormListView.TabIndex = 0;
			this.busFormListView.UseCompatibleStateImageBehavior = false;
			this.busFormListView.View = System.Windows.Forms.View.Details;
			// 
			// busHeader
			// 
			this.busHeader.Text = "Bus Item:";
			this.busHeader.Width = 100;
			// 
			// columnHeader1
			// 
			this.columnHeader1.Text = "Value:";
			this.columnHeader1.Width = 80;
			// 
			// BusForm
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(341, 349);
			this.Controls.Add(this.busFormListView);
			this.Name = "BusForm";
			this.Text = "BusForm";
			this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.BusForm_FormClosed);
			this.ResumeLayout(false);

		}

		#endregion

		private System.Windows.Forms.ListView busFormListView;
		private System.Windows.Forms.ColumnHeader busHeader;
		private System.Windows.Forms.ColumnHeader columnHeader1;
	}
}