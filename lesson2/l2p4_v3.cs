using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace l2p
{
    class l2p4_v3
    {
        public static void Fiscal()
        {
            string[,] a = new string[,] { { "матрас", "1209", "2" }, { "подгузники", "900", "1" } };
            string[] b = new string[] { "Кассовый чек №3889", $"{DateTime.Now}", "Интернет решения ООО" };


            Print_all(b, a);
        }
        public static void Print_all(string[] info_company, string[,] product_list)
        {
            int fiscal_width = 20;
            line(fiscal_width, 1);
            Print_info(info_company, fiscal_width);
            line(fiscal_width, 2);
            line(fiscal_width, 3);
            line(fiscal_width, 2);
            Print_product(product_list, fiscal_width);
            line(fiscal_width, 1);
        }

        public static void Print_info(string[] info, int fiscal_widgth)
        {
            foreach (string text in info)
            {
                Print_text(text, fiscal_widgth);
            }
        }
        public static void Print_product(string[,] product, int fiscal_width)
        {
            int rows = product.GetUpperBound(0) + 1;
            int summ_fiscal = 0;
            for(int i = 0; i< rows; i++)
            {
                int summ = int.Parse(product[i, 1]) * int.Parse(product[i, 2]);
                summ_fiscal += summ;
                Print_text(product[i, 0], summ.ToString(), fiscal_width);
                Print_text($"{product[i, 1]} x {product[i, 2]}", "", fiscal_width);
                line(fiscal_width, 3);
            }
            string total = "ИТОГ";
            Print_text(total, summ_fiscal.ToString(), fiscal_width);
            string without_nds = "Без НДС";
            Print_text(without_nds, summ_fiscal.ToString(), fiscal_width);
            string full_calc = "Полный расчет";
            Print_text(full_calc, summ_fiscal.ToString(), fiscal_width);



        }

        /// <summary>
        /// 1 - сплошная *
        /// 2 - пустая с границами *
        /// 3 - сплошная - с границами *
        /// </summary>
        /// <param name="widgth_fiscal"></param>
        /// <param name="type_line"></param>
        public static void line(int widgth_fiscal, int type_line)
        {
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
                case 1:
                    Console.WriteLine(top_line);
                    break;
                case 2:
                    Console.WriteLine(empty_line);
                    break;
                case 3:
                    Console.WriteLine(line_line);
                    break;
            }



        }

        public static void Print_text(string left_part, string right_part, int fiscal_widgth)
        {
            string line_print = "";
            string alt_line = "";
            while (true)
            {
                line_print = "*  " + left_part + right_part + "  *";

                //разбиение текста на несколько строк если текст слишком длинный
                if(line_print.Length > fiscal_widgth)
                {
                    alt_line = left_part.Substring(fiscal_widgth - 7 - right_part.Length);
                    left_part = left_part.Substring(0, fiscal_widgth - 7 - right_part.Length);
                    continue;


                }
                //удлинение текста если текст короткий
                if (line_print.Length < fiscal_widgth) 
                { 
                    left_part += " ";
                    continue;
                }
                break;
            }
            Console.WriteLine(line_print);
            if (alt_line != "") 
            {
                Print_text(alt_line, "", fiscal_widgth);
            }
        }
        public static void Print_text(string middle_part, int fiscal_widgth)
        {
            string line_print = "";
            string alt_line = "";


            if (middle_part.Length % 2 != fiscal_widgth % 2)
            {
                middle_part = " " + middle_part;
            }
            while (true)
            {
                line_print = "*  " + middle_part + "  *";

                if (line_print.Length > fiscal_widgth)
                {
                    alt_line = middle_part.Substring(fiscal_widgth - 6);
                    middle_part = middle_part.Substring(0, fiscal_widgth - 6);
                    continue;
                }


                if (line_print.Length < fiscal_widgth)
                {
                    middle_part = " " + middle_part + " ";
                    continue;
                }
                break;
            }
            Console.WriteLine(line_print);
            if(alt_line != "")
            {
                Print_text(alt_line, fiscal_widgth);
            }
        }



    }
}
