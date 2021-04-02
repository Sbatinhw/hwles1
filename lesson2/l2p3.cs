using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace l2p
{
    class l2p3
    {
        public static void EvenNumber()
        {
            bool insert_value = true;
            int return_value = 0;
            while (insert_value) {
                Console.WriteLine("Введите число: ");
                insert_value = int.TryParse(Console.ReadLine(), out return_value);
                if (insert_value) break;
                insert_value = true;
                Console.WriteLine("Введено некорректное значение. Попробуйте снова.");
            }
            if (CheckEven(return_value) == 1)
                Console.WriteLine($"Введенное число {return_value} четное") ;
            else
                Console.WriteLine($"Введенное число {return_value} нечетное");

        }

        public static int CheckEven(int num_for_check)
        {
            if (num_for_check % 2 == 0) return 1;
            else return 0;
        }

    }
}
