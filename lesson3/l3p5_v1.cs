using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

/* Написать программу, 
 * которая считывает с консоли число n 
 * и смешает одномерный массив на n 
 * (может быть положительным, или отрицательным). 
 * Для усложнения задачи нельзя пользоваться вспомогательными массивами. */

namespace l3p
{
    class l3p5_v1
    {
        public static void Array()
        {
            string[] array = { "1", "2", "3", "4", "5", "6" };
            int num = -2;
            array = ShiftArray(array, num);

            SelectArray(array);
        }
        public static string[] ShiftArray(string[] array, int num)
        {
            if(num > 0)
            {
                array = ShiftPlus(array);
                num--;
            }

            if(num < 0)
            {
                array = ShiftMinus(array);
                num++;
            }

            if(num != 0)
            {
                ShiftArray(array, num);
            }
            
            return array;
        }

        public static string[] ShiftMinus(string[] array)
        {
            string shift = array[array.Length - 1];

            for (int i = array.Length - 1; i > 0; i--)
            {
                array[i] = array[i - 1];
            }
            array[0] = shift;

            return array;
        }

        public static string[] ShiftPlus(string[] array)
        {
            string shift = array[0];
            for(int i = 0; i< array.Length - 1; i++)
            {
                array[i] = array[i + 1];
            }
            array[array.Length - 1] = shift;
            return array;
        }

        public static void SelectArray(string[] array)
        {
            string selectar = "";
            for(int i = 0; i < array.Length; i++)
            {
                selectar += $"{array[i]}, ";
            }
            Console.WriteLine(selectar);
        }
    }
}
