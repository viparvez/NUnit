namespace Sparky
{
    public class Customer
    {
        public int Discount { get; set; } = 35;
        public int OrderTotal { get; set; }
        public string GreetMessage { get; set; }
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
