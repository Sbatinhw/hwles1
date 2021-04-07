using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace l4p
{
    /* Написать программу, 
     * принимающую на вход строку — набор чисел, 
     * разделенных пробелом, и возвращающую число — 
     * сумму всех чисел в строке. 
     * Ввести данные с клавиатуры и вывести результат на экран.*/
    class l4p2
    {
        public static void SumString()
        {
            int summ = CreateNum(AskLine());
            Console.WriteLine($"Сумма введенных чисел равна: {summ}");
        }

        public static string AskLine()
        {
            Console.WriteLine("Введите цифры разделённые пробелами: ");
            return Console.ReadLine();
        }

        public static int CreateNum(string line)
        {
            int number = 0;
            int summ = 0;
            string[] nums = line.Split(new char[] { ' ' });
            for (int i = 0; i < nums.Length; i++)
            {
                if(!int.TryParse(nums[i], out number))
                {
                    continue;
                }
                summ += number;
            }
            return summ;
        }

    }
}
