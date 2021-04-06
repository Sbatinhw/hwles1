using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace l4p
{
    /* Написать метод 
     * GetFullName(string firstName, string lastName, string patronymic), 
     * принимающий на вход ФИО в разных аргументах и возвращающий объединённую строку с ФИО. 
     * Используя метод, написать программу, выводящую в консоль 3–4 разных ФИО. */
    class l4p1
    {
        public static void FullName()
        {

        }

        public static void AskFLP()
        {
            Console.WriteLine("Введите имя:");
            string firstName = Console.ReadLine();
            Console.WriteLine("Введите фамилию: ");
            string lastName = Console.ReadLine();
            Console.WriteLine("Введите отчество:");
            string patronymic = Console.ReadLine();

        }

    }
}
