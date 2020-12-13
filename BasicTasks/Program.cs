using System;
using System.Collections.Generic;

/*
 * Пользователь вводит строку (до точки). Проверить, является ли строка палиндромом 
 * (читается справа-налево и слева-направо одинаково)
 * 192.168.43.141
 */

namespace BasicTasks
{
    class Program
    {
        static void Main(string[] args)
        {
            Car car = new Car();
            Audi audi = new Audi();

            DoSomethingWithCar(car);
            DoSomethingWithCar(audi);

            Console.ReadKey();
        }

        static void DoSomethingWithCar(Car car)
        {
            Console.WriteLine(car);
        }

        static bool TryGetNumber(string maybeNumber, out int result)
        {
            try
            {
                result = int.Parse(maybeNumber);
                return true;
            }
            catch (Exception e)
            {
                result = 0;
                return false;
            }
        }

        static string GetStringFromConsole()
        {
            string myString = string.Empty;
            char symbol;
            do
            {
                symbol = Console.ReadKey().KeyChar;
                myString += symbol;
            } while (symbol != '.');

            return myString;
        }

        static List<string> GetWords(string inputString)
        {
            List<string> words = new List<string>();
            string currentWord = string.Empty;
            foreach (char currentSymbol in inputString)
            {
                if (currentSymbol != ' ')
                {
                    currentWord += currentSymbol;
                }
                else
                {
                    if (!string.IsNullOrWhiteSpace(currentWord))
                    {
                        words.Add(currentWord);
                    }
                }
            }

            return words;
        }
    }
}
