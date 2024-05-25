namespace Sparky
{
    public class Calculator
    {
        public List<int> NumberRange = new();
        public int AddNumbers(int a, int b)
        {
            return a + b;
        }

        public double AddNumbers(double a, double b)
        {
            return a + b;
        }

        public bool IsOdd(int value)
        {
            return value % 2 == 1;
        }

        public List<int> GetOddRange(int min, int max)
        {
            NumberRange.Clear();
            for (int i = min; i <= max; i++)
            {
                if (IsOdd(i))
                {
                    NumberRange.Add(i);
                }
            }
            return NumberRange;
        }
    }
}