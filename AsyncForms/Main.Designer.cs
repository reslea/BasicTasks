
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
            this.ReadFileButton = new System.Windows.Forms.Button();
            this.FileTextLabel = new System.Windows.Forms.Label();
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
            // ReadFileButton
            // 
            this.ReadFileButton.Location = new System.Drawing.Point(433, 78);
            this.ReadFileButton.Name = "ReadFileButton";
            this.ReadFileButton.Size = new System.Drawing.Size(117, 23);
            this.ReadFileButton.TabIndex = 2;
            this.ReadFileButton.Text = "Read File";
            this.ReadFileButton.UseVisualStyleBackColor = true;
            this.ReadFileButton.Click += new System.EventHandler(this.ReadFileButton_Click);
            // 
            // FileOutputLabel
            // 
            this.FileTextLabel.AutoSize = true;
            this.FileTextLabel.Location = new System.Drawing.Point(433, 130);
            this.FileTextLabel.Name = "FileTextLabel";
            this.FileTextLabel.Size = new System.Drawing.Size(0, 17);
            this.FileTextLabel.TabIndex = 3;
            // 
            // Main
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.FileTextLabel);
            this.Controls.Add(this.ReadFileButton);
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
        private System.Windows.Forms.Button ReadFileButton;
        private System.Windows.Forms.Label FileTextLabel;
    }
}

