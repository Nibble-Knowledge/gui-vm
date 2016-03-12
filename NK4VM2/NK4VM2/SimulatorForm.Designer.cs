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
			this.restartToolStripButton = new System.Windows.Forms.ToolStripButton();
			this.label1 = new System.Windows.Forms.Label();
			this.label2 = new System.Windows.Forms.Label();
			this.previousInstructionTextBox = new System.Windows.Forms.TextBox();
			this.nextInstructionTextBox = new System.Windows.Forms.TextBox();
			this.statusStrip1 = new System.Windows.Forms.StatusStrip();
			this.printMessagesCheckBox = new System.Windows.Forms.CheckBox();
			this.updateFormsCheckBox = new System.Windows.Forms.CheckBox();
			this.toolStrip1.SuspendLayout();
			this.SuspendLayout();
			// 
			// toolStrip1
			// 
			this.toolStrip1.ImageScalingSize = new System.Drawing.Size(24, 24);
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
			this.toolStrip1.Padding = new System.Windows.Forms.Padding(0, 0, 2, 0);
			this.toolStrip1.Size = new System.Drawing.Size(622, 32);
			this.toolStrip1.TabIndex = 0;
			this.toolStrip1.Text = "toolStrip1";
			// 
			// toolStripLabel1
			// 
			this.toolStripLabel1.Name = "toolStripLabel1";
			this.toolStripLabel1.Size = new System.Drawing.Size(66, 29);
			this.toolStripLabel1.Text = "Period:";
			// 
			// periodToolStripTextBox
			// 
			this.periodToolStripTextBox.MaxLength = 5;
			this.periodToolStripTextBox.Name = "periodToolStripTextBox";
			this.periodToolStripTextBox.Size = new System.Drawing.Size(88, 32);
			this.periodToolStripTextBox.Text = "1000";
			this.periodToolStripTextBox.TextChanged += new System.EventHandler(this.periodToolStripTextBox_TextChanged);
			// 
			// toolStripSeparator1
			// 
			this.toolStripSeparator1.Name = "toolStripSeparator1";
			this.toolStripSeparator1.Size = new System.Drawing.Size(6, 32);
			// 
			// toolStripLabel2
			// 
			this.toolStripLabel2.Name = "toolStripLabel2";
			this.toolStripLabel2.Size = new System.Drawing.Size(52, 29);
			this.toolStripLabel2.Text = "Start:";
			// 
			// startToolStripTextBox
			// 
			this.startToolStripTextBox.MaxLength = 5;
			this.startToolStripTextBox.Name = "startToolStripTextBox";
			this.startToolStripTextBox.Size = new System.Drawing.Size(88, 32);
			this.startToolStripTextBox.Text = "1024";
			// 
			// toolStripSeparator2
			// 
			this.toolStripSeparator2.Name = "toolStripSeparator2";
			this.toolStripSeparator2.Size = new System.Drawing.Size(6, 32);
			// 
			// runToolStripButton
			// 
			this.runToolStripButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
			this.runToolStripButton.Image = ((System.Drawing.Image)(resources.GetObject("runToolStripButton.Image")));
			this.runToolStripButton.ImageTransparentColor = System.Drawing.Color.Magenta;
			this.runToolStripButton.Name = "runToolStripButton";
			this.runToolStripButton.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
			this.runToolStripButton.Size = new System.Drawing.Size(28, 29);
			this.runToolStripButton.Text = "Run";
			this.runToolStripButton.Click += new System.EventHandler(this.runToolStripButton_Click);
			// 
			// stopToolStripButton
			// 
			this.stopToolStripButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
			this.stopToolStripButton.Image = ((System.Drawing.Image)(resources.GetObject("stopToolStripButton.Image")));
			this.stopToolStripButton.ImageTransparentColor = System.Drawing.Color.Magenta;
			this.stopToolStripButton.Name = "stopToolStripButton";
			this.stopToolStripButton.Size = new System.Drawing.Size(28, 29);
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
			// restartToolStripButton
			// 
			this.restartToolStripButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
			this.restartToolStripButton.Image = ((System.Drawing.Image)(resources.GetObject("restartToolStripButton.Image")));
			this.restartToolStripButton.ImageTransparentColor = System.Drawing.Color.Magenta;
			this.restartToolStripButton.Name = "restartToolStripButton";
			this.restartToolStripButton.Size = new System.Drawing.Size(70, 29);
			this.restartToolStripButton.Text = "Restart";
			this.restartToolStripButton.Click += new System.EventHandler(this.restartToolStripButton_Click);
			// 
			// label1
			// 
			this.label1.AutoSize = true;
			this.label1.Location = new System.Drawing.Point(20, 80);
			this.label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(152, 20);
			this.label1.TabIndex = 1;
			this.label1.Text = "Previous Instruction:";
			// 
			// label2
			// 
			this.label2.AutoSize = true;
			this.label2.Location = new System.Drawing.Point(24, 149);
			this.label2.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
			this.label2.Name = "label2";
			this.label2.Size = new System.Drawing.Size(124, 20);
			this.label2.TabIndex = 2;
			this.label2.Text = "Next Instruction:";
			// 
			// previousInstructionTextBox
			// 
			this.previousInstructionTextBox.Location = new System.Drawing.Point(24, 105);
			this.previousInstructionTextBox.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
			this.previousInstructionTextBox.Name = "previousInstructionTextBox";
			this.previousInstructionTextBox.Size = new System.Drawing.Size(148, 26);
			this.previousInstructionTextBox.TabIndex = 3;
			// 
			// nextInstructionTextBox
			// 
			this.nextInstructionTextBox.Location = new System.Drawing.Point(24, 175);
			this.nextInstructionTextBox.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
			this.nextInstructionTextBox.Name = "nextInstructionTextBox";
			this.nextInstructionTextBox.Size = new System.Drawing.Size(148, 26);
			this.nextInstructionTextBox.TabIndex = 4;
			// 
			// statusStrip1
			// 
			this.statusStrip1.ImageScalingSize = new System.Drawing.Size(24, 24);
			this.statusStrip1.Location = new System.Drawing.Point(0, 232);
			this.statusStrip1.Name = "statusStrip1";
			this.statusStrip1.Size = new System.Drawing.Size(622, 22);
			this.statusStrip1.TabIndex = 5;
			this.statusStrip1.Text = "statusStrip1";
			// 
			// printMessagesCheckBox
			// 
			this.printMessagesCheckBox.AutoSize = true;
			this.printMessagesCheckBox.Location = new System.Drawing.Point(279, 90);
			this.printMessagesCheckBox.Name = "printMessagesCheckBox";
			this.printMessagesCheckBox.Size = new System.Drawing.Size(264, 24);
			this.printMessagesCheckBox.TabIndex = 7;
			this.printMessagesCheckBox.Text = "Print Memory Change Messages";
			this.printMessagesCheckBox.UseVisualStyleBackColor = true;
			// 
			// updateFormsCheckBox
			// 
			this.updateFormsCheckBox.AutoSize = true;
			this.updateFormsCheckBox.Location = new System.Drawing.Point(279, 144);
			this.updateFormsCheckBox.Name = "updateFormsCheckBox";
			this.updateFormsCheckBox.Size = new System.Drawing.Size(181, 24);
			this.updateFormsCheckBox.TabIndex = 8;
			this.updateFormsCheckBox.Text = "Update Other Forms";
			this.updateFormsCheckBox.UseVisualStyleBackColor = true;
			// 
			// SimulatorForm
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(622, 254);
			this.Controls.Add(this.updateFormsCheckBox);
			this.Controls.Add(this.printMessagesCheckBox);
			this.Controls.Add(this.statusStrip1);
			this.Controls.Add(this.nextInstructionTextBox);
			this.Controls.Add(this.previousInstructionTextBox);
			this.Controls.Add(this.label2);
			this.Controls.Add(this.label1);
			this.Controls.Add(this.toolStrip1);
			this.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
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
        private System.Windows.Forms.StatusStrip statusStrip1;
		private System.Windows.Forms.CheckBox printMessagesCheckBox;
		private System.Windows.Forms.CheckBox updateFormsCheckBox;
    }
}