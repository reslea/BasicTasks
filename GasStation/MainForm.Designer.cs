
namespace GasStation
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
            this.GasTypeCombobox = new System.Windows.Forms.ComboBox();
            this.GasPriceText = new System.Windows.Forms.TextBox();
            this.GasTypeLbl = new System.Windows.Forms.Label();
            this.GasPriceLbl = new System.Windows.Forms.Label();
            this.CafeItemsPanel = new System.Windows.Forms.Panel();
            this.TotalPriceLbl = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // GasTypeCombobox
            // 
            this.GasTypeCombobox.FormattingEnabled = true;
            this.GasTypeCombobox.Location = new System.Drawing.Point(109, 69);
            this.GasTypeCombobox.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.GasTypeCombobox.Name = "GasTypeCombobox";
            this.GasTypeCombobox.Size = new System.Drawing.Size(160, 24);
            this.GasTypeCombobox.TabIndex = 0;
            this.GasTypeCombobox.SelectedIndexChanged += new System.EventHandler(this.GasTypeCombobox_SelectedIndexChanged);
            // 
            // GasPriceText
            // 
            this.GasPriceText.Location = new System.Drawing.Point(109, 128);
            this.GasPriceText.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.GasPriceText.Name = "GasPriceText";
            this.GasPriceText.ReadOnly = true;
            this.GasPriceText.Size = new System.Drawing.Size(160, 22);
            this.GasPriceText.TabIndex = 1;
            // 
            // GasTypeLbl
            // 
            this.GasTypeLbl.AutoSize = true;
            this.GasTypeLbl.Location = new System.Drawing.Point(28, 76);
            this.GasTypeLbl.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.GasTypeLbl.Name = "GasTypeLbl";
            this.GasTypeLbl.Size = new System.Drawing.Size(66, 17);
            this.GasTypeLbl.TabIndex = 2;
            this.GasTypeLbl.Text = "GasType";
            // 
            // GasPriceLbl
            // 
            this.GasPriceLbl.AutoSize = true;
            this.GasPriceLbl.Location = new System.Drawing.Point(55, 134);
            this.GasPriceLbl.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.GasPriceLbl.Name = "GasPriceLbl";
            this.GasPriceLbl.Size = new System.Drawing.Size(40, 17);
            this.GasPriceLbl.TabIndex = 3;
            this.GasPriceLbl.Text = "Price";
            // 
            // CafeItemsPanel
            // 
            this.CafeItemsPanel.Location = new System.Drawing.Point(617, 69);
            this.CafeItemsPanel.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.CafeItemsPanel.Name = "CafeItemsPanel";
            this.CafeItemsPanel.Size = new System.Drawing.Size(293, 254);
            this.CafeItemsPanel.TabIndex = 5;
            // 
            // TotalPriceLbl
            // 
            this.TotalPriceLbl.AutoSize = true;
            this.TotalPriceLbl.Location = new System.Drawing.Point(829, 362);
            this.TotalPriceLbl.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.TotalPriceLbl.Name = "TotalPriceLbl";
            this.TotalPriceLbl.Size = new System.Drawing.Size(16, 17);
            this.TotalPriceLbl.TabIndex = 7;
            this.TotalPriceLbl.Text = "0";
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1067, 554);
            this.Controls.Add(this.TotalPriceLbl);
            this.Controls.Add(this.CafeItemsPanel);
            this.Controls.Add(this.GasPriceLbl);
            this.Controls.Add(this.GasTypeLbl);
            this.Controls.Add(this.GasPriceText);
            this.Controls.Add(this.GasTypeCombobox);
            this.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.Name = "MainForm";
            this.Text = "Form1";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ComboBox GasTypeCombobox;
        private System.Windows.Forms.TextBox GasPriceText;
        private System.Windows.Forms.Label GasTypeLbl;
        private System.Windows.Forms.Label GasPriceLbl;
        private System.Windows.Forms.Panel CafeItemsPanel;
        private System.Windows.Forms.Label TotalPriceLbl;
    }
}

