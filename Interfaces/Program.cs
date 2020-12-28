using System;
using System.Collections;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Linq;

namespace Interfaces
{
    class Program
    {
        public enum CompareType
        {
            ByEven = 1,
            ToFrom
        }

        static void Main(string[] args)
        {
            var selectedOption = GetCompareOption();
            var selectedFilter = GetSelectedFilter(selectedOption);

            var numbers = new[] { 1, 2, 2, 3, 5 };

            var list = new LinkedList<int>(numbers);
            int itemsCount = list?.Count ?? 0;
            var filtered = Filter(list, selectedFilter);

            for (int i = 0; i < itemsCount; i++)
            {
                Console.WriteLine(list?.ElementAt(i));
            }

            foreach (var item in filtered)
            {
                Console.WriteLine(item);
            }
        }

        private static CompareType GetCompareOption()
        {
            Console.WriteLine("please chose filter type");
            Console.WriteLine("1. Compare by even"); // сверять по чет-нечет
            Console.WriteLine("2. Compare by range"); // сверять по диапазону
            var selectedOption = (CompareType)int.Parse(Console.ReadLine());
            return selectedOption;
        }
        
        private static Func<int, bool> GetSelectedFilter(CompareType selectedOption)
        {
            Func<int, bool> selectedFilter = null;
            switch (selectedOption)
            {
                case CompareType.ByEven:
                    selectedFilter = FilterEven;
                    break;
                case CompareType.ToFrom:
                    Console.WriteLine("please enter min value");
                    var from = int.Parse(Console.ReadLine());

                    Console.WriteLine("please enter max value");
                    var to = int.Parse(Console.ReadLine());

                    var toFromComparer = new ToFromComparer(from, to);

                    selectedFilter = toFromComparer.FilterToFrom;
                    break;
            }

            return selectedFilter;
        }

        static bool FilterEven(int number)
        {
            return number % 2 == 0;
        }

        static IEnumerable<T> Filter<T>(IEnumerable<T> toFilter, Func<T, bool> filter)
        {
            if (filter == null) throw new ArgumentNullException("int filter is not declared");
            var list = new LinkedList<T>();
            foreach (var item in toFilter)
            {
                if(filter(item))
                {
                    list.Add(item);
                }
            }
            return list;
        }

        static string Show<T>(T toShow)
        {
            Console.WriteLine(typeof(T));
            return toShow.ToString();
        }

        public static void PrintNumbers(IEnumerable<int> numbers)
        {
            foreach (int number in numbers)
            {
                Console.WriteLine(number);
            }
        }

        public class ToFromComparer
        {
            private int from;
            private int to;

            public ToFromComparer(int from, int to)
            {
                this.from = from;
                this.to = to;
            }

            public bool FilterToFrom(int number)
            {
                return number >= from && number <= to;
            }
        }
    }
}
