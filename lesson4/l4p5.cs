using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

/* Есть предложение String str1 = 
 * " Предложение один Теперь предложение два Предложение три"; 
 * нужно превести строку к нормально виду 
 * " Предложение один. Теперь предложение два. Предложение три" */

namespace l4p
{
    class l4p5
    {

        public static void NormalView()
        {
            string original_text = " Предложение один Теперь предложение два Предложение три";
            Console.WriteLine($"Исходный текст: \n{original_text}");
            Console.WriteLine($"Нормализованный текст: \n{ChangeText1(original_text)}");
            Console.WriteLine($"Нормализованный текст: \n{ChangeText2(original_text)}");
        }

        public static string ChangeText1(string line)
        {
            StringBuilder builder = new StringBuilder();
            bool start_text = false;
            for(int i = 0; i < line.Length; i++)
            {
                if (line[i] != ' ') start_text = true;

                try
                {
                    if (line[i] == ' ' && line[i + 1] == ' ')
                    {
                        continue;
                    }
                }
                catch
                {
                    continue;
                }

                if(line[i] == ' ' && Char.IsUpper(line[i + 1]) && start_text)
                {
                    builder.Append('.');
                }
                builder.Append(line[i]);
                if(i == line.Length - 1 && line[i] != '.')
                {
                    builder.Append('.');
                }
            }
            line = builder.ToString();

            return line;
        }


        public static string ChangeText2(string text)
        {
            string[] line = Regex.Split(text, @"(?<!^)(?=[А-Я])");
            text = "";
            for(int i = 0; i < line.Length; i++)
            {
                text += line[i];
                if (text[0] == ' ') text = text.Substring(1);
                try
                {
                    if (text[text.Length - 1] == ' ') text = text.Substring(0, text.Length - 1);
                }
                catch
                {
                    continue;
                }
                
                text += ". ";
            }
            return text;
        }


    }
}
