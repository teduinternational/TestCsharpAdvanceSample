using Calculator;
using Calculator.Services;
using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _6._1.UnitTesting
{
    public class OrderServiceTests
    {
        [Fact]
        public void PlaceHolder_ShouldReturnTrue_WhenPaymentIsSuccessful()
        {
            // Arrange
            var paymentProcessor = new Mock<IPaymentProcessor>();

            paymentProcessor.Setup(x => x.ProcessPayment(It.IsAny<decimal>())).Returns(true);

            var orderService = new OrderService(paymentProcessor.Object);
            // Act
            var result = orderService.PlaceOrder(100);
            // Assert
            Assert.True(result);
        }

        [Fact]
        public void PlaceHolder_ShouldReturnFalse_WhenPaymentIsFailure()
        {
            // Arrange
            var paymentProcessor = new Mock<IPaymentProcessor>();

            paymentProcessor.Setup(x => x.ProcessPayment(It.IsAny<decimal>())).Returns(false);

            var orderService = new OrderService(paymentProcessor.Object);
            // Act
            var result = orderService.PlaceOrder(100);
            // Assert
            Assert.False(result);
            paymentProcessor.Verify(p => p.ProcessPayment(100), Times.Once);
        }

        [Fact]
        public void PlaceHolder_ShouldReturnFalse_WhenAmountLessThanZero()
        {
            // Arrange
            var paymentProcessor = new Mock<IPaymentProcessor>();
            var orderService = new OrderService(paymentProcessor.Object);
            // Act
            var result1 = orderService.PlaceOrder(0);
            var result2 = orderService.PlaceOrder(-100);

            // Assert
            Assert.False(result1);
            Assert.False(result2);

            paymentProcessor.Verify(p => p.ProcessPayment(100), Times.Never);
        }
    }
}
