
namespace AsyncForms
{
    partial class Main
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
            this.RunTaskButton = new System.Windows.Forms.Button();
            this.TaskResultLabel = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // RunTaskButton
            // 
            this.RunTaskButton.Location = new System.Drawing.Point(329, 78);
            this.RunTaskButton.Name = "RunTaskButton";
            this.RunTaskButton.Size = new System.Drawing.Size(75, 23);
            this.RunTaskButton.TabIndex = 0;
            this.RunTaskButton.Text = "Run";
            this.RunTaskButton.UseVisualStyleBackColor = true;
            this.RunTaskButton.Click += new System.EventHandler(this.RunTaskButton_Click);
            // 
            // TaskResultLabel
            // 
            this.TaskResultLabel.AutoSize = true;
            this.TaskResultLabel.Location = new System.Drawing.Point(329, 130);
            this.TaskResultLabel.Name = "TaskResultLabel";
            this.TaskResultLabel.Size = new System.Drawing.Size(0, 17);
            this.TaskResultLabel.TabIndex = 1;
            // 
            // Main
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.TaskResultLabel);
            this.Controls.Add(this.RunTaskButton);
            this.Name = "Main";
            this.Text = "Form1";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button RunTaskButton;
        private System.Windows.Forms.Label TaskResultLabel;
    }
}

