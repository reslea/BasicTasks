using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Overview
{
    public partial class MainForm : Form
    {
        public MainForm()
        {
            InitializeComponent();
        }

        private void FreezeButton_Click(object sender, EventArgs e)
        {
            ThreadPool.QueueUserWorkItem(Freeze);
        }

        private void Freeze(object obj)
        {
            for (int i = 0; i < 5000; i++)
            {
                Debug.WriteLine(i);
            }
        }
    }
}
