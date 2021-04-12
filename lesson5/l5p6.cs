using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

/* Создать класс "Сотрудник" с полями: ФИО, должность, email, телефон, зарплата, возраст;
Конструктор класса должен заполнять эти поля при создании объекта;
Внутри класса «Сотрудник» написать метод, который выводит информацию об объекте в консоль;
Создать массив из 5 сотрудников

Пример:
Person[] persArray = new Person[5]; // Вначале объявляем массив объектов
persArray[0] = new Person("Ivanov Ivan", "Engineer", "ivivan@mailbox.com", "892312312", 30000, 30); // потом для каждой ячейки массива задаем объект
persArray[1] = new Person(...);
...
persArray[4] = new Person(...);

С помощью цикла вывести информацию только о сотрудниках старше 40 лет; */

namespace l5p
{
    class l5p6
    {
        public static void Person_list()
        {
            Person[] person_list = Create_array();
            select_more_age(person_list, 40);
        }

        public static void select_more_age(Person[] person_list, int age)
        {
            for(int i = 0; i < person_list.Length; i++)
            {
                if(person_list[i].age > 40)
                {
                    person_list[i].Select_info();
                }
            }
        }


        public static Person[] Create_array()
        {
            Person[] person_list = new Person[5];
            person_list[0] = new Person("Смирнов М.И.", "инженер",
    "smir85@mail.ru",
    "9-720-111-11-12-15",
    30000, 40);

            person_list[1] = new Person("Петров В.Г.", "проектировщик",
    "petro22_15@mail.ru",
    "9-720-111-11-12-16",
    35000, 43);

            person_list[2] = new Person("Васильев Т.Р.", "разнорабочий",
    "vasilievtr@mail.ru",
    "9-720-111-11-12-44",
    25000, 32);

            person_list[3] = new Person("Третьяков Р.Р.", "разнорабочий",
    "rtret@mail.ru",
    "9-720-111-11-11-22",
    25000, 43);

            person_list[4] = new Person("Михайлов М.П.", "инженер",
    "mikhaiylov@mail.ru",
    "9-720-111-11-11-23",
    33000, 45);

            return person_list;

        }
    }
    

    class Person
    {
        public string FLP { get; set; }
        public string work { get; set; }
        public string email { get; set; }
        public string phone { get; set; }
        public decimal pay { get; set; }
        public int age { get; set; }
        public Person(string _flp, string _work, string _email, string _phone, decimal _pay, int _age)
        {
            FLP = _flp;
            work = _work;
            email = _email;
            phone = _phone;
            pay = _pay;
            age = _age;
        }
        public void Select_info()
        {
            Console.WriteLine($"ФИО: {FLP}\nДолжность: {work}\nemail: {email}\nТелефон: {phone}\nЗарплата: {pay}\nВозраст: {age}\n");
        }
    }
}
