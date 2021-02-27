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
            // "положить" счетчик консоли в задачу
            // для возможности дальнейшего запуска на пуле потоков (ThreadPool)
            var consoleTask = new Task(ConsoleCounter);

            // запустить задачу к выполнению
            consoleTask.Start();

            // сформировать новую задачу
            // она будет выполнена после завершения предыдущей
            // это сделает автоматически планировщик потоков на пуле потоков
            var continueTask = consoleTask.ContinueWith(t =>
            // код продолжения
            {
                Console.WriteLine("Task is completed");
            });

            // назначить ожидание задачи.
            // Поскольку задача продолжения выполнится гарантированно после consoleTask
            // то здесь мы ожидаем выполнения обоих задач
            continueTask.Wait();
            // здесь обе задачи выполнены, можно выводить сообщение
            // и закрывать программу
            Console.WriteLine("All tasks are completed");
        }

        private static void ConsoleSpaces()
        {
            Console.WriteLine($"main thread: {Thread.CurrentThread.ManagedThreadId}");
            Console.WriteLine("doing something useful");
            for (int i = 0; i < 10 * 100; i++)
            {
                Console.Write(" ");
            }
        }

        private static Task GetTaskWrapped()
        {
            var task = GetConsoleTask();

            task.Start();
                
            return task;
        }

        private static Task GetConsoleTask()
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
            ConsoleCounter(null);
        }

        private static void ConsoleCounter(object param)
        {
            for (int i = 0; i < 1 * 10; i++)
            {
                Console.WriteLine($"threadId: {Thread.CurrentThread.ManagedThreadId}, i: {i}");
            }
            Console.WriteLine($"threadId: {Thread.CurrentThread.ManagedThreadId}");
            //throw new ApplicationException("error!");
        }
    }
}
