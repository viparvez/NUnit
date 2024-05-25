using Microsoft.VisualStudio.TestTools.UnitTesting;


namespace Sparky.MSTest
{
    [TestClass]
    public class TestAddNumbers
    {
        [TestMethod]
        public void AddNumbers()
        {
            //Arrange
            Calculator calculator = new Calculator();
            //Act
            int result = calculator.AddNumbers(1, 2);
            //Assert
            Assert.AreEqual(3, result);
        }
    }
}
