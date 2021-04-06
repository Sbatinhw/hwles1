using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

/*Написать программу, выводящую элементы двухмерного массива по диагонали.*/

namespace l3p
{
    class l3p1
    {
        public static void Part1()
        {
            int[,] array = { { 1, 2, 3 }, { 4, 5, 6 }, { 7, 8, 9 } };
            int rows = array.GetUpperBound(0) + 1;
            int column = array.Length / rows;
            for (int i = 0; i < rows; i++)
            {
                for(int j = 0; j < column; j++)
                {
                    if(i == j)
                    {
                        Console.WriteLine(array[i, j]);
                    }
                }
            }

        }
    }
}
