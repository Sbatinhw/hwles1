using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Text.Json;
using System.IO;

/* Список задач (ToDo-list):
написать приложение для ввода списка задач;
задачу описать классом ToDo с полями Title и IsDone;
на старте, если есть файл tasks.json/xml/bin (выбрать формат), загрузить из него массив имеющихся задач и вывести их на экран;
если задача выполнена, вывести перед её названием строку «[x]»;
вывести порядковый номер для каждой задачи;
при вводе пользователем порядкового номера задачи отметить задачу с этим порядковым номером как выполненную;
записать актуальный массив задач в файл tasks.json/xml/bin.*/

namespace l5p
{
    class l5p5
    {
        public static void ToDo_list()
        {

        }
        public static void main_menu()
        {
            ToDo[] list = new ToDo[0];
            string filename = "tasks.json";
            bool flag = true;

            if (File.Exists(filename))
            {
                string json = File.ReadAllText(filename);
                list = JsonSerializer.Deserialize<ToDo[]>(json);
            }

            while (flag)
            {
                Console.WriteLine($"\nСписок действий: ");
                Console.WriteLine("1 - добавить задание"); // +
                Console.WriteLine("2 - найти задание по номеру"); // +
                Console.WriteLine("3 - показать список невыполненных заданий"); //-
                Console.WriteLine("4 - показать список всех заданий"); //+
                Console.WriteLine("0 - выход");
                Console.WriteLine($"Введите номер действия: ");
                string s = Console.ReadLine();
                Console.Clear();
                switch (s)
                {
                    case "0":
                        flag = false;
                        break;
                    case "1":
                        add_todo(ref list);
                        continue;
                    case "2":
                        search_todo(list);
                        continue;
                    case "3":
                        select_not_done(list);
                        continue;
                    case "4":
                        select_all_todo(list);
                        continue;
                    default: continue;
                }

            }

            {
                string json = JsonSerializer.Serialize(list);
                File.WriteAllText(filename, json);
            }
            
        }

        public static void select_not_done(ToDo[] list)
        {
            for(int i = 0; i < list.Length; i++)
            {
                if(!list[i].isDone)
                {
                    Console.WriteLine(list[i].ToString());
                }
            }
        }

        public static void search_todo(ToDo[] list)
        {
            Console.WriteLine("Введите номер задания: ");
            string num = Console.ReadLine();
            Console.WriteLine("Задание по вашему запросу: ");
            try
            {
                string x = list[int.Parse(num) - 1].ToString();
                Console.WriteLine(x);
            }
            catch
            {
                Console.WriteLine("Не найдено");
                return;
            }
            bool flag = true;
            while (flag)
            {
                Console.WriteLine("Отметить как выполненное? \n 0 - да \n 1 - нет");
                switch (Console.ReadLine())
                {
                    case "0":
                        list[int.Parse(num) - 1].isDone = true;
                        return;
                    case "1":
                        return;
                    default: continue;
                }
            }

        }

        public static void add_todo(ref ToDo[] list)
        {
            Array.Resize(ref list, list.Length + 1);
            Console.WriteLine("\nВведите текст нового задания:");
            list[list.Length - 1] = new ToDo(Console.ReadLine());
            Console.WriteLine($"Задание добавлено под номером {list.Length}");
        }
        public static void select_all_todo(ToDo[] list)
        {
            Console.WriteLine("\n");
            for(int i = 0; i < list.Length; i++)
            {
                Console.WriteLine($"{i + 1} {list[i].ToString()}");
            }
        }

    }

    class ToDo
    {
        public string Title { get; set; }
        public bool isDone { get; set; }
        public ToDo()
        {

        }
        public ToDo(string n)
        {
            Title = n;
            isDone = false;
        }
        public override string ToString()
        {
            if (isDone == false) 
            {
                return $"[ ] {Title}";
            }
            return $"[x] {Title}";

        }
    }

}
