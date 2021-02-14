
namespace GasStation
{
    partial class CafeItem
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

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.ItemPrice = new System.Windows.Forms.TextBox();
            this.ItemCheckbox = new System.Windows.Forms.CheckBox();
            this.ItemCountNumeric = new System.Windows.Forms.NumericUpDown();
            ((System.ComponentModel.ISupportInitialize)(this.ItemCountNumeric)).BeginInit();
            this.SuspendLayout();
            // 
            // ItemPrice
            // 
            this.ItemPrice.Location = new System.Drawing.Point(111, 2);
            this.ItemPrice.Name = "ItemPrice";
            this.ItemPrice.ReadOnly = true;
            this.ItemPrice.Size = new System.Drawing.Size(48, 20);
            this.ItemPrice.TabIndex = 11;
            this.ItemPrice.Text = "4,20";
            // 
            // ItemCheckbox
            // 
            this.ItemCheckbox.AutoSize = true;
            this.ItemCheckbox.Location = new System.Drawing.Point(3, 3);
            this.ItemCheckbox.Name = "ItemCheckbox";
            this.ItemCheckbox.Size = new System.Drawing.Size(74, 19);
            this.ItemCheckbox.TabIndex = 10;
            this.ItemCheckbox.Text = "Хот-дог";
            this.ItemCheckbox.UseVisualStyleBackColor = true;
            this.ItemCheckbox.CheckedChanged += new System.EventHandler(this.ItemCheckbox_CheckedChanged);
            // 
            // ItemCountNumeric
            // 
            this.ItemCountNumeric.Enabled = false;
            this.ItemCountNumeric.Location = new System.Drawing.Point(165, 2);
            this.ItemCountNumeric.Name = "ItemCountNumeric";
            this.ItemCountNumeric.Size = new System.Drawing.Size(41, 20);
            this.ItemCountNumeric.TabIndex = 9;
            this.ItemCountNumeric.ValueChanged += new System.EventHandler(this.ItemCountNumeric_ValueChanged);
            // 
            // CafeItem
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.ItemPrice);
            this.Controls.Add(this.ItemCheckbox);
            this.Controls.Add(this.ItemCountNumeric);
            this.Name = "CafeItem";
            this.Size = new System.Drawing.Size(212, 26);
            ((System.ComponentModel.ISupportInitialize)(this.ItemCountNumeric)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox ItemPrice;
        private System.Windows.Forms.CheckBox ItemCheckbox;
        private System.Windows.Forms.NumericUpDown ItemCountNumeric;
    }
}
