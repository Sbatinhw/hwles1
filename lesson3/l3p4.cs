using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace l3p
{
    /*«Морской бой» — вывести на экран массив 10х10, 
     * состоящий из символов X и O, 
     * где Х — элементы кораблей, 
     * а О — свободные клетки.*/
    class l3p4
    {
        public static void SeaBattle()
        {
            string[,] field = Create_Field(9, 10);
            // длина коробля, положение (1 - вертикально, 0 - горизонтально),
            // координаты первой точки 
            int[,] ships = { {3, 1, 2, 1 }, {2, 0, 9, 8 } };
            field = Insert_Ship(field, ships);

            Select_field(field);
        }

        public static bool Check_Ship(int[] ship, string[,] field)
        {
            int point_x = ship[2] - 1;
            int point_y = ship[3] - 1;
            int up_x = 0;
            int up_y = 0;
            int rows = field.GetUpperBound(0) + 1;
            int columns = field.Length / rows;

            if (ship[1] == 0)
            {
                up_y = 1;
            }
            else
            {
                up_x = 1;
            }

            for (int i = 0; i < ship[0] + 2; i++)
            {
                int c_point_x = point_x;
                int c_point_y = point_y;
                for (int j = 0; j < 3; j++)
                {
                    if ((c_point_x >= rows || c_point_x < 0))
                    {
                        if (j == 1 && (i > 0 && i < ship[0] + 1)) return false;
                        continue;
                    }
                    if ((c_point_y >= columns || c_point_y < 0))
                    {
                        if (j == 1 && (i > 0 && i < ship[0] + 1)) return false;
                        continue;
                    }

                    if(field[c_point_x, c_point_y] != "o")
                    {
                        return false;
                    }
                    c_point_x += up_y;
                    c_point_y += up_x;
                }
                point_x += up_x;
                point_y += up_y;
            }

            return true;
        }

        public static int[] CreateOneShip(int[,] ship, int num)
        {
            int rows = ship.GetUpperBound(0) + 1;
            int columns = ship.Length / rows;

            int[] one_ship = new int[columns];
            for(int i = 0; i < columns; i++)
            {
                one_ship[i] = ship[num, i];
            }

            return one_ship;
        }

        public static string[,] Insert_Ship(string[,] field, int[,] ship)
        {
            int rows = ship.GetUpperBound(0) + 1;
            int columns = ship.Length / rows;
            for(int i = 0;i < rows; i++)
            {
                if (!Check_Ship(CreateOneShip(ship, i), field))
                {
                    Console.WriteLine($"Корабль №{i + 1} не добавлен на поле.");
                    continue;
                }
                int pos_x = ship[i, 2];
                int pos_y = ship[i, 3];
                int up_x = 0;
                int up_y = 0;
                if (ship[i, 1] == 0)
                {
                    up_y = 1;
                } else
                {
                    up_x = 1;
                }
                for(int j = 0; j < ship[i, 0]; j++)
                {
                    field[pos_x, pos_y] = "x";
                    pos_x += up_x;
                    pos_y += up_y;
                }
            }

            return field;
        }

        public static void Select_field(string[,] field)
        {
            int rows = field.GetUpperBound(0) + 1;
            int columns = field.Length / rows;
            for (int i = 0; i < rows; i++)
            {
                for (int j = 0; j < columns; j++)
                {
                    Console.Write(field[i, j]);
                }
                Console.WriteLine();
            }
        }
        public static string[,] Create_Field(int x, int y)
        {
            string[,] field = new string[x, y];
            for(int i = 0; i < x; i++)
            {
                for(int j = 0; j < y; j++)
                {
                    field[i, j] = "o";
                }
            }
            return field;
        }
    }
}
