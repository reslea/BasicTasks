using System;
using Xunit;

namespace Calculator.Tests
{
    public class CalculatorTests
    {
        [Fact]
        public void Add_Signature()
        {
            var calculator = new Calculator();
            string numbers = string.Empty;
            calculator.Add(numbers);
        }
        
        [Fact]
        public void Add_Empty_Parameters()
        {
            var calculator = new Calculator();
            var input = string.Empty;
            int result = calculator.Add(input);
            Assert.Equal(0, result);
        }

        [Theory]
        [InlineData("1", 1)]
        [InlineData("5", 5)]
        [InlineData("55", 55)]
        public void Add_Single_Parameters(string input, int expectedResult)
        {
            var calculator = new Calculator();
            int result = calculator.Add(input);
            Assert.Equal(expectedResult, result);
        }

        [Theory]
        [InlineData("1,2", 3)]
        [InlineData("5,7", 12)]
        [InlineData("55, 1", 56)]
        public void Add_Two_Parameters(string input, int expectedResult)
        {
            var calculator = new Calculator();
            int result = calculator.Add(input);
            Assert.Equal(expectedResult, result);
        }

        [Theory]
        [InlineData("1,2,3", 6)]
        [InlineData("5,7,1,1", 14)]
        [InlineData("55,1,1,1,1", 59)]
        public void Add_Many_Parameters(string input, int expectedResult)
        {
            var calculator = new Calculator();
            int result = calculator.Add(input);
            Assert.Equal(expectedResult, result);
        }

        [Theory]
        [InlineData("1\n2,4", 7)]
        [InlineData("5,5,1\n1", 12)]
        public void Add_New_Line_Delimiter(string input, int expectedResult)
        {
            var calculator = new Calculator();
            int result = calculator.Add(input);
            Assert.Equal(expectedResult, result);
        }

        [Theory]
        [InlineData("//;\n1;9", 10)]
        [InlineData("//*\n5*5*1*2", 13)]
        public void Add_Changed_Delimiter(string input, int expectedResult)
        {
            var calculator = new Calculator();
            int result = calculator.Add(input);
            Assert.Equal(expectedResult, result);
        }

        [Theory]
        [InlineData("-50")]
        [InlineData("-1,9")]
        [InlineData("20,-1,5")]
        public void Add_Throws_Negative_Numbers(string input)
        {
            var calculator = new Calculator();
            Assert.Throws<ArgumentException>(() => calculator.Add(input));
        }

        [Theory]
        [InlineData("-60", "-60")]
        [InlineData("-2,9", "-2")]
        [InlineData("20,5,-15,-40", "-15, -40")]
        public void Add_Throws_Negative_Numbers_Specifying_Them(string input, string negativeNumbers)
        {
            var calculator = new Calculator();
            var exception = Assert.Throws<ArgumentException>(() => calculator.Add(input));

            var expectedExceptionMessage = $"negatives not allowed: {negativeNumbers}";

            Assert.Equal(expectedExceptionMessage, exception.Message);
        }
    }
}
