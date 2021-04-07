using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

/* Написать программу, 
 * вычисляющую число Фибоначчи для заданного значения рекурсивным способом. */

namespace l4p
{
    class l4p4
    {
        public static void Fib()
        {
            CalcFibonachi(10);
        }
        public static void CalcFibonachi(int fib, int num1 = 0, int num2 = 1)
        {

            Console.Write($"{num1}, ");
            if (num2 >= fib) 
            {
                Console.Write(fib);
                return; }

            CalcFibonachi(fib, num2, num2 + num1);

        }
    }
}
