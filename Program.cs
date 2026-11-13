using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace cs_homework7
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.Write("Введите имя файла: ");
            string inputFileName = Console.ReadLine();

            if (!File.Exists(inputFileName))
            {
                Console.WriteLine("Такого файла не существует.");
                return;
            }

            string content = File.ReadAllText(inputFileName);
            string upperContent = content.ToUpper();

            string outputFileName = "output.txt";
            File.WriteAllText(outputFileName, upperContent);

            Console.WriteLine($"Содержимое записано в файл {outputFileName}.");
        }
    }
}
