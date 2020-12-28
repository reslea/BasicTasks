using System;
using System.Linq;
using System.Collections.Generic;
using System.Net.Sockets;

namespace Extentions
{
    class Program
    {
        private static Random random = new Random();

        static void Main(string[] args)
        {
            var numbers = GetEvenNumbers()
                .Take(100);
            
            var firstNumber = numbers
                .FirstOrDefault(n => n < 0);

            foreach (var number in numbers)
            {
                Console.WriteLine(number);
            }
        }

        public static IEnumerable<int> GetEvenNumbers()
        {
            var i = 0;
            while (true)
            {
                yield return i++;
            }
        }

        private static IEnumerable<int> GetPage(IEnumerable<int> numbers, int pageNumber, int itemsPerPage = 10)
        {
            return numbers
                .Skip(pageNumber * itemsPerPage)
                .Take(itemsPerPage);
        }
    }
}
