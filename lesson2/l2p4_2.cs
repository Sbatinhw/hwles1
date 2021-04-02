using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace l2p
{
    class l2p4_2
    {
        public static void Fiscal()
        {
            string[,] a = new string[,] { { "матраааааааааааааааааааааас", "1209", "2" } };
            string[] b = new string[] { "info_1", "info_11" };

            Print_all(a, b);
        }
        public static void Print_all(string[,] product_list, string[] info_company)
        {
            int widgth_fiscal = 20;


            line(widgth_fiscal, 1);
            Print_info(info_company, widgth_fiscal);
            Print_product(product_list, widgth_fiscal);
            
        }

        public static void line(int widgth_fiscal, int type_line)
        {
            //int widgth_fiscal = 20;
            string top_line = "";
            string empty_line = "";
            string line_line = "";
            for (int i = 0; i < widgth_fiscal; i++)
            {
                top_line += "*";

                if (i == 0 || i == widgth_fiscal - 1)
                {
                    empty_line += "*";
                    line_line += "*";
                }
                else
                {
                    empty_line += " ";
                    line_line += "-";
                }

            }

            switch (type_line)
            {
                case 1: Console.WriteLine(top_line);
                    break;
                case 2: Console.WriteLine(empty_line);
                    break;
                case 3: Console.WriteLine(line_line);
                    break;
            }
                


        }

        public static void Print_info(string[] info, int line_length)
        {

            for(int i = 0; i < info.Length; i++)
            {
                string sd = info[i];
                string start_line = "*  ";
                string end_line = "  *";
                string line_1 = "";
                bool flag = true;
                while (flag)
                {
                    
                    line_1 = start_line + sd + end_line;
                    if (line_length % 2 != sd.Length % 2)
                    {
                        sd = " " + sd;
                    }
                    if(line_1.Length < line_length)
                    {
                        sd = " " + sd + " ";
                        continue;
                    }
                    Console.WriteLine(line_1);
                    break;
                }


            }
        }



        public static void Print_product(string[,] product_array, int line_length)
        {
            string start_line = "*  ";
            string end_line = "  *";
            bool flag = true;
            string line_1 = "";
            string line_2 = "";
            int i = 0;
            int summ = int.Parse(product_array[i, 1]) * int.Parse(product_array[i, 2]);
            string product = product_array[i, 0];

            while (flag)
            {
                string test_string1 = start_line + product + summ + "р." + end_line;
                //Console.WriteLine(test_string1);
                if(test_string1.Length < line_length)
                {
                    product += " ";
                    continue;
                }
                if (test_string1.Length > line_length)
                {
                    product = product.Substring(0, product.Length - 2) + " ";
                    continue;
                }
                line_1 = test_string1;
                break;
            }
            string sd = product_array[i, 2];
            while (flag)
            {
                
                string test_string2 = start_line + product_array[i, 1] + "р." + " x " + sd + end_line;
                //Console.WriteLine(test_string2);
                if(test_string2.Length < line_length)
                {
                    sd += " ";
                    continue;
                }
                line_2 = test_string2;
                break;
            }

            Console.WriteLine(line_1 + "\n" + line_2);

        }
        



    }
}
