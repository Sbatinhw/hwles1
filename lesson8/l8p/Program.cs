using System;
using lesson8library;

namespace l8p
{
    class Program
    {
        static void Main(string[] args)
        {
            helloClass user = new helloClass();
            user.PrintHello();

            helloClass custom = new helloClass("Андрей", "Пивет..");
            custom.PrintHello();


            Console.ReadLine();
        }
    }
}
