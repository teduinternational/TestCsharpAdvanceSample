using Calculator;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _6._1.UnitTesting
{
    public class MathHelperTests
    {
        private readonly MathHelper _mathHelper;
        public MathHelperTests()
        {
            _mathHelper = new MathHelper();
        }

        [Fact]
        public void Factorial_ZeroNumber_ReturnOne()
        {             
            // Arrange
            int n = 0;
            int expected = 1;
            // Act
            int actual = _mathHelper.Factorial(n);
            // Assert
            Assert.Equal(expected, actual);
        }

        [Fact]
        public void Factorial_OneNumber_ReturnOne()
        {
            // Arrange
            int n = 1;
            int expected = 1;
            // Act
            int actual = _mathHelper.Factorial(n);
            // Assert
            Assert.Equal(expected, actual);
        }

        [Fact]
        public void Factorial_NegativeNumber_ThrowAgrumentException()
        {
            // Arrange
            int n = -5;
            // Assert
            Assert.Throws<ArgumentException>(() => _mathHelper.Factorial(n));
        }

        [Theory]
        [InlineData(1,false)]
        [InlineData(2, true)]
        [InlineData(3,true)]
        [InlineData(4,false)]
        [InlineData(5, true)]
        [InlineData(10, false)]
        [InlineData(11, true)]
        [InlineData(13, true)]
        [InlineData(17, true)]
        public void IsPrime_ShouldBeCorrectedResult(int number, bool expected)
        {
            // Act
            bool actual = _mathHelper.IsPrime(number);
            // Assert
            Assert.Equal(expected, actual);
        }
    }
}
