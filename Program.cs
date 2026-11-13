using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace cs_homework7
{
    internal class Program
    {
        public static void CheckFormattable(object obj)
        {
            bool isFormattable = obj is IFormattable;
            IFormattable asFormattable = obj as IFormattable;

            Console.WriteLine($"Объект: {obj} ({obj.GetType().Name})");
            Console.WriteLine($"Проверка через is: {isFormattable}");
            Console.WriteLine($"Проверка через as: {asFormattable != null}");
            Console.WriteLine();
        }
        static void Main(string[] args)
        {
            int number = 100;
            double fraction = 25.5;
            string text = "Hello";
            object obj = new object();

            CheckFormattable(number);
            CheckFormattable(fraction);
            CheckFormattable(text);
            CheckFormattable(obj);
        }
    }
}
