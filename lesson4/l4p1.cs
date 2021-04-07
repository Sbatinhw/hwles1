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
            Console.WriteLine(AskFLP());
        }

        public static string AskFLP()
        {
            Console.WriteLine("Введите имя:");
            string firstName = Console.ReadLine();
            Console.WriteLine("Введите фамилию: ");
            string lastName = Console.ReadLine();
            Console.WriteLine("Введите отчество:");
            string patronymic = Console.ReadLine();

            return GetFullName(firstName, lastName, patronymic); 

        }

        public static string GetFullName(string firstName, string lastName, string patronymic)
        {
            return $"\nИмя: {firstName}\nФамилия: {lastName}\nОтчество: {patronymic}";
        } 


    }
}
