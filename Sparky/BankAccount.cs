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
            _logBook.Message("Test");
            _logBook.LogSeverity = 101;
            Balance += amount;
            return true;
        }

        public bool Withdraw(int amount)
        {
            if (Balance >= amount)
            {
                _logBook.LogToDb("Withdrawal invoked");
                Balance -= amount;
                _logBook.LogBalanceAfterWithdrawal(Balance);
                return true;
            }
            return false;
        }

        public int GetBalance() { return Balance; }
    }
}
