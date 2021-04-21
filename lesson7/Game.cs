using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CrossZero
{
    class Game
    {
        static int size_x = 3;
        static int size_y = 3;
        static int win_len = 4;

        static char[,] field = new char[size_y, size_x];
        


        static char player_dot = 'X';
        static char ai_dot = '0';
        static char empty_dot = '.';

        static Random random = new Random();


        public static void StartGame()
        {


            field = CreateEmptyField(field, empty_dot);

            SelectField(field);
            //Console.WriteLine(IsCellValid(1, 1));

            do
            {
                playerMove();
                Console.WriteLine("Ваш ход на поле");
                SelectField(field);
                if (CheckWin(player_dot))
                {
                    Console.WriteLine("Вы выиграли");
                    break;
                }
                else if (IsFieldFull()) break;
                aiMove();
                Console.WriteLine("Ход Компа на поле");
                SelectField(field);
                if (CheckWin(ai_dot))
                {
                    Console.WriteLine("Выиграли Комп");
                    break;
                }
                else if (IsFieldFull()) break;
                
            } while (true);
            Console.WriteLine("!Конец игры!");

        }

        

        public static bool CheckWin(char sym)
        {
            if(CheckHorizontal(sym) || CheckVertical(sym) 
                || CheckDiagonal(sym) || CheckDiagonalRev(sym))
            {
                return true;
            }

            return false;
        }

        

        public static bool CheckDiagonal(char sym)
	{
		int rows = field.GetUpperBound(0) + 1;
		int columns = field.Length / rows;
		int win = 0;
		
		for(int x = 0; x < rows; x++)
		{
			for(int i = 0; i < rows; i++)
			{
				for(int j = 0; j < columns; j++)
				{
					if(i - x == j )
					{
						if (CheckPoint(i, j, sym)) { win++; }
                        else if (!CheckPoint(i, j, sym)) { win = 0; }
                        if (win == win_len) { return true; }
						
					}
				}
			}	
		}
		
		win = 0;
		
		for(int x = 0; x < columns; x++)
		{
			for(int i = 0; i < rows; i++)
			{
				for(int j = 0; j < columns; j++)
				{
					if(i == j - x)
					{
						if (CheckPoint(i, j, sym)) { win++; }
                        else if (!CheckPoint(i, j, sym)) { win = 0; }
                        if (win == win_len) { return true; }
					}	
				}	
			}	
		}	
		return false;	
	}
	
	
	
	public static void CheckDiagonalRev(char sym)
	{
		int rows = field.GetUpperBound(0) + 1;
		int columns = field.Length / rows;
		int win = 0;
		
		for(int x = 0; x < rows ; x++)
		{
			for(int i = 0; i < rows; i++)
			{
				for(int j = columns - 1; j > -1; j--)
				{
					
					if(rows - i + x == j)
					{
						if (CheckPoint(i, j, sym)) { win++; }
                        else if (!CheckPoint(i, j, sym)) { win = 0; }
                        if (win == win_len) { return true; }
						
					}	
				}
			}
		}
		
		win = 0;
		
		for(int x = 0; x < columns ; x++)
		{
			for(int i = 0; i < rows; i++)
			{
				for(int j = columns - 1; j > -1; j--)
				{
					if(columns - i - 1 - x == j )
					
					{
						if (CheckPoint(i, j, sym)) { win++; }
                        else if (!CheckPoint(i, j, sym)) { win = 0; }
                        if (win == win_len) { return true; }
						
					}						
				}	
			}	
		}
		return false;
	}


        public static bool CheckVertical(char sym)
        {
            int rows = field.GetUpperBound(0) + 1;
            int columns = field.Length / rows;

            for (int i = 0; i < columns; i++)
            {
                int win = 0;
                for (int j = 0; j < rows; j++)
                {
                    if (CheckPoint(j, i, sym)) { win++; }
                    else if (!CheckPoint(j, i, sym)) { win = 0; }
                    if (win == win_len) { return true; }

                }
            }
            return false;

        }

        public static bool CheckHorizontal(char sym)
        {
            int rows = field.GetUpperBound(0) + 1;
            int columns = field.Length / rows;
            
            for(int i = 0; i < rows; i++)
            {
                int win = 0;
                for (int j = 0; j < columns; j++)
                {
                    if(CheckPoint(i, j, sym)) { win++; }
                    else if (!CheckPoint(i, j, sym)) { win = 0; }
                    if(win == win_len) { return true; }

                }
            }
            return false;

        }

        public static bool CheckPoint(int y, int x, char sym)
        {
            return field[y, x] == sym;
        }

        public static void aiMove()
        {
            int x, y;
            do
            {
                x = random.Next(0, size_x);
                y = random.Next(0, size_y);
            } while (!IsCellValid(y, x));
            SetSym(y, x, ai_dot);
        }

        public static void playerMove()
        {
            int x, y;
            do
            {
                Console.WriteLine("Координаты по строке");
                Console.WriteLine($"Введите координаты хода в диапозоне от 1 до {size_y}");
                x = Int32.Parse(Console.ReadLine()) - 1;
                Console.WriteLine("Координаты по столбцу");
                Console.WriteLine($"Введите координаты хода в диапозоне от 1 до {size_x}");
                y = Int32.Parse(Console.ReadLine()) - 1;


            } while (!IsCellValid(x, y));
            SetSym(y, x, player_dot);


        }

        private static bool IsFieldFull()
        {

            for(int i = 0; i < size_y; i++)
            {
                for(int j = 0; j < size_x; j++)
                {
                    if(field[i, j] == empty_dot)
                    {
                        return false;
                    }
                }


            }
            return true;
        }

        public static void SetSym(int y, int x, char sym)
        {
            field[y, x] = sym;
        }

        public static bool IsCellValid(int y, int x)
        {
            if (x < 0 || y < 0 || x >= size_x - 1 || y >= size_y - 1)
            {
                return false;
            }
            return field[y, x] == empty_dot;
        }


        public static char[,] CreateEmptyField(char[,] field, char emp_dot)
        {
            int rows = field.GetUpperBound(0) + 1;
            int columns = field.Length / rows;


            for (int i = 0; i < rows; i++)
            {
                for (int j = 0; j < columns; j++)
                {
                    field[i, j] = emp_dot;
                }
            }
            return field;
        }

        public static void SelectField(char[,] field)
        {
            int rows = field.GetUpperBound(0) + 1;
            int columns = field.Length / rows;
            StringBuilder line = new StringBuilder();

            for (int i = 0; i < columns * 2 + 1; i++)
            {
                line.Append("-");
            }

            line.Append("\n");


            for (int i = 0; i < rows; i++)
            {
                Console.Write(line);
                for(int j = 0; j< columns; j++)
                {
                    Console.Write($"|{field[i, j]}");


                }
                Console.Write("|");
                Console.Write("\n");
            }
            Console.Write(line);


        }





        //
    }
}
