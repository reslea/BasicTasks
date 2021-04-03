
namespace Disconnected.UI
{
    partial class MainForm
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
            this.BooksDataGridView = new System.Windows.Forms.DataGridView();
            this.DebugButton = new System.Windows.Forms.Button();
            this.PricesDataGridView = new System.Windows.Forms.DataGridView();
            this.TitleTextBox = new System.Windows.Forms.TextBox();
            this.AuthorTextBox = new System.Windows.Forms.TextBox();
            this.PagesCountNumeric = new System.Windows.Forms.NumericUpDown();
            this.AddBookButton = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.BooksDataGridView)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.PricesDataGridView)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.PagesCountNumeric)).BeginInit();
            this.SuspendLayout();
            // 
            // BooksDataGridView
            // 
            this.BooksDataGridView.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.BooksDataGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.BooksDataGridView.Location = new System.Drawing.Point(12, 41);
            this.BooksDataGridView.Name = "BooksDataGridView";
            this.BooksDataGridView.RowHeadersWidth = 51;
            this.BooksDataGridView.Size = new System.Drawing.Size(534, 397);
            this.BooksDataGridView.TabIndex = 0;
            // 
            // DebugButton
            // 
            this.DebugButton.Location = new System.Drawing.Point(862, 12);
            this.DebugButton.Name = "DebugButton";
            this.DebugButton.Size = new System.Drawing.Size(75, 23);
            this.DebugButton.TabIndex = 1;
            this.DebugButton.Text = "Debug";
            this.DebugButton.UseVisualStyleBackColor = true;
            this.DebugButton.Click += new System.EventHandler(this.DebugButton_Click);
            // 
            // PricesDataGridView
            // 
            this.PricesDataGridView.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.PricesDataGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.PricesDataGridView.Location = new System.Drawing.Point(552, 41);
            this.PricesDataGridView.Name = "PricesDataGridView";
            this.PricesDataGridView.RowHeadersWidth = 51;
            this.PricesDataGridView.Size = new System.Drawing.Size(385, 397);
            this.PricesDataGridView.TabIndex = 2;
            // 
            // TitleTextBox
            // 
            this.TitleTextBox.Location = new System.Drawing.Point(13, 12);
            this.TitleTextBox.Name = "TitleTextBox";
            this.TitleTextBox.Size = new System.Drawing.Size(199, 20);
            this.TitleTextBox.TabIndex = 3;
            // 
            // AuthorTextBox
            // 
            this.AuthorTextBox.Location = new System.Drawing.Point(218, 11);
            this.AuthorTextBox.Name = "AuthorTextBox";
            this.AuthorTextBox.Size = new System.Drawing.Size(178, 20);
            this.AuthorTextBox.TabIndex = 4;
            // 
            // PagesCountNumeric
            // 
            this.PagesCountNumeric.Location = new System.Drawing.Point(402, 12);
            this.PagesCountNumeric.Name = "PagesCountNumeric";
            this.PagesCountNumeric.Size = new System.Drawing.Size(63, 20);
            this.PagesCountNumeric.TabIndex = 5;
            // 
            // AddBookButton
            // 
            this.AddBookButton.Location = new System.Drawing.Point(471, 9);
            this.AddBookButton.Name = "AddBookButton";
            this.AddBookButton.Size = new System.Drawing.Size(75, 23);
            this.AddBookButton.TabIndex = 6;
            this.AddBookButton.Text = "Add Book";
            this.AddBookButton.UseVisualStyleBackColor = true;
            this.AddBookButton.Click += new System.EventHandler(this.AddBookButton_Click);
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(949, 450);
            this.Controls.Add(this.AddBookButton);
            this.Controls.Add(this.PagesCountNumeric);
            this.Controls.Add(this.AuthorTextBox);
            this.Controls.Add(this.TitleTextBox);
            this.Controls.Add(this.PricesDataGridView);
            this.Controls.Add(this.DebugButton);
            this.Controls.Add(this.BooksDataGridView);
            this.Name = "MainForm";
            this.Text = "Form1";
            ((System.ComponentModel.ISupportInitialize)(this.BooksDataGridView)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.PricesDataGridView)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.PagesCountNumeric)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView BooksDataGridView;
        private System.Windows.Forms.Button DebugButton;
        private System.Windows.Forms.DataGridView PricesDataGridView;
        private System.Windows.Forms.TextBox TitleTextBox;
        private System.Windows.Forms.TextBox AuthorTextBox;
        private System.Windows.Forms.NumericUpDown PagesCountNumeric;
        private System.Windows.Forms.Button AddBookButton;
    }
}

