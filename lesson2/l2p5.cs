using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace l2p
{
    class l2p5
    {
        public static void MounthTemp()
        {
            int mounth_num = l2p2.AskMounth();
            double day_temp = l2p1.CalcAverageTemp();
            if ((mounth_num < 3 || mounth_num > 11) && day_temp > 0)
                Console.WriteLine("Дождливая зима");
            else
                Console.WriteLine($"Указан месяц {l2p2.ConvertMounth(mounth_num)}, среднесуточная температура {day_temp}");
        }
    }
}
