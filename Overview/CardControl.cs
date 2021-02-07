using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Windows.Forms;
using System.Linq;
using System.Diagnostics;

namespace Overview
{
    public partial class CardControl : UserControl
    {
        private TextBox InputControl;

        public CardControl()
        {
            InitializeComponent();
            InputControl = CardNumberTxt;
            PinTxt.Enabled = false;

            //ColorButtonsLinq();
        }

        private void KeyboardBtn_Click(object sender, EventArgs e)
        {
            if (sender is Button button)
            {
                InputControl.Text += button.Text;
            }
        }

        private void CardNumberTxt_TextChanged(object sender, EventArgs e)
        {
            if (CardNumberTxt.Text.Length == 16)
            {
                InputControl = PinTxt;
                PinTxt.Enabled = true;
                CardNumberTxt.Enabled = false;
            }
        }

        private void PinTxt_TextChanged(object sender, EventArgs e)
        {
            if (PinTxt.Text.Length == 4)
            {
                DisableButtons();
            }
        }

        private void DisableButtons()
        {
            foreach (var control in Controls)
            {
                if (control is Button button)
                {
                    button.Enabled = false;
                }
            }
        }

        private void ColorButtonsLinq()
        {
            var buttons = Controls
                            .Cast<Control>()
                            .Where(c => c is Button)
                            .Cast<Button>();
            foreach (var button in buttons)
            {
                button.BackColor = Color.Green;
            }
        }
    }
}
