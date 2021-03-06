namespace DirectoryScanner
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
            this.FolderBrowserDialog = new System.Windows.Forms.FolderBrowserDialog();
            this.DirectoriesTree = new System.Windows.Forms.TreeView();
            this.RedrawCountLabel = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // DirectoriesTree
            // 
            this.DirectoriesTree.Location = new System.Drawing.Point(15, 17);
            this.DirectoriesTree.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.DirectoriesTree.Name = "DirectoriesTree";
            this.DirectoriesTree.Size = new System.Drawing.Size(654, 517);
            this.DirectoriesTree.TabIndex = 0;
            // 
            // RedrawCountLabel
            // 
            this.RedrawCountLabel.AutoSize = true;
            this.RedrawCountLabel.Location = new System.Drawing.Point(686, 33);
            this.RedrawCountLabel.Name = "RedrawCountLabel";
            this.RedrawCountLabel.Size = new System.Drawing.Size(17, 20);
            this.RedrawCountLabel.TabIndex = 1;
            this.RedrawCountLabel.Text = "0";
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(914, 600);
            this.Controls.Add(this.RedrawCountLabel);
            this.Controls.Add(this.DirectoriesTree);
            this.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.Name = "MainForm";
            this.Text = "Directory Scanner";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.FolderBrowserDialog FolderBrowserDialog;
        private System.Windows.Forms.TreeView DirectoriesTree;
        private System.Windows.Forms.Label RedrawCountLabel;
    }
}

