using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace AsyncForms
{
    public partial class Main : Form
    {
        public Main()
        {
            InitializeComponent();
        }

        private void RunTaskButton_Click(object sender, EventArgs e)
        {

        }

        private void GetFreezeTask()
        {
            Debug.WriteLine($"threadId: {}");
        }

        private void Freeze()
        {
            for (int i = 0; i < 5000; i++)
            {
                Debug.Write(" ");
            }
        }
    }
}
