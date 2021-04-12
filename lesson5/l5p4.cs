using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

/* Сохранить дерево каталогов и файлов 
 * по заданному пути в текстовый файл — с рекурсией и без. */

namespace l5p
{
    class l5p4
    {
        public static void CatalogTree()
        {
            string start_catalog = @"C:\Users\user\source\repos\hwles1\lesson5";
            ReadCatalog(start_catalog);

            
        }

        public static void ReadCatalog(string start_catalog)
        {
            string filename = "catalog.txt";
            
            if (Directory.Exists(start_catalog))
            {
                string[] files = Directory.GetFiles(start_catalog);
                DirectoryInfo di = new DirectoryInfo(start_catalog);

                File.AppendAllText(filename, $"\n \nФайлы каталога: {di.Name}");

                for (int i = 0; i < files.Length; i++)
                {
                    File.AppendAllText(filename, $"\n{Path.GetFileName(files[i])}");
                }

                string[] direct = Directory.GetDirectories(start_catalog);
                File.AppendAllText(filename, $"\n \nПодкаталоги каталога: {di.Name}");


                for (int i = 0; i < direct.Length; i++)
                {
                    di = new DirectoryInfo(direct[i]);
                    File.AppendAllText(filename, $"\n{di.Name}");
                }

                for(int i = 0; i < direct.Length; i++)
                {
                    ReadCatalog(direct[i]);
                }
                
            }
            else
            {
                Console.WriteLine("Указанный каталог не найден.");
            }
        }

    }
}
