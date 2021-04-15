using System;
using System.Diagnostics;


namespace l6p
{
    class Program
    {
        static void Main(string[] args)
        {
            TaskManager();

            string[,] array = new string[2, 3] { {"1","1", "?" }, {"x", "1", "1" } };
            Console.WriteLine( $"\nСумма ячеек массива: {SummArray(array)}");

            Console.ReadLine();
        }

        
        public static void TaskManager()
        {
            select_array(create_array_process());
            Kill_process();
            Console.WriteLine("Конец программы.");

        }

        public static void Kill_process()
        {
            Console.WriteLine("\nВведите ID или имя процесса: ");
            string ask_process = Console.ReadLine();
            bool how_kill = int.TryParse(ask_process, out int id_process);

            if (how_kill)
            {
                Process process_for_kill = new Process();

                try
                {
                    process_for_kill = Process.GetProcessById(id_process);
                }
                catch (Exception ex)
                {
                    //Console.WriteLine(ex);
                    Console.WriteLine("Найдено 0 процессов.");
                    return;
                }
                if (sure_kill(process_for_kill))
                {
                    process_for_kill.Kill();
                    Console.WriteLine("Процесс остановлен.");
                }
            }
            else
            {
                Process[] processes_for_kill = new Process[0];
                try
                {
                    processes_for_kill = Process.GetProcessesByName(ask_process);
                    if (processes_for_kill.Length < 1)
                    {
                        throw new Exception("Длинна массива равна нулю");
                    }
                }
                catch (Exception ex)
                {
                    //Console.WriteLine(ex);
                    Console.WriteLine("Найдено 0 процессов.");
                    return;
                }

                if (sure_kill(processes_for_kill))
                {
                    for (int i = 0; i < processes_for_kill.Length; i++)
                    {
                        processes_for_kill[i].Kill();
                    }
                    Console.WriteLine("Процессы остановлены.");
                }
            }
        }

        public static bool sure_kill(Process[] process_for_kill)
        {
            Console.WriteLine($"\nВы уверены что хотите завершить процессы?");
            select_array(process_for_kill);
            Console.WriteLine("\n0 - Да\n1 - Нет");
            string sure = Console.ReadLine();
            if (sure == "0")
            {
                return true;
            }
            return false;
        }

        public static bool sure_kill(Process process_for_kill)
        {
            Console.WriteLine($"\nВы уверены что хотите завершить процесс \n{process_for_kill}?");
            Console.WriteLine("\n0 - Да\n1 - Нет");
            string sure = Console.ReadLine();
            if (sure == "0")
            {
                return true;
            }
            return false;
        }

        public static void select_array(Process[] process_list)
        {
            for (int i = 0; i < process_list.Length; i++)
            {
                Console.WriteLine($"\nID: {process_list[i].Id} \nИмя: {process_list[i].ProcessName}");
            }
        }
        public static Process[] create_array_process()
        {
            return Process.GetProcesses();
        }


        //задание №2
        /*  Напишите метод, на вход которого подаётся двумерный строковый массив размером 4х4,
            при подаче массива другого размера необходимо бросить исключение MyArraySizeException.
            Далее метод должен пройтись по всем элементам массива, преобразовать в int, и просуммировать.
            Если в каком-то элементе массива преобразование не удалось
            (например, в ячейке лежит символ или текст вместо числа), 
            должно быть брошено исключение MyArrayDataException, 
            с детализацией в какой именно ячейке лежат неверные данные.
            В методе main() вызвать полученный метод, 
            обработать возможные исключения MySizeArrayException и MyArrayDataException, 
            и вывести результат расчета.*/

        public static int SummArray(string[,] array_for_check)
        {
            int max_rows = 4;
            int max_columns = 4;
            int rows = array_for_check.GetUpperBound(0) + 1;
            int column = array_for_check.Length / rows;
            int summ = 0;
            try
            {
                if (rows != max_rows || column != max_columns)
                {
                    throw new MyArraySizeException("Длина массива не соответствует заданным параметрам");
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
            }

            for (int i = 0; i < rows; i++)
            {
                for (int j = 0; j < column; j++)
                {
                    try
                    {
                        bool trysumm = int.TryParse(array_for_check[i, j], out int num);

                        if (trysumm)
                        {
                            summ += num;
                        }
                        else
                        {
                            throw new MyArrayDataException(i, j);
                        }

                    }
                    catch (Exception ex)
                    {
                        Console.WriteLine(ex);
                    }
                }
            }

            return summ;


        }

    }

    [Serializable]
    public class MyArrayDataException : Exception
    {
        string text_exception { get; set; }
        public MyArrayDataException() { }


        public MyArrayDataException(int x, int y)
        {
            text_exception = $"Некорректное значение в ячейке {x} {y}";
        }

        public override string ToString()
        {
            return text_exception;
        }
    }

    [Serializable]
    public class MyArraySizeException : Exception
    {
        public MyArraySizeException() { }
        public MyArraySizeException(string message)
            : base(message) { }
        public MyArraySizeException(string message, Exception inner)
            : base(message, inner) { }

        public override string ToString()
        {
            return Message;
        }

    }

}

