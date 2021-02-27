using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Threading;
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

        private async void RunTaskButton_Click(object sender, EventArgs e)
        {
            //FreezeContinueWithOnContext();
            await FreezeAsync();
        }

        private async Task FreezeAsync()
        {
            var freezeTask1 = GetFreezeTask();
            freezeTask1.Start();
            await freezeTask1;

            var freezeTask2 = GetFreezeTask();
            freezeTask2.Start();
            await freezeTask2;

            //await Task.WhenAll(freezeTask1, freezeTask2);

            Debug.WriteLine($"end of {nameof(FreezeAsync)}! threadId: {GetThreadNumer()}");
            TaskResultLabel.Text = "Completed both tasks";
        }

        private void FreezeContinueWithOnContext()
        {
            var freezeTask = GetFreezeTask();
            freezeTask.Start();
            freezeTask.ContinueWith(t =>
            {
                var methodName = nameof(Task.ContinueWith);
                Debug.WriteLine($"{methodName} threadId: {GetThreadNumer()}");

                TaskResultLabel.Text = "Completed";
            }, TaskScheduler.FromCurrentSynchronizationContext());
        }

        private Task GetFreezeTask()
        {
            var methodName = nameof(GetFreezeTask);
            Debug.WriteLine($"{methodName} threadId: {GetThreadNumer()}");
            return new Task(Freeze);
        }

        private void Freeze()
        {
            var methodName = nameof(Freeze);
            Debug.WriteLine($"{methodName} threadId: {GetThreadNumer()}");
            for (int i = 0; i < 500; i++)
            {
                Debug.Write(" ");
            }
            Debug.WriteLine($"end of {nameof(Freeze)}! threadId: {GetThreadNumer()}");
        }

        private int GetThreadNumer() => Thread.CurrentThread.ManagedThreadId;

        private async void ReadFileButton_Click(object sender, EventArgs e)
        {
            var filePath = "myFile1.txt";
            var isExists = File.Exists(filePath);

            if (!isExists)
            {
                Console.WriteLine("no such file found");
            }

            using (var fs = new FileStream(filePath, FileMode.OpenOrCreate))
            {
                using (var sr = new StreamReader(fs, detectEncodingFromByteOrderMarks: true))
                {
                    var fileText = await sr.ReadToEndAsync();

                    FileTextLabel.Text = fileText;
                }
            }
        }
    }
}
