using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace cs_homework7
{
    public enum TaskType
    {
        Management,
        SystemAdmins,
        Developers
    }
    public class JobTask
    {
        private string _title;
        private TaskType _type;

        public JobTask(string title, TaskType type)
        {
            _title = title;
            _type = type;
        }

        public string GetTitle() { return _title; }
        public TaskType GetTaskType() { return _type; }
    }

    public class Employee
    {
        private string _name;
        private TaskType _department;
        private List<Employee> _bosses = new List<Employee>();

        public Employee(string name, TaskType department)
        {
            _name = name;
            _department = department;
        }

        public string GetName() { return _name; }

        public void AddBoss(Employee boss)
        {
            _bosses.Add(boss);
        }

        public void GiveTask(Employee from, JobTask task)
        {
            bool isTaken = _bosses.Contains(from) && _department == task.GetTaskType();
            string result = isTaken ? "Берет задачу" : "Не берет задачу";

            Console.WriteLine($"От человека {from.GetName()} дается задача «{task.GetTitle()}» человеку {_name}. Результат: {result}");
        }
    }
    internal class Program
    {
        static void Main(string[] args)
        {
            Employee timur = new Employee("Тимур", TaskType.Management);

            Employee rashid = new Employee("Рашид", TaskType.Management);
            rashid.AddBoss(timur);

            Employee ilham = new Employee("О Ильхам", TaskType.Management);
            ilham.AddBoss(timur);

            Employee lukas = new Employee("Лукас", TaskType.Management);
            lukas.AddBoss(rashid);

            Employee orkadiy = new Employee("Оркадий", TaskType.Management);
            orkadiy.AddBoss(ilham);

            Employee volodya = new Employee("Володя", TaskType.Management);
            volodya.AddBoss(ilham);
            volodya.AddBoss(orkadiy);

            Employee ilshat = new Employee("Ильшат", TaskType.SystemAdmins);
            ilshat.AddBoss(orkadiy);
            ilshat.AddBoss(volodya);

            Employee ivanych = new Employee("Иваныч", TaskType.SystemAdmins);
            ivanych.AddBoss(ilshat);

            Employee ilya = new Employee("Илья", TaskType.SystemAdmins);
            ilya.AddBoss(ivanych);

            Employee vitya = new Employee("Витя", TaskType.SystemAdmins);
            vitya.AddBoss(ivanych);

            Employee zhenya = new Employee("Женя", TaskType.SystemAdmins);
            zhenya.AddBoss(ivanych);

            Employee sergey = new Employee("Сергей", TaskType.Developers);
            sergey.AddBoss(orkadiy);
            sergey.AddBoss(volodya);

            Employee lyaisan = new Employee("Ляйсан", TaskType.Developers);
            lyaisan.AddBoss(sergey);

            Employee marat = new Employee("Марат", TaskType.Developers);
            marat.AddBoss(lyaisan);

            Employee dina = new Employee("Дина", TaskType.Developers);
            dina.AddBoss(lyaisan);

            Employee ildar = new Employee("Ильдар", TaskType.Developers);
            ildar.AddBoss(lyaisan);

            Employee anton = new Employee("Антон", TaskType.Developers);
            anton.AddBoss(lyaisan);

            JobTask task1 = new JobTask("Организовать автоматизацию бухгалтерии", TaskType.Management);
            JobTask task2 = new JobTask("Настроить сеть и сервера", TaskType.SystemAdmins);
            JobTask task3 = new JobTask("Написать программу для бухгалтерии", TaskType.Developers);

            orkadiy.GiveTask(ilham, task1);
            marat.GiveTask(lukas, task3);
            sergey.GiveTask(orkadiy, task3);
            sergey.GiveTask(volodya, task3);
            lyaisan.GiveTask(sergey, task3);
            dina.GiveTask(sergey, task3);
            dina.GiveTask(lyaisan, task3);
            ilshat.GiveTask(orkadiy, task2);
            ivanych.GiveTask(ilshat, task2);
            ilya.GiveTask(ivanych, task2);
            vitya.GiveTask(ilshat, task2);
            zhenya.GiveTask(ivanych, task3);
        }
    }
}
