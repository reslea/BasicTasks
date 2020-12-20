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

        //delegate bool IntFilter(int toFilter);

        delegate void Void();
        delegate void Void<T1>(T1 param);
        delegate void Void<T1, T2>(T1 param1, T2 param2);
        delegate void Void<T1, T2, T3>(T1 param1, T2 param2, T3 param3);

        delegate TResult Function<TResult>();
        delegate TResult Function<TResult, T1>(T1 param1);
        delegate TResult Function<TResult, T1, T2>(T1 param1, T2 param2);
        delegate TResult Function<TResult, T1, T2, T3>(T1 param1, T2 param2, T3 param3);

        static void Main(string[] args)
        {
            var selectedOption = GetCompareOption();
            var selectedFilter = GetSelectedFilter(selectedOption);

            var numbers = new[] { 1, 2, 2, 3, 5 };

            var list = new LinkedList<int>(numbers);
            var filtered = Filter(list, selectedFilter);

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

        private static Function<bool, int> GetSelectedFilter(CompareType selectedOption)
        {
            Function<bool, int> selectedFilter = null;
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

        static IEnumerable<int> Filter(IEnumerable<int> toFilter, Function<bool, int> intFilter)
        {
            if (intFilter == null) throw new ArgumentNullException("int filter is not declared");
            var list = new LinkedList<int>();
            foreach (var item in toFilter)
            {
                if(intFilter(item))
                {
                    list.Add(item);
                }
            }
            return list;
        }

        static IEnumerable<string> Filter(IEnumerable<string> toFilter, string toSearch)
        {
            var list = new LinkedList<string>();
            foreach (var item in toFilter)
            {
                if (item.Contains(toSearch))
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
