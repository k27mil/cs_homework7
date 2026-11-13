using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace cs_homework7
{
    public enum AccountType
    {
        Current,
        Savings
    }
    public class BankAccount
    {
        private static int _nextId = 1;
        private int _id;
        private decimal _balance;
        private AccountType _type;
        private static int GenerateId() { return _nextId++; }
        public void SetData(decimal balance, AccountType type)
        {
            _id = GenerateId();
            _balance = balance;
            _type = type;
        }
        public int GetId() { return _id; }
        public decimal GetBalance() { return _balance; }
        public AccountType GetAccountType() { return _type; }
        public void Deposit(decimal amount)
        {
            if (amount > 0)
            {
                _balance += amount;
            }
        }
        public bool Withdraw(decimal amount)
        {
            if (amount > 0 && _balance >= amount)
            {
                _balance -= amount;
                return true;
            }
            return false;
        }
        public bool TransferFrom(BankAccount fromAccount, decimal amount)
        {
            if (fromAccount != null && fromAccount.Withdraw(amount))
            {
                Deposit(amount);
                return true;
            }
            return false;
        }

        public void Print() { Console.WriteLine($"Счет: {_id} Тип: {_type} Баланс: {_balance}"); }
    }
    internal class Program
    {
        static void Main(string[] args)
        {
            BankAccount account1 = new BankAccount();
            account1.SetData(10000m, AccountType.Current);

            BankAccount account2 = new BankAccount();
            account2.SetData(3000m, AccountType.Savings);

            account1.Print();
            account2.Print();
            Console.WriteLine();

            account2.TransferFrom(account1, 4000m);
            account1.Print();
            account2.Print();
            Console.WriteLine();

            account2.TransferFrom(account1, 50000m);
            account1.Print();
            account2.Print();
        }
    }
}
