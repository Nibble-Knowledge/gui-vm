namespace NK4VM2
{
    partial class SimulatorForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(SimulatorForm));
            this.toolStrip1 = new System.Windows.Forms.ToolStrip();
            this.toolStripLabel1 = new System.Windows.Forms.ToolStripLabel();
            this.periodToolStripTextBox = new System.Windows.Forms.ToolStripTextBox();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.toolStripLabel2 = new System.Windows.Forms.ToolStripLabel();
            this.startToolStripTextBox = new System.Windows.Forms.ToolStripTextBox();
            this.toolStripSeparator2 = new System.Windows.Forms.ToolStripSeparator();
            this.runToolStripButton = new System.Windows.Forms.ToolStripButton();
            this.stopToolStripButton = new System.Windows.Forms.ToolStripButton();
            this.stepToolStripButton = new System.Windows.Forms.ToolStripButton();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.previousInstructionTextBox = new System.Windows.Forms.TextBox();
            this.nextInstructionTextBox = new System.Windows.Forms.TextBox();
            this.restartToolStripButton = new System.Windows.Forms.ToolStripButton();
            this.toolStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // toolStrip1
            // 
            this.toolStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripLabel1,
            this.periodToolStripTextBox,
            this.toolStripSeparator1,
            this.toolStripLabel2,
            this.startToolStripTextBox,
            this.toolStripSeparator2,
            this.runToolStripButton,
            this.stopToolStripButton,
            this.stepToolStripButton,
            this.restartToolStripButton});
            this.toolStrip1.Location = new System.Drawing.Point(0, 0);
            this.toolStrip1.Name = "toolStrip1";
            this.toolStrip1.Size = new System.Drawing.Size(415, 25);
            this.toolStrip1.TabIndex = 0;
            this.toolStrip1.Text = "toolStrip1";
            // 
            // toolStripLabel1
            // 
            this.toolStripLabel1.Name = "toolStripLabel1";
            this.toolStripLabel1.Size = new System.Drawing.Size(44, 22);
            this.toolStripLabel1.Text = "Period:";
            // 
            // periodToolStripTextBox
            // 
            this.periodToolStripTextBox.MaxLength = 5;
            this.periodToolStripTextBox.Name = "periodToolStripTextBox";
            this.periodToolStripTextBox.Size = new System.Drawing.Size(60, 25);
            this.periodToolStripTextBox.Text = "1000";
            this.periodToolStripTextBox.TextChanged += new System.EventHandler(this.periodToolStripTextBox_TextChanged);
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(6, 25);
            // 
            // toolStripLabel2
            // 
            this.toolStripLabel2.Name = "toolStripLabel2";
            this.toolStripLabel2.Size = new System.Drawing.Size(34, 22);
            this.toolStripLabel2.Text = "Start:";
            // 
            // startToolStripTextBox
            // 
            this.startToolStripTextBox.MaxLength = 5;
            this.startToolStripTextBox.Name = "startToolStripTextBox";
            this.startToolStripTextBox.Size = new System.Drawing.Size(60, 25);
            this.startToolStripTextBox.Text = "1024";
            // 
            // toolStripSeparator2
            // 
            this.toolStripSeparator2.Name = "toolStripSeparator2";
            this.toolStripSeparator2.Size = new System.Drawing.Size(6, 25);
            // 
            // runToolStripButton
            // 
            this.runToolStripButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.runToolStripButton.Image = ((System.Drawing.Image)(resources.GetObject("runToolStripButton.Image")));
            this.runToolStripButton.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.runToolStripButton.Name = "runToolStripButton";
            this.runToolStripButton.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.runToolStripButton.Size = new System.Drawing.Size(23, 22);
            this.runToolStripButton.Text = "Run";
            this.runToolStripButton.Click += new System.EventHandler(this.runToolStripButton_Click);
            // 
            // stopToolStripButton
            // 
            this.stopToolStripButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.stopToolStripButton.Image = ((System.Drawing.Image)(resources.GetObject("stopToolStripButton.Image")));
            this.stopToolStripButton.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.stopToolStripButton.Name = "stopToolStripButton";
            this.stopToolStripButton.Size = new System.Drawing.Size(23, 22);
            this.stopToolStripButton.Text = "Stop";
            this.stopToolStripButton.ToolTipText = "Stop";
            this.stopToolStripButton.Click += new System.EventHandler(this.stopToolStripButton_Click);
            // 
            // stepToolStripButton
            // 
            this.stepToolStripButton.AutoSize = false;
            this.stepToolStripButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.stepToolStripButton.Image = ((System.Drawing.Image)(resources.GetObject("stepToolStripButton.Image")));
            this.stepToolStripButton.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.stepToolStripButton.Name = "stepToolStripButton";
            this.stepToolStripButton.Size = new System.Drawing.Size(30, 22);
            this.stepToolStripButton.Text = "toolStripButton3";
            this.stepToolStripButton.ToolTipText = "Step";
            this.stepToolStripButton.Click += new System.EventHandler(this.stepToolStripButton_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(13, 52);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(103, 13);
            this.label1.TabIndex = 1;
            this.label1.Text = "Previous Instruction:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(16, 97);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(84, 13);
            this.label2.TabIndex = 2;
            this.label2.Text = "Next Instruction:";
            // 
            // previousInstructionTextBox
            // 
            this.previousInstructionTextBox.Location = new System.Drawing.Point(16, 68);
            this.previousInstructionTextBox.Name = "previousInstructionTextBox";
            this.previousInstructionTextBox.Size = new System.Drawing.Size(100, 20);
            this.previousInstructionTextBox.TabIndex = 3;
            // 
            // nextInstructionTextBox
            // 
            this.nextInstructionTextBox.Location = new System.Drawing.Point(16, 114);
            this.nextInstructionTextBox.Name = "nextInstructionTextBox";
            this.nextInstructionTextBox.Size = new System.Drawing.Size(100, 20);
            this.nextInstructionTextBox.TabIndex = 4;
            // 
            // restartToolStripButton
            // 
            this.restartToolStripButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.restartToolStripButton.Image = ((System.Drawing.Image)(resources.GetObject("restartToolStripButton.Image")));
            this.restartToolStripButton.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.restartToolStripButton.Name = "restartToolStripButton";
            this.restartToolStripButton.Size = new System.Drawing.Size(47, 22);
            this.restartToolStripButton.Text = "Restart";
            this.restartToolStripButton.Click += new System.EventHandler(this.restartToolStripButton_Click);
            // 
            // SimulatorForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(415, 165);
            this.Controls.Add(this.nextInstructionTextBox);
            this.Controls.Add(this.previousInstructionTextBox);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.toolStrip1);
            this.Name = "SimulatorForm";
            this.Text = "SimulatorForm";
            this.toolStrip1.ResumeLayout(false);
            this.toolStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ToolStrip toolStrip1;
        private System.Windows.Forms.ToolStripButton runToolStripButton;
        private System.Windows.Forms.ToolStripLabel toolStripLabel1;
        private System.Windows.Forms.ToolStripTextBox periodToolStripTextBox;
        private System.Windows.Forms.ToolStripButton stopToolStripButton;
        private System.Windows.Forms.ToolStripButton stepToolStripButton;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.ToolStripLabel toolStripLabel2;
        private System.Windows.Forms.ToolStripTextBox startToolStripTextBox;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox previousInstructionTextBox;
        private System.Windows.Forms.TextBox nextInstructionTextBox;
        private System.Windows.Forms.ToolStripButton restartToolStripButton;
    }
}