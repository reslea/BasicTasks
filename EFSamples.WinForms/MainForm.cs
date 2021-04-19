using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using EFSamples.Entities;
using EFSamples.Logic;

namespace EFSamples.WinForms
{
    public partial class MainForm : Form
    {
        private readonly IVisitorService _visitorService;

        public MainForm()
        {
            _visitorService = new VisitorService();
            InitializeComponent();
        }

        private void AllVisitorsButton_Click(object sender, EventArgs e)
        {
            var visitors = _visitorService.Get();

            VisitorsDataGridView.DataSource = visitors;
        }

        private void ShowWithBooksButton_Click(object sender, EventArgs e)
        {
            var visitors = _visitorService.GetVisitorsWithBooks();
            VisitorsDataGridView.DataSource = visitors;
        }
    }
}
