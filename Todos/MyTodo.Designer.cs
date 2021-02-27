
namespace Todos
{
    partial class MyTodo
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
            this.TodosListbox = new System.Windows.Forms.ListBox();
            this.TodoNameTextbox = new System.Windows.Forms.TextBox();
            this.AddTodoButton = new System.Windows.Forms.Button();
            this.RemoveTodo = new System.Windows.Forms.Button();
            this.EditTodo = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // TodosListbox
            // 
            this.TodosListbox.FormattingEnabled = true;
            this.TodosListbox.ItemHeight = 16;
            this.TodosListbox.Location = new System.Drawing.Point(186, 87);
            this.TodosListbox.Name = "TodosListbox";
            this.TodosListbox.Size = new System.Drawing.Size(252, 212);
            this.TodosListbox.TabIndex = 0;
            this.TodosListbox.KeyDown += new System.Windows.Forms.KeyEventHandler(this.TodosListbox_KeyDown);
            // 
            // TodoNameTextbox
            // 
            this.TodoNameTextbox.Location = new System.Drawing.Point(186, 59);
            this.TodoNameTextbox.Name = "TodoNameTextbox";
            this.TodoNameTextbox.Size = new System.Drawing.Size(162, 22);
            this.TodoNameTextbox.TabIndex = 1;
            // 
            // AddTodoButton
            // 
            this.AddTodoButton.Location = new System.Drawing.Point(354, 58);
            this.AddTodoButton.Name = "AddTodoButton";
            this.AddTodoButton.Size = new System.Drawing.Size(84, 23);
            this.AddTodoButton.TabIndex = 2;
            this.AddTodoButton.Text = "Добавить";
            this.AddTodoButton.UseVisualStyleBackColor = true;
            this.AddTodoButton.Click += new System.EventHandler(this.AddTodoButton_Click);
            // 
            // RemoveTodo
            // 
            this.RemoveTodo.Location = new System.Drawing.Point(466, 116);
            this.RemoveTodo.Name = "RemoveTodo";
            this.RemoveTodo.Size = new System.Drawing.Size(67, 23);
            this.RemoveTodo.TabIndex = 3;
            this.RemoveTodo.Text = "Delete";
            this.RemoveTodo.UseVisualStyleBackColor = true;
            this.RemoveTodo.Click += new System.EventHandler(this.RemoveItem_Click);
            // 
            // EditTodo
            // 
            this.EditTodo.Location = new System.Drawing.Point(466, 145);
            this.EditTodo.Name = "EditTodo";
            this.EditTodo.Size = new System.Drawing.Size(67, 23);
            this.EditTodo.TabIndex = 4;
            this.EditTodo.Text = "Edit";
            this.EditTodo.UseVisualStyleBackColor = true;
            this.EditTodo.Click += new System.EventHandler(this.EditTodoButton_Click);
            // 
            // MyTodo
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(688, 450);
            this.Controls.Add(this.EditTodo);
            this.Controls.Add(this.RemoveTodo);
            this.Controls.Add(this.AddTodoButton);
            this.Controls.Add(this.TodoNameTextbox);
            this.Controls.Add(this.TodosListbox);
            this.Name = "MyTodo";
            this.Text = "Form1";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ListBox TodosListbox;
        private System.Windows.Forms.TextBox TodoNameTextbox;
        private System.Windows.Forms.Button AddTodoButton;
        private System.Windows.Forms.Button RemoveTodo;
        private System.Windows.Forms.Button EditTodo;
    }
}

