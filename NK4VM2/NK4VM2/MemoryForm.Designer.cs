namespace NK4VM2
{
    partial class MemoryForm
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
            this.memoryListView = new System.Windows.Forms.ListView();
            this.contents = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.toolStrip1 = new System.Windows.Forms.ToolStrip();
            this.toolStripLabel1 = new System.Windows.Forms.ToolStripLabel();
            this.minToolStripTextBox = new System.Windows.Forms.ToolStripTextBox();
            this.toolStripLabel2 = new System.Windows.Forms.ToolStripLabel();
            this.maxToolStripTextBox = new System.Windows.Forms.ToolStripTextBox();
            this.refreshToolStripButton = new System.Windows.Forms.ToolStripButton();
            this.toolStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // memoryListView
            // 
            this.memoryListView.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.contents});
            this.memoryListView.Dock = System.Windows.Forms.DockStyle.Fill;
            this.memoryListView.GridLines = true;
            this.memoryListView.Location = new System.Drawing.Point(0, 0);
            this.memoryListView.Margin = new System.Windows.Forms.Padding(2);
            this.memoryListView.Name = "memoryListView";
            this.memoryListView.Size = new System.Drawing.Size(262, 381);
            this.memoryListView.TabIndex = 0;
            this.memoryListView.UseCompatibleStateImageBehavior = false;
            this.memoryListView.View = System.Windows.Forms.View.Details;
            // 
            // contents
            // 
            this.contents.Text = "Memory Contents:";
            this.contents.Width = 371;
            // 
            // toolStrip1
            // 
            this.toolStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripLabel1,
            this.minToolStripTextBox,
            this.toolStripLabel2,
            this.maxToolStripTextBox,
            this.refreshToolStripButton});
            this.toolStrip1.Location = new System.Drawing.Point(0, 0);
            this.toolStrip1.Name = "toolStrip1";
            this.toolStrip1.Size = new System.Drawing.Size(262, 25);
            this.toolStrip1.TabIndex = 1;
            this.toolStrip1.Text = "toolStrip1";
            // 
            // toolStripLabel1
            // 
            this.toolStripLabel1.Name = "toolStripLabel1";
            this.toolStripLabel1.Size = new System.Drawing.Size(28, 22);
            this.toolStripLabel1.Text = "Min";
            // 
            // minToolStripTextBox
            // 
            this.minToolStripTextBox.Name = "minToolStripTextBox";
            this.minToolStripTextBox.Size = new System.Drawing.Size(50, 25);
            this.minToolStripTextBox.Text = "1024";
            // 
            // toolStripLabel2
            // 
            this.toolStripLabel2.Name = "toolStripLabel2";
            this.toolStripLabel2.Size = new System.Drawing.Size(29, 22);
            this.toolStripLabel2.Text = "Max";
            // 
            // maxToolStripTextBox
            // 
            this.maxToolStripTextBox.Name = "maxToolStripTextBox";
            this.maxToolStripTextBox.Size = new System.Drawing.Size(50, 25);
            this.maxToolStripTextBox.Text = "1054";
            // 
            // refreshToolStripButton
            // 
            this.refreshToolStripButton.BackColor = System.Drawing.SystemColors.ButtonFace;
            this.refreshToolStripButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.refreshToolStripButton.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.refreshToolStripButton.Name = "refreshToolStripButton";
            this.refreshToolStripButton.Size = new System.Drawing.Size(50, 22);
            this.refreshToolStripButton.Text = "Refresh";
            this.refreshToolStripButton.Click += new System.EventHandler(this.refreshToolStripButton_Click);
            // 
            // MemoryForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(262, 381);
            this.Controls.Add(this.toolStrip1);
            this.Controls.Add(this.memoryListView);
            this.Margin = new System.Windows.Forms.Padding(2);
            this.Name = "MemoryForm";
            this.Text = "MemoryForm";
            this.toolStrip1.ResumeLayout(false);
            this.toolStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ListView memoryListView;
        private System.Windows.Forms.ToolStrip toolStrip1;
        private System.Windows.Forms.ToolStripLabel toolStripLabel1;
        private System.Windows.Forms.ToolStripTextBox minToolStripTextBox;
        private System.Windows.Forms.ToolStripLabel toolStripLabel2;
        private System.Windows.Forms.ToolStripTextBox maxToolStripTextBox;
        private System.Windows.Forms.ToolStripButton refreshToolStripButton;
        private System.Windows.Forms.ColumnHeader contents;

    }
}