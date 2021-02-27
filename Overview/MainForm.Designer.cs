namespace Overview
{
    partial class MainForm
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
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
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.CardControl = new Overview.CardControl();
            this.FreezeButton = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // CardControl
            // 
            this.CardControl.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.CardControl.BackColor = System.Drawing.SystemColors.Control;
            this.CardControl.Location = new System.Drawing.Point(14, 16);
            this.CardControl.Margin = new System.Windows.Forms.Padding(3, 5, 3, 5);
            this.CardControl.Name = "CardControl";
            this.CardControl.Size = new System.Drawing.Size(117, 312);
            this.CardControl.TabIndex = 0;
            // 
            // FreezeButton
            // 
            this.FreezeButton.Location = new System.Drawing.Point(357, 96);
            this.FreezeButton.Name = "FreezeButton";
            this.FreezeButton.Size = new System.Drawing.Size(94, 29);
            this.FreezeButton.TabIndex = 1;
            this.FreezeButton.Text = "Freeze";
            this.FreezeButton.UseVisualStyleBackColor = true;
            this.FreezeButton.Click += new System.EventHandler(this.FreezeButton_Click);
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(649, 355);
            this.Controls.Add(this.FreezeButton);
            this.Controls.Add(this.CardControl);
            this.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.Name = "MainForm";
            this.Text = "MainForm";
            this.ResumeLayout(false);

        }

        #endregion

        private CardControl CardControl;
        private System.Windows.Forms.Button FreezeButton;
    }
}

