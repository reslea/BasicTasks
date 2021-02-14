using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace EventsOverview
{
    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            var eventExample = new EventExample();
            eventExample.Example();

            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new Form1());
        }
    }

    public class EventExample
    {
        //private int counter = 0;
        //private Action fakeButtonClick;

        public event Action FakeButtonClick;
        //{
        //    add
        //    {
        //        counter++;
        //        fakeButtonClick += value;
        //    }
        //    remove
        //    {
        //        counter--;
        //        fakeButtonClick -= value;
        //    }
        //} 

        public void Example()
        {
            FakeButtonClick += DoNothing1;
            FakeButtonClick += DoNothing2;
        }

        private void DoNothing1()
        {
            Debug.WriteLine("Did nothing 1");
        }

        private void DoNothing2()
        {
            Debug.WriteLine("Did nothing 2");
        }
    }
}
