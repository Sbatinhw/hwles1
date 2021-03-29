using System;

namespace l1p1
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Введите имя:");
            string name = Console.ReadLine();

            Console.WriteLine($"Привет, {name}, сегодня {DateTime.Today:d}");


            Console.ReadLine();
        }
    }
}
