using NUnit.Framework;
using NUnit.Framework.Legacy;

namespace Sparky.NUnitTest
{
    [TestFixture]
    public class CalculatorNUnitTest
    {
        [Test]
        public void AddNumbers_ShouldReturnSum()
        {
            // Arrange
            var calculator = new Calculator();

            // Act
            int sum = calculator.AddNumbers(1, 2);

            // Assert
            ClassicAssert.AreEqual(3, sum);
        }

        [Test]
        public void IsOdd_ShouldReturnTrueForOddValues()
        {
            // Arrange
            var calculator = new Calculator();

            // Act
            bool isOdd1 = calculator.IsOdd(1);
            bool isOdd2 = calculator.IsOdd(3);
            bool isOdd3 = calculator.IsOdd(5);
            bool isOdd4 = calculator.IsOdd(9);

            // Assert
            ClassicAssert.IsTrue(isOdd1);
            ClassicAssert.IsTrue(isOdd2);
            ClassicAssert.IsTrue(isOdd3);
            ClassicAssert.IsTrue(isOdd4);
        }

        [Test]
        public void IsOdd_ShouldReturnFalseForEvenValues()
        {
            // Arrange
            var calculator = new Calculator();

            // Act
            bool isOdd1 = calculator.IsOdd(2);
            bool isOdd2 = calculator.IsOdd(4);
            bool isOdd3 = calculator.IsOdd(6);
            bool isOdd4 = calculator.IsOdd(8);

            // Assert
            ClassicAssert.IsFalse(isOdd1);
            ClassicAssert.IsFalse(isOdd2);
            ClassicAssert.IsFalse(isOdd3);
            Assert.That(isOdd4, Is.EqualTo(false));
        }

        [Test]
        [TestCase(1)]
        [TestCase(3)]
        [TestCase(5)]
        [TestCase(901)]
        [TestCase(1001)]
        public void IsOdd_ShouldReturnTrueForGivenInputs(int a)
        {
            // Arrange
            var calculator = new Calculator();

            // Act
            bool isOdd = calculator.IsOdd(a);

            // Assert
            ClassicAssert.IsTrue(isOdd);
        }

        [Test]
        [TestCase(2, ExpectedResult = false)]
        [TestCase(41, ExpectedResult = true)]
        public bool IsOddChecker_ShouldReturnExpectedResult(int a)
        {
            // Arrange
            var calculator = new Calculator();

            // Act
            return calculator.IsOdd(a);
        }

        [Test]
        [TestCase(2.0, 10.5)]
        [TestCase(3.1, 9.5)]
        public void AddNumbers_ShouldReturnSumForDoubleValues(double a, double b)
        {
            // Arrange
            var calculator = new Calculator();

            // Act
            double sum = calculator.AddNumbers(a,b);

            // Assert
            ClassicAssert.AreEqual(12.7, sum, 1);
        }

        [Test]
        [TestCase(1, 10)]
        public void OddRange_ShouldReturnOddNumbersInRange(int min, int max)
        {
            // Arrange
            var calculator = new Calculator();
            List<int> expectedOddRange = new() { 1, 3, 5, 7, 9 };
            // Act
            var oddNumbers = calculator.GetOddRange(min, max);

            //Assert
            Assert.That(oddNumbers, Is.Not.Null);
            Assert.That(oddNumbers, Has.Count.EqualTo(5));
            Assert.That(oddNumbers, Is.EquivalentTo(expectedOddRange));
            ClassicAssert.AreEqual(expectedOddRange, oddNumbers);
            ClassicAssert.Contains(3, oddNumbers);
            Assert.That(oddNumbers, Does.Contain(5));
            Assert.That(oddNumbers, Is.Not.Empty);
            Assert.That(oddNumbers.Count, Is.EqualTo(5));
            Assert.That(oddNumbers, Has.No.Member(6));
            Assert.That(oddNumbers, Is.Ordered);
            Assert.That(oddNumbers, Is.Unique);
        }
    }
}
