﻿namespace Sparky
{
    public interface ICustomer
    {
        int Discount { get; set; }
        int OrderTotal { get; set; }
        string GreetMessage { get; set; }
        bool IsPlatinum { get; set; }
        string GreetAndCombineNames(string firstName, string lastName);
        CustomerType GetCustomerType();
    }
    public class Customer : ICustomer
    {
        public int Discount { get; set; }
        public int OrderTotal { get; set; }
        public string GreetMessage { get; set; }
        public bool IsPlatinum { get; set; }

        public Customer()
        {
            Discount = 15;
            IsPlatinum = false;   
        }

        public string GreetAndCombineNames(string firstName, string lastName)
        {
            if (string.IsNullOrWhiteSpace(firstName))
            {
                throw new ArgumentException("First name is null or empty");
            }

            GreetMessage = $"Hello, {firstName} {lastName}";
            Discount = 20;
            return GreetMessage;
        }

        public CustomerType GetCustomerType()
        {
            if(OrderTotal < 100)
            {
                return new BasicCustomer();
            }
            return new PremiumCustomer();
        }
    }

    public class CustomerType { }
    public class BasicCustomer : CustomerType { }
    public class PremiumCustomer : CustomerType { }
}
