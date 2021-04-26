using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace lesson8library
{
    public class helloClass
    {
        string Name { get; }
        string HelloType { get; }
        public helloClass()
        {
            Name = "Пользователь";
            HelloType = "Здравствуйте,";
        }

        public helloClass(string name, string hello)
        {
            Name = name;
            HelloType = hello;
        }

        public void PrintHello()
        {
            Console.WriteLine($"{HelloType} {Name}");
        }

    }
}
