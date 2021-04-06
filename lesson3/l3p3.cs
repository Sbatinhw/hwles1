using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

/* Написать программу, 
 * выводящую введенную пользователем строку 
 * в обратном порядке (olleH вместо Hello). */

namespace l3p
{
    class l3p3
    {
        public static void ReversLine()
        {
            Console.WriteLine("Введите строку: ");
            string line = Console.ReadLine();
            string newline = "";
            for(int i = 0; i < line.Length; i++)
            {
                newline = line[i].ToString() + newline; 
            }
            Console.WriteLine($"Обратная строка: {newline}");
        }
    }
}
