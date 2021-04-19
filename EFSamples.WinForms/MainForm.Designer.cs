
namespace EFSamples.WinForms
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
            this.VisitorsDataGridView = new System.Windows.Forms.DataGridView();
            this.AllVisitorsButton = new System.Windows.Forms.Button();
            this.ShowWithBooksButton = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.VisitorsDataGridView)).BeginInit();
            this.SuspendLayout();
            // 
            // VisitorsDataGridView
            // 
            this.VisitorsDataGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.VisitorsDataGridView.Location = new System.Drawing.Point(12, 47);
            this.VisitorsDataGridView.Name = "VisitorsDataGridView";
            this.VisitorsDataGridView.RowHeadersWidth = 51;
            this.VisitorsDataGridView.RowTemplate.Height = 29;
            this.VisitorsDataGridView.Size = new System.Drawing.Size(776, 391);
            this.VisitorsDataGridView.TabIndex = 0;
            // 
            // AllVisitorsButton
            // 
            this.AllVisitorsButton.Location = new System.Drawing.Point(12, 12);
            this.AllVisitorsButton.Name = "AllVisitorsButton";
            this.AllVisitorsButton.Size = new System.Drawing.Size(94, 29);
            this.AllVisitorsButton.TabIndex = 1;
            this.AllVisitorsButton.Text = "Show all";
            this.AllVisitorsButton.UseVisualStyleBackColor = true;
            this.AllVisitorsButton.Click += new System.EventHandler(this.AllVisitorsButton_Click);
            // 
            // ShowWithBooksButton
            // 
            this.ShowWithBooksButton.Location = new System.Drawing.Point(112, 12);
            this.ShowWithBooksButton.Name = "ShowWithBooksButton";
            this.ShowWithBooksButton.Size = new System.Drawing.Size(159, 29);
            this.ShowWithBooksButton.TabIndex = 2;
            this.ShowWithBooksButton.Text = "Show with books";
            this.ShowWithBooksButton.UseVisualStyleBackColor = true;
            this.ShowWithBooksButton.Click += new System.EventHandler(this.ShowWithBooksButton_Click);
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.ShowWithBooksButton);
            this.Controls.Add(this.AllVisitorsButton);
            this.Controls.Add(this.VisitorsDataGridView);
            this.Name = "MainForm";
            this.Text = "MainForm";
            ((System.ComponentModel.ISupportInitialize)(this.VisitorsDataGridView)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataGridView VisitorsDataGridView;
        private System.Windows.Forms.Button AllVisitorsButton;
        private System.Windows.Forms.Button ShowWithBooksButton;
    }
}

