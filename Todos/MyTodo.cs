using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Todos
{
    public partial class MyTodo : Form
    {
        private enum TextEditMode
        {
            Add,
            Change
        }

        private TextEditMode CurrentTextEditState = TextEditMode.Add;

        public MyTodo()
        {
            InitializeComponent();
        }

        private void AddTodoButton_Click(object sender, EventArgs e)
        {
            var todo = TodoNameTextbox.Text;

            if (string.IsNullOrWhiteSpace(todo))
            {
                switch (CurrentTextEditState)
                {
                    case TextEditMode.Add: TodosListbox.Items.Add(todo); break;
                    case TextEditMode.Change:
                    {
                        var selectedIndex = TodosListbox.SelectedIndex;
                        if (!string.IsNullOrWhiteSpace(todo))
                        {
                            TodosListbox.Items[selectedIndex] = todo;
                        }
                        break;
                    }
                    default:
                        throw new ArgumentOutOfRangeException();
                }
            }

            TodoNameTextbox.Text = string.Empty;
        }

        private void AddTodo()
        {
            
        }
        private void TodosListbox_KeyDown(object sender, KeyEventArgs e)
        {
            switch (e.KeyCode)
            {
                case Keys.Delete: DeleteTodo(); break;
                case Keys.F2: CurrentTextEditState = TextEditMode.Change; break;
            }
        }

        private void DeleteTodo()
        {
            TodosListbox.Items.Remove(TodosListbox.SelectedItem);
        }

        private void RemoveItem_Click(object sender, EventArgs e)
        {
            DeleteTodo();
        }

        private void EditTodoButton_Click(object sender, EventArgs e)
        {
            CurrentTextEditState = TextEditMode.Change;
        }
    }
}
