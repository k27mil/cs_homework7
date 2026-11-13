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
        public void SearchMail(ref string s)
        {
            string[] parts = s.Split('#');
            if (parts.Length > 1)
            {
                s = parts[1].Trim();
            }
            else
            {
                s = string.Empty;
            }
        }
        static void Main(string[] args)
        {
            string inputFile = "users.txt";
            string outputFile = "emails.txt";

            string[] initialLines =
            {
                "Иванов Иван Иванович # iviviv@mail.ru",
                "Петров Петр Петрович # petr@mail.ru"
            };

            File.WriteAllLines(inputFile, initialLines);

            string[] lines = File.ReadAllLines(inputFile);
            List<string> emails = new List<string>();
            Program program = new Program();

            for (int i = 0; i < lines.Length; i++)
            {
                string currentLine = lines[i];
                program.SearchMail(ref currentLine);

                if (currentLine != string.Empty)
                {
                    emails.Add(currentLine);
                }
            }

            File.WriteAllLines(outputFile, emails);

            Console.WriteLine($"Адреса успешно записаны в файл {outputFile}:");
            foreach (string email in emails)
            {
                Console.WriteLine(email);
            }
        }
    }
}
