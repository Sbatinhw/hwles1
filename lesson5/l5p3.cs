using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

/* Ввести с клавиатуры произвольный набор чисел (0...255) и записать их в бинарный файл.*/

namespace l5p
{
    class l5p3
    {
        public static void WriteText()
        {
            string filename = "bytes.bin";

            Console.WriteLine("Введите через пробел числа от 0 до 255 для добавления в файл: ");

            string text = Console.ReadLine();

            string[] text_for_append = text.Split(' ');
            byte[] bytes_for_append = new byte[text_for_append.Length];
            for(int i = 0; i < bytes_for_append.Length; i++)
            {
                try
                {
                    bytes_for_append[i] = byte.Parse(text_for_append[i]);
                }
                catch
                {
                    continue;
                }
            }

            File.WriteAllBytes(filename, bytes_for_append);
            File.AppendAllText(filename, Environment.NewLine);

            Console.WriteLine("Строка записана");
        }
    }
}
