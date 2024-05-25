namespace Sparky
{
    public class Customer
    {
        public int Discount { get; set; } = 35;
        public string GreetMessage { get; set; }
        public string GreetAndCombineNames(string firstName, string lastName)
        {
            GreetMessage = $"Hello, {firstName} {lastName}";
            Discount = 20;
            return GreetMessage;
        }
    }
}
