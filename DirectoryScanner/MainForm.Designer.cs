﻿namespace DirectoryScanner
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
            this.SuspendLayout();
            // 
            // DirectoriesTree
            // 
            this.DirectoriesTree.Location = new System.Drawing.Point(13, 13);
            this.DirectoriesTree.Name = "DirectoriesTree";
            this.DirectoriesTree.Size = new System.Drawing.Size(573, 389);
            this.DirectoriesTree.TabIndex = 0;
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.DirectoriesTree);
            this.Name = "MainForm";
            this.Text = "Directory Scanner";
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.FolderBrowserDialog FolderBrowserDialog;
        private System.Windows.Forms.TreeView DirectoriesTree;
    }
}
