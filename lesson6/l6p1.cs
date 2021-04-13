using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Diagnostics;

/* Написать консольное приложение Task Manager, 
 * которое выводит на экран запущенные процессы 
 * и позволяет завершить указанный процесс. 
 * Предусмотреть возможность завершения процессов 
 * с помощью указания его ID или имени процесса. 
 * В качестве примера можно использовать консольные 
 * утилиты Windows tasklist и taskkill.*/

namespace l6p
{
    class l6p1
    {
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
                    if(processes_for_kill.Length < 1)
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
                    for(int i = 0; i< processes_for_kill.Length; i++)
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
            if(sure == "0")
            {
                return true;
            }
            return false;
        }

        public static void select_array(Process[] process_list)
        {
            for(int i = 0; i < process_list.Length; i++)
            {
                Console.WriteLine($"\nID: {process_list[i].Id} \nИмя: {process_list[i].ProcessName}");
            }
        }
        public static Process[] create_array_process()
        {
            return Process.GetProcesses();
        }
    }
}
