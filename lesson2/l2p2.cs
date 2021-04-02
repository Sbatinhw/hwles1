using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace l2p
{
    class l2p2
    {
        public static void Mounth()
        {
            Console.WriteLine($"Введен месяц: {ConvertMounth(AskMounth())}");
        }

        public static string ConvertMounth(int insert_value)
        {
            string name_mounth = "";
            switch (insert_value)
            {
                case 1: 
                    name_mounth = "Январь";
                    break;
                case 2: 
                    name_mounth = "Февраль";
                    break;
                case 3:
                    name_mounth = "Март";
                    break;
                case 4:
                    name_mounth = "Апрель";
                    break;
                case 5:
                    name_mounth = "Май";
                    break;
                case 6:
                    name_mounth = "Июнь";
                    break;
                case 7:
                    name_mounth = "Июль";
                    break;
                case 8:
                    name_mounth = "Август";
                    break;
                case 9:
                    name_mounth = "Сентябрь";
                    break;
                case 10:
                    name_mounth = "Октябрь";
                    break;
                case 11:
                    name_mounth = "Ноябрь";
                    break;
                case 12:
                    name_mounth = "Декабрь";
                    break;
            }
            return name_mounth;
        }

        public static int AskMounth()
        {
            bool insert_value = true;
            int num_mounth = 0;
            while (insert_value)
            {
                Console.WriteLine("Введите номер месяца: ");
                insert_value = int.TryParse(Console.ReadLine(), out num_mounth);
                if (insert_value && num_mounth > 0 && num_mounth <= 12) break;

                insert_value = true;
                Console.WriteLine("Введено некорректное значение. Попробуйте снова.");
            }

            return num_mounth;

        }
    }
}
