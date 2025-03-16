using Calculator;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _6._3.SampleTDDTests
{
    public class StringCalculatorTest
    {
        [Fact]
        public void Add_EmptyString_ReturnsZero()
        {
            // Arrange
            var calculator = new StringCalculator();
            // Act
            var result = calculator.Add("");
            // Assert
            Assert.Equal(0, result);
        }

        [Fact]
        public void Add_SingleNumber_ReturnsTheNumber()
        {
            // Arrange
            var calculator = new StringCalculator();
            // Act
            var result = calculator.Add("5");
            // Assert
            Assert.Equal(5, result);
        }

        [Fact]
        public void Add_TwoNumbers_ReturnsTheSum()
        {
            // Arrange
            var calculator = new StringCalculator();
            // Act
            var result = calculator.Add("5,3");
            // Assert
            Assert.Equal(8, result);
        }

        [Fact]
        public void Add_MultipleNumbers_ReturnsTheSum()
        {
            // Arrange
            var calculator = new StringCalculator();
            // Act
            var result = calculator.Add("5,3,8,1");
            // Assert
            Assert.Equal(17, result);
        }

        [Fact]
        public void Add_StringWithNonNumericCharacters_ThrowsException()
        {
            // Arrange
            var calculator = new StringCalculator();
            // Assert
            Assert.Equal(17, calculator.Add("5,3,8,1,x"));
        }
    }
}
