using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

/*Написать программу — телефонный справочник — 
  создать двумерный массив 5*2, 
  хранящий список телефонных контактов: 
  первый элемент хранит имя контакта, 
  второй — номер телефона/e-mail.
 */

namespace l3p
{
    class l3p2
    {
        public static void Contact_list()
        {
            string[,] list = { { "Михаил", "713-66-144"},
            { "Александр", "mail@mail.com"} };
            Print_list(list);

        }
        //вывести список всех контактов
        public static void Print_list(string[,] list)
        {
            for(int i = 0; i < list.GetUpperBound(0) + 1; i++)
            {
                Print_list(list, i);
            }
        }

        //вывести один контакт из списка
        public static void Print_list(string[,] list, int num_contact)
        {
            Console.WriteLine($"Имя: {list[num_contact, 0]} Почта/телефон: {list[num_contact, 1]}");
        }


    }
    

}
