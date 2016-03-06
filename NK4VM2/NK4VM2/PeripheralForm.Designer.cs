namespace NK4VM2
{
    partial class PeripheralForm
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
            this.PeripheralList = new System.Windows.Forms.ListBox();
            this.SuspendLayout();
            // 
            // PeripheralList
            // 
            this.PeripheralList.FormattingEnabled = true;
            this.PeripheralList.Location = new System.Drawing.Point(12, 12);
            this.PeripheralList.Name = "PeripheralList";
            this.PeripheralList.Size = new System.Drawing.Size(388, 394);
            this.PeripheralList.TabIndex = 0;
            // 
            // PeripheralForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(412, 420);
            this.Controls.Add(this.PeripheralList);
            this.Name = "PeripheralForm";
            this.Text = "PeripheralForm";
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.ListBox PeripheralList;
    }
}