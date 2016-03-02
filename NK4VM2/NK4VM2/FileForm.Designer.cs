namespace NK4VM2
{
    partial class FileForm
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
            this.fileFormTextBox = new System.Windows.Forms.TextBox();
            this.menuStrip = new System.Windows.Forms.MenuStrip();
            this.fileToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.openToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.saveToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.saveAsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.closeToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.compileToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.macroToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.lowLevelAssemblerToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.openFileDialog = new System.Windows.Forms.OpenFileDialog();
            this.saveFileDialog = new System.Windows.Forms.SaveFileDialog();
            this.baseAddressToolStripLabel = new System.Windows.Forms.ToolStripTextBox();
            this.baseAddressToolStripTextBox = new System.Windows.Forms.ToolStripTextBox();
            this.menuStrip.SuspendLayout();
            this.SuspendLayout();
            // 
            // fileFormTextBox
            // 
            this.fileFormTextBox.Dock = System.Windows.Forms.DockStyle.Fill;
            this.fileFormTextBox.Location = new System.Drawing.Point(0, 27);
            this.fileFormTextBox.Margin = new System.Windows.Forms.Padding(2);
            this.fileFormTextBox.Multiline = true;
            this.fileFormTextBox.Name = "fileFormTextBox";
            this.fileFormTextBox.ScrollBars = System.Windows.Forms.ScrollBars.Both;
            this.fileFormTextBox.Size = new System.Drawing.Size(316, 274);
            this.fileFormTextBox.TabIndex = 0;
            this.fileFormTextBox.TextChanged += new System.EventHandler(this.fileFormTextBox_TextChanged);
            // 
            // menuStrip
            // 
            this.menuStrip.AllowMerge = false;
            this.menuStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.fileToolStripMenuItem,
            this.compileToolStripMenuItem,
            this.baseAddressToolStripLabel,
            this.baseAddressToolStripTextBox});
            this.menuStrip.Location = new System.Drawing.Point(0, 0);
            this.menuStrip.Name = "menuStrip";
            this.menuStrip.ShowItemToolTips = true;
            this.menuStrip.Size = new System.Drawing.Size(316, 27);
            this.menuStrip.TabIndex = 1;
            this.menuStrip.Text = "menuStrip1";
            // 
            // fileToolStripMenuItem
            // 
            this.fileToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.openToolStripMenuItem,
            this.saveToolStripMenuItem,
            this.saveAsToolStripMenuItem,
            this.closeToolStripMenuItem});
            this.fileToolStripMenuItem.Name = "fileToolStripMenuItem";
            this.fileToolStripMenuItem.Size = new System.Drawing.Size(37, 23);
            this.fileToolStripMenuItem.Text = "File";
            // 
            // openToolStripMenuItem
            // 
            this.openToolStripMenuItem.Name = "openToolStripMenuItem";
            this.openToolStripMenuItem.Size = new System.Drawing.Size(112, 22);
            this.openToolStripMenuItem.Text = "Open";
            this.openToolStripMenuItem.Click += new System.EventHandler(this.openToolStripMenuItem_Click);
            // 
            // saveToolStripMenuItem
            // 
            this.saveToolStripMenuItem.Name = "saveToolStripMenuItem";
            this.saveToolStripMenuItem.Size = new System.Drawing.Size(112, 22);
            this.saveToolStripMenuItem.Text = "Save";
            this.saveToolStripMenuItem.Click += new System.EventHandler(this.saveToolStripMenuItem_Click);
            // 
            // saveAsToolStripMenuItem
            // 
            this.saveAsToolStripMenuItem.Name = "saveAsToolStripMenuItem";
            this.saveAsToolStripMenuItem.Size = new System.Drawing.Size(112, 22);
            this.saveAsToolStripMenuItem.Text = "Save as";
            this.saveAsToolStripMenuItem.Click += new System.EventHandler(this.saveAsToolStripMenuItem_Click);
            // 
            // closeToolStripMenuItem
            // 
            this.closeToolStripMenuItem.Name = "closeToolStripMenuItem";
            this.closeToolStripMenuItem.Size = new System.Drawing.Size(112, 22);
            this.closeToolStripMenuItem.Text = "Close";
            this.closeToolStripMenuItem.Click += new System.EventHandler(this.closeToolStripMenuItem_Click);
            // 
            // compileToolStripMenuItem
            // 
            this.compileToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.macroToolStripMenuItem,
            this.lowLevelAssemblerToolStripMenuItem});
            this.compileToolStripMenuItem.Name = "compileToolStripMenuItem";
            this.compileToolStripMenuItem.Size = new System.Drawing.Size(70, 23);
            this.compileToolStripMenuItem.Text = "Assemble";
            // 
            // macroToolStripMenuItem
            // 
            this.macroToolStripMenuItem.Name = "macroToolStripMenuItem";
            this.macroToolStripMenuItem.Size = new System.Drawing.Size(184, 22);
            this.macroToolStripMenuItem.Text = "Macro";
            this.macroToolStripMenuItem.Click += new System.EventHandler(this.macroToolStripMenuItem_Click);
            // 
            // lowLevelAssemblerToolStripMenuItem
            // 
            this.lowLevelAssemblerToolStripMenuItem.Name = "lowLevelAssemblerToolStripMenuItem";
            this.lowLevelAssemblerToolStripMenuItem.Size = new System.Drawing.Size(184, 22);
            this.lowLevelAssemblerToolStripMenuItem.Text = "Low Level Assembler";
            this.lowLevelAssemblerToolStripMenuItem.Click += new System.EventHandler(this.lowLevelAssemblerToolStripMenuItem_Click);
            // 
            // openFileDialog
            // 
            this.openFileDialog.DefaultExt = "asm, txt";
            this.openFileDialog.FileName = "myfile.asm";
            // 
            // baseAddressToolStripLabel
            // 
            this.baseAddressToolStripLabel.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.baseAddressToolStripLabel.Name = "baseAddressToolStripLabel";
            this.baseAddressToolStripLabel.ReadOnly = true;
            this.baseAddressToolStripLabel.Size = new System.Drawing.Size(80, 23);
            this.baseAddressToolStripLabel.Text = "Base Address:";
            // 
            // baseAddressToolStripTextBox
            // 
            this.baseAddressToolStripTextBox.Name = "baseAddressToolStripTextBox";
            this.baseAddressToolStripTextBox.Size = new System.Drawing.Size(50, 23);
            this.baseAddressToolStripTextBox.Text = "1024";
            // 
            // FileForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(316, 301);
            this.Controls.Add(this.fileFormTextBox);
            this.Controls.Add(this.menuStrip);
            this.Margin = new System.Windows.Forms.Padding(2);
            this.Name = "FileForm";
            this.Text = "FileForm";
            this.menuStrip.ResumeLayout(false);
            this.menuStrip.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox fileFormTextBox;
        private System.Windows.Forms.MenuStrip menuStrip;
        private System.Windows.Forms.ToolStripMenuItem fileToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem saveToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem openToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem closeToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem compileToolStripMenuItem;
        private System.Windows.Forms.OpenFileDialog openFileDialog;
        private System.Windows.Forms.ToolStripMenuItem macroToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem lowLevelAssemblerToolStripMenuItem;
        private System.Windows.Forms.SaveFileDialog saveFileDialog;
        private System.Windows.Forms.ToolStripMenuItem saveAsToolStripMenuItem;
        private System.Windows.Forms.ToolStripTextBox baseAddressToolStripLabel;
        private System.Windows.Forms.ToolStripTextBox baseAddressToolStripTextBox;
    }
}