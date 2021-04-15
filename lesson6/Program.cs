using System;

namespace l6p
{
    class Program
    {
        static void Main(string[] args)
        {
            //l6p1.TaskManager();
            string[,] array = new string[2, 3] { {"1","1", "?" }, {"x", "1", "1" } };
            Console.WriteLine( $"\nСумма ячеек массива: {l6p1.SummArray(array)}");

            Console.ReadLine();
        }
    }
}
