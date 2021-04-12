using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

/* Ввести с клавиатуры произвольный набор данных и сохранить его в текстовый файл.*/

namespace l5p
{
    class l5p1
    {
        public static void WriteText()
        {
            string filename = "text.txt";
            string text_for_append = "";

            Console.WriteLine("Введите текст для добавления в файл: ");

            text_for_append = Console.ReadLine();

            File.AppendAllText(filename, text_for_append);
            File.AppendAllText(filename, Environment.NewLine);

            Console.WriteLine("Строка записана");
        }
    }
}
