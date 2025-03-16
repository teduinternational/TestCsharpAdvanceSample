using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Calculator
{
    public class StringCalculator
    {
        public int Add(string numbers)
        {
            if (string.IsNullOrEmpty(numbers))
            {
                return 0;
            }
            return numbers.Split(',')
                .Where(n => int.TryParse(n, out _))
                .Select(int.Parse)
                .Sum();
        }
    }
}
