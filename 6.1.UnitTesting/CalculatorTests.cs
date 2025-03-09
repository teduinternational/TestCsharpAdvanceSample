using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _6._1.UnitTesting
{
    public class CalculatorTests
    {
        private readonly Calculator.Calculator _calculator;

        public CalculatorTests()
        {
            _calculator = new Calculator.Calculator();
        }

        [Fact]
        public void Add_ReturnSumOfTwoNumbers_Success()
        {   
            // Arrange
            int a = 10;
            int b = 20;
            // Act
            var result = _calculator.Add(a, b);
            // Assert
            Assert.Equal(30, result);
        }

        [Theory]
        [InlineData(10, 20, 30)]
        [InlineData(-10, -20, -30)]
        [InlineData(-1, -2, -3)]
        [InlineData(1, -2, -1)]
        public void Add_ReturnSumOfTwoNumbers_MultipleCasesSuccess(int a, int b, int expected)
        {
            // Act
            var result = _calculator.Add(a, b);
            // Assert
            Assert.Equal(expected, result);
        }
    }
}
