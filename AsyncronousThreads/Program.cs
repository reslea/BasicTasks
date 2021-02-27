using System;
using System.Diagnostics;
using System.Threading;
using System.Threading.Tasks;

namespace AsyncronousThreads
{
    class Program
    {
        static void Main(string[] args)
        {
            var task = GetTask();

            task.Start();
            Console.ReadKey();

            task.Start();
            Console.ReadKey();
        }

        private static Task GetTask()
        {
            return new Task(ConsoleCounter);
        }

        private static void WorkWithTheadPool()
        {
            ThreadPool.QueueUserWorkItem(new WaitCallback(ConsoleCounter));
            ThreadPool.QueueUserWorkItem(new WaitCallback(Freeze));
            ThreadPool.QueueUserWorkItem(new WaitCallback(ConsoleCounter));
        }

        private static void Freeze(object param)
        {
            for (int i = 0; i < 10000; i++)
            {
                Debug.WriteLine(i);
            }
        }

        private static void ConsoleCounter()
        {
            for (int i = 0; i < 1 * 1000; i++)
            {
                Console.WriteLine($"threadId: {Thread.CurrentThread.ManagedThreadId}, i: {i}");
            }
        }

        private static void ConsoleCounter(object param)
        {
            for (int i = 0; i < 1 * 1000; i++)
            {
                Console.WriteLine($"threadId: {Thread.CurrentThread.ManagedThreadId}, i: {i}");
            }
        }
    }
}
