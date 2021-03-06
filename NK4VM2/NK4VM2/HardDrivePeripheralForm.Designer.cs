﻿namespace NK4VM2
{
    partial class HardDrivePeripheralForm
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
			this.hardDriveStateTextBox = new System.Windows.Forms.TextBox();
			this.stopThreadButton = new System.Windows.Forms.Button();
			this.label1 = new System.Windows.Forms.Label();
			this.hdRegisterListView = new System.Windows.Forms.ListView();
			this.columnHeader1 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
			this.columnHeader2 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
			this.interfaceRegisterListView = new System.Windows.Forms.ListView();
			this.columnHeader3 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
			this.columnHeader4 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
			this.SuspendLayout();
			// 
			// hardDriveStateTextBox
			// 
			this.hardDriveStateTextBox.Location = new System.Drawing.Point(81, 56);
			this.hardDriveStateTextBox.Name = "hardDriveStateTextBox";
			this.hardDriveStateTextBox.Size = new System.Drawing.Size(100, 26);
			this.hardDriveStateTextBox.TabIndex = 0;
			// 
			// stopThreadButton
			// 
			this.stopThreadButton.AutoSize = true;
			this.stopThreadButton.Location = new System.Drawing.Point(27, 12);
			this.stopThreadButton.Name = "stopThreadButton";
			this.stopThreadButton.Size = new System.Drawing.Size(75, 30);
			this.stopThreadButton.TabIndex = 1;
			this.stopThreadButton.Text = "Stop";
			this.stopThreadButton.UseVisualStyleBackColor = true;
			this.stopThreadButton.Click += new System.EventHandler(this.stopThreadButton_Click);
			// 
			// label1
			// 
			this.label1.AutoSize = true;
			this.label1.Location = new System.Drawing.Point(23, 56);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(52, 20);
			this.label1.TabIndex = 2;
			this.label1.Text = "State:";
			// 
			// hdRegisterListView
			// 
			this.hdRegisterListView.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnHeader1,
            this.columnHeader2});
			this.hdRegisterListView.Location = new System.Drawing.Point(27, 106);
			this.hdRegisterListView.Name = "hdRegisterListView";
			this.hdRegisterListView.Size = new System.Drawing.Size(237, 277);
			this.hdRegisterListView.TabIndex = 3;
			this.hdRegisterListView.UseCompatibleStateImageBehavior = false;
			this.hdRegisterListView.View = System.Windows.Forms.View.Details;
			// 
			// columnHeader1
			// 
			this.columnHeader1.Text = "HD Register:";
			this.columnHeader1.Width = 110;
			// 
			// columnHeader2
			// 
			this.columnHeader2.Text = "Value:";
			this.columnHeader2.Width = 80;
			// 
			// interfaceRegisterListView
			// 
			this.interfaceRegisterListView.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnHeader3,
            this.columnHeader4});
			this.interfaceRegisterListView.Location = new System.Drawing.Point(312, 106);
			this.interfaceRegisterListView.Name = "interfaceRegisterListView";
			this.interfaceRegisterListView.Size = new System.Drawing.Size(235, 277);
			this.interfaceRegisterListView.TabIndex = 4;
			this.interfaceRegisterListView.UseCompatibleStateImageBehavior = false;
			this.interfaceRegisterListView.View = System.Windows.Forms.View.Details;
			// 
			// columnHeader3
			// 
			this.columnHeader3.Text = "Intfc Register:";
			this.columnHeader3.Width = 100;
			// 
			// columnHeader4
			// 
			this.columnHeader4.Text = "Value:";
			this.columnHeader4.Width = 80;
			// 
			// HardDrivePeripheralForm
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(559, 405);
			this.Controls.Add(this.interfaceRegisterListView);
			this.Controls.Add(this.hdRegisterListView);
			this.Controls.Add(this.label1);
			this.Controls.Add(this.stopThreadButton);
			this.Controls.Add(this.hardDriveStateTextBox);
			this.Name = "HardDrivePeripheralForm";
			this.Text = "HardDrivePeripheral";
			this.ResumeLayout(false);
			this.PerformLayout();

        }

        #endregion

		private System.Windows.Forms.TextBox hardDriveStateTextBox;
		private System.Windows.Forms.Button stopThreadButton;
		private System.Windows.Forms.Label label1;
		private System.Windows.Forms.ListView hdRegisterListView;
		private System.Windows.Forms.ColumnHeader columnHeader1;
		private System.Windows.Forms.ColumnHeader columnHeader2;
		private System.Windows.Forms.ListView interfaceRegisterListView;
		private System.Windows.Forms.ColumnHeader columnHeader3;
		private System.Windows.Forms.ColumnHeader columnHeader4;
    }
}