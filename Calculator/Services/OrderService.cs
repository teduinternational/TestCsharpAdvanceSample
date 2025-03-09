using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Calculator.Services
{
    public class OrderService
    {
        private readonly IPaymentProcessor _paymentProcessor;

        public OrderService(IPaymentProcessor paymentProcessor)
        {
            _paymentProcessor = paymentProcessor;
        }

        public bool PlaceOrder(decimal orderAmount)
        {
            if (orderAmount <= 0) return false;
            return _paymentProcessor.ProcessPayment(orderAmount);
        }
    }

}
