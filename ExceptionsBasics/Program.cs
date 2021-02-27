using System;

namespace ExceptionsBasics
{
    public class Program
    {
        static void Main(string[] args)
        {
            var coolClass = new CoolClass();
            var otherClass = new OtherClass();
            coolClass.SomeMethod(otherClass);
            Console.WriteLine("main");
        }

        public static int? GetNumber()
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

    class CoolClass
    {
        public void SomeMethod(OtherClass otherClass)
        {
            try
            {
                otherClass.SomeMethod(1, 1);
                Console.WriteLine("outer class");
            }
            catch(ArgumentException ex)
            {
                throw new ExecutionEngineException("inner class failure", ex);
            }
        }
    }

     class OtherClass
    {
        public void SomeMethod(int x, int y)
        {
            var someNumber = 15;
            Console.WriteLine("inner class");
            throw new ArgumentException($"Some process is failed with x: {x} y: {y}");
        }
    }

    class ConsoleException  : Exception
    {
        public ConsoleException() : base() { }

        public ConsoleException(string message) : base(message) { }

        public ConsoleException(string message, Exception innerException) : base(message, innerException) { }
    }
}
