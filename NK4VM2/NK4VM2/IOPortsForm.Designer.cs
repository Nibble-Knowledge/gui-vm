namespace NK4VM2
{
    partial class IOPortsForm
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
            this.ioPortsListView = new System.Windows.Forms.ListView();
            this.columnHeader1 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader2 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.SuspendLayout();
            // 
            // ioPortsListView
            // 
            this.ioPortsListView.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnHeader1,
            this.columnHeader2});
            this.ioPortsListView.Location = new System.Drawing.Point(32, 23);
            this.ioPortsListView.Name = "ioPortsListView";
            this.ioPortsListView.Size = new System.Drawing.Size(194, 93);
            this.ioPortsListView.TabIndex = 1;
            this.ioPortsListView.UseCompatibleStateImageBehavior = false;
            this.ioPortsListView.View = System.Windows.Forms.View.Details;
            // 
            // columnHeader1
            // 
            this.columnHeader1.Text = "IO";
            this.columnHeader1.Width = 100;
            // 
            // columnHeader2
            // 
            this.columnHeader2.Text = "Value";
            this.columnHeader2.Width = 85;
            // 
            // IOPortsForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(238, 128);
            this.Controls.Add(this.ioPortsListView);
            this.Name = "IOPortsForm";
            this.Text = "IOPorts";
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.ListView ioPortsListView;
        private System.Windows.Forms.ColumnHeader columnHeader1;
        private System.Windows.Forms.ColumnHeader columnHeader2;
    }
}