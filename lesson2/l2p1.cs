using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace l2p
{
    class l2p1
    {
        

        public static void AverageTemp()
        {
            Console.WriteLine($"Среднесуточная температура: {CalcAverageTemp()}");

        }
        public static double  CalcAverageTemp()
        {
            return (AskTemp(0) + AskTemp(1)) / 2;
        }

        public static double AskTemp(int max_or_min)
        {
            bool insert_value = true;
            double return_value = 0;
            string text_for_console = "";

            if (max_or_min == 0) text_for_console = "максимальную";
            else text_for_console = "минимальную";

            while (insert_value)
            {
                Console.WriteLine($"Введите {text_for_console} температуру:");
                insert_value = double.TryParse(Console.ReadLine(), out return_value);
                if (insert_value) break;
                else
                    insert_value = true;
                Console.WriteLine("Введено некорректное значение. Попробуйте снова.");
            }
            return return_value;
        }
    }
}
