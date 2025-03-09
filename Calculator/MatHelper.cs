using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Calculator
{
    public class MathHelper
    {
        // Hàm tính giai thừa
        public int Factorial(int n)
        {
            if (n < 0) throw new ArgumentException("n must be non-negative");
            if (n == 0 || n == 1) return 1;

            int result = 1;
            for (int i = 2; i <= n; i++)
            {
                result *= i;
            }
            return result;
        }

        // Hàm kiểm tra số nguyên tố
        public bool IsPrime(int number)
        {
            if (number < 2) return false;
            for (int i = 2; i * i <= number; i++)
            {
                if (number % i == 0) return false;
            }
            return true;
        }
    }

}
