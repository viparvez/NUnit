using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sparky
{
    public interface ILogBook
    {
        int LogSeverity { get; set; }
        void Message(string message);
        bool LogToDb(string message);
        bool LogBalanceAfterWithdrawal(int balance);
        string MessageWithReturnString(string message);
        bool LogWithOutputResult(string str, out string outputSrt);
    }
    public class LogBook : ILogBook
    {
        public int LogSeverity { get; set; }

        public bool LogBalanceAfterWithdrawal(int balance)
        {
            if(balance >= 0)
            {
                Console.WriteLine($"Balance after withdrawal is {balance}");
                return true;
            }
            return false;
        }

        public bool LogToDb(string message)
        {
            Console.WriteLine(message);
            return true;
        }

        public bool LogWithOutputResult(string str, out string outputSrt)
        {
            outputSrt = "Hello "+str;
            return true;
        }

        public void Message(string message)
        {
            Console.WriteLine(message);
        }

        public string MessageWithReturnString(string message)
        {
            Console.WriteLine("Message");
            return message;
        }
    }
}
