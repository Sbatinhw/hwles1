using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace l2p
{
    class l2p6
    {


        public static void list()
        {
            string day = "";
            
            int[] week = new int[] {
            0b1000000,
            0b0100000,
            0b0010000,
            0b0001000,
            0b0000100,
            0b0000010,
            0b0000001,
        };

            for(int i = 0; i < week.Length; i++)
            {
                switch (week[i])
                {
                    case 0b1000000: 
                        day = "Пн";
                            break;
                    case 0b0100000: 
                        day = "Вт";
                        break;
                    case 0b0010000: 
                        day = "Ср";
                        break;
                    case 0b0001000:
                        day = "Чт";
                        break;
                    case 0b0000100:
                        day = "Пт";
                        break;
                    case 0b0000010:
                        day = "Сб";
                        break;
                    case 0b0000001:
                        day = "Вс";
                        break;
                    default: day = "Праздник";
                        break;
                }

                if((week[i] | 0b0111110) == 0b0111110)
                {
                    day += " 10.00 - 20.00";
                } else
                {
                    day += " Выходной";
                }

                Console.WriteLine(day);

            }

        }

    }
}
