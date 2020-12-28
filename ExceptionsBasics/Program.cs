using System;

namespace ExceptionsBasics
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine(GetNumber());
        }

        static int? GetNumber()
        {
            try
            {
                Console.WriteLine("Enter a number");
                var number = int.Parse(Console.ReadLine());
                return number;
            }
            catch (FormatException exception)
            {
                Console.WriteLine(exception.Message);

                throw new ConsoleException("Sorry, not a number", exception);
            }
            catch (Exception e)
            {
                Console.WriteLine("Something happened");

                return null;
            }
            finally
            {
                Console.WriteLine("inside finally");
            }
        }
    }

    class ConsoleException  : Exception
    {
        public ConsoleException() : base() { }

        public ConsoleException(string message) : base(message) { }

        public ConsoleException(string message, Exception innerException) : base(message, innerException) { }
    }
}
