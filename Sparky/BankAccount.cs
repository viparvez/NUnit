using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sparky
{
    public class BankAccount
    {
        public int Balance { get; set; }
        private readonly ILogBook _logBook;
        public BankAccount(ILogBook logBook)
        {
            Balance = 0;
            _logBook = logBook;
        }

        public bool Deposit(int amount)
        {
            _logBook.Message("Deposit invoked");
            Balance += amount;
            return true;
        }

        public bool Withdraw(int amount)
        {
            if (Balance >= amount)
                Balance -= amount;
            return true;
        }

        public int GetBalance() { return Balance; }
    }
}
