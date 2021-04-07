using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

/* Написать метод по определению времени года. 
 * На вход подаётся число – порядковый номер месяца. 
 * На выходе — значение из перечисления (enum) — 
 * Winter, Spring, Summer, Autumn. 
 * Написать метод, принимающий на вход значение 
 * из этого перечисления и возвращающий название времени года 
 * (зима, весна, лето, осень). 
 * Используя эти методы, ввести с клавиатуры номер месяца 
 * и вывести название времени года. 
 * Если введено некорректное число, 
 * вывести в консоль текст «Ошибка: введите число от 1 до 12» */

namespace l4p
{
    class l4p3
    {
        public static void YearSeason()
        {
            Console.WriteLine("Введите номер месяца: ");
            SelectSeason(SeasonNum(Console.ReadLine()));
        }

        enum Seasons
        {
            Winter = 1,
            Spring,
            Summer,
            Autumn
        }

        public static void SelectSeason(int seasnum)
        {
            string season_name = "";
            switch(seasnum)
            {
                case 1:
                    season_name = "зима";
                    break;
                case 2:
                    season_name = "весна";
                    break;
                case 3:
                    season_name = "лето";
                    break;
                case 4:
                    season_name = "осень";
                    break;
                case 0:
                    Console.WriteLine("Ошибка: введите число от 1 до 12");
                    return;
                    break;
            }
            Console.WriteLine($"Указано время года: {season_name}");

        }

        public static int SeasonNum(string mounthnum)
        {
            int mounth = 0;
            if (!int.TryParse(mounthnum, out mounth)) return 0;
            switch (mounth)
            {
                case 3:
                    return (int)Seasons.Spring;
                    break;
                case 4:
                    goto case 3;
                case 5:
                    goto case 3;
                case 6:
                    return (int)Seasons.Summer;
                    break;
                case 7:
                    goto case 6;
                case 8:
                    goto case 6;
                case 9:
                    return (int)Seasons.Autumn;
                    break;
                case 10:
                    goto case 9;
                case 11:
                    goto case 9;
                case 12:
                    return (int)Seasons.Winter;
                    break;
                case 1:
                    goto case 12;
                case 2:
                    goto case 12;

            }
            return 0;

        }

    }
}
