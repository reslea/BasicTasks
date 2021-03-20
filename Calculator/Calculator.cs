using System;
using System.Linq;

namespace Calculator
{
    public class Calculator
    {
        public int Add(string numbers)
        {
            if (string.IsNullOrEmpty(numbers))
            {
                return 0;
            }

            char delimiter = ',';
            if (numbers.StartsWith("//"))
            {
                delimiter = numbers[2];
                numbers = numbers.Substring(4);
            }

            var splitted = numbers.Split(delimiter, '\n');
            if (splitted.Length == 1)
            {
                var result = ParseInt(splitted[0]);
                return result >= 0 ? result : throw new ArgumentException($"negatives not allowed: {result}");
            }

            var parsedNumbers = splitted.Select(ParseInt).ToList();

            var negativeNumbers = parsedNumbers.Where(n => n < 0).ToList();
            return negativeNumbers.Any()
                ? throw new ArgumentException($"negatives not allowed: {string.Join(", ", negativeNumbers)}")
                : parsedNumbers.Sum();
        }

        private int ParseInt(string number)
        {
            return int.Parse(number);
        }
    }
}
