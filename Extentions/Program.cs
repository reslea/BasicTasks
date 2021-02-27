using System;
using System.Collections;
using System.Linq;
using System.Collections.Generic;
using System.Net.Sockets;

namespace Extentions
{
    public class NumbersGenerator : IEnumerable<int>
    {
        public IEnumerator<int> GetEnumerator()
        {
            return new GeneratedNumbersEnumerator();
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }

        public class GeneratedNumbersEnumerator : IEnumerator<int>
        {
            private int _value = 0;

            public int Current { get; private set; }

            object? IEnumerator.Current => Current;

            public bool MoveNext()
            {
                Current = _value++;
                return true;
            }

            public void Reset()
            {
                _value = 0;
            }

            public void Dispose() { }
        }
    }

    class Program
    {
        private static Random random = new Random();

        static void Main(string[] args)
        {
            foreach (var number in new NumbersGenerator())
            {
                Console.WriteLine(number);
            }
        }

        public static IEnumerable<int> GetNumbers()
        {
            var _value = 0;

            while (true)
            {
                yield return _value++;
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
