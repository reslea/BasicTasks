using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DirectoryScanner
{
    public partial class MainForm : Form
    {
        private int _redrawsCount = 0;

        public MainForm()
        {
            InitializeComponent();

            OpenDirectory();
        }

        private void ShowRedrawCount()
        {
            RedrawCountLabel.Text = _redrawsCount++.ToString();
        }

        private void OpenDirectory()
        {
            using var dialog = new FolderBrowserDialog();

            var dialogResult = dialog.ShowDialog();
            var path = dialog.SelectedPath;

            if (dialogResult == DialogResult.OK 
                && !string.IsNullOrWhiteSpace(path) 
                && Directory.Exists(path))
            {
                DirectoriesTree.BeginUpdate();
                PopulateDirectoryInfo(path, DirectoriesTree.Nodes);
                DirectoriesTree.EndUpdate();
            }
        }

        private void PopulateDirectoryInfo(string path, TreeNodeCollection treeNode)
        {
            var directories = Directory.GetDirectories(path);
            var files = Directory.GetFiles(path);

            foreach (var directory in directories)
            {
                var directoryName = directory.Replace(path, "");
                
                var node = treeNode.Add(directoryName);

                PopulateDirectoryInfo(directory, node.Nodes);
            }

            foreach (var file in files)
            {
                var fileName = file.Replace(path, "");
                treeNode.Add(fileName);
            }
        }
    }
}
