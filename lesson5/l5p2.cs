using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

/* Написать программу, которая при старте дописывает текущее время в файл «startup.txt».*/

namespace l5p
{
    class l5p2
    {
        public static void WriteTime()
        {
            string filename = "strtup.txt";
            string text_for_append = DateTime.Now.ToString("HH:mm:ss tt");

            File.AppendAllText(filename, text_for_append);
            File.AppendAllText(filename, Environment.NewLine);

            Console.WriteLine($"Записано значение: {text_for_append}");
        }
    }
}
