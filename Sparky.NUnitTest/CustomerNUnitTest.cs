using NUnit.Framework;
using NUnit.Framework.Legacy;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sparky.NUnitTest
{
    [TestFixture]
    public class CustomerNUnitTest
    {
        private Customer customer;
        [SetUp]
        public void Setup()
        {
            customer = new Customer();
        }

        [Test]
        public void GreetAndCombineNames_ShouldReturnCombinedNames()
        {

            // Act
            string greeting = customer.GreetAndCombineNames("John", "Doe");

            // Assert
            Assert.That(greeting, Is.EqualTo("Hello, John Doe").IgnoreCase);
            ClassicAssert.AreEqual("Hello, John Doe", greeting);
            Assert.That(greeting, Does.Contain(","));
            Assert.That(greeting, Does.StartWith("Hello"));
            Assert.That(greeting, Does.EndWith("Doe"));
            Assert.That(greeting, Does.Match("Hello, [A-Z][a-z]+ [A-Z][a-z]+"));
        }

        [Test]
        public void GreetMessage_NotGreeted_ReturnsNull()
        {
            // Act
            //string greeting = customer.GreetAndCombineNames(null, null);

            // Assert
            ClassicAssert.IsNull(customer.GreetMessage);
        }

        [Test]
        public void Discount_ShouldReturnDefaultDiscount()
        {
            // Act
            customer.GreetAndCombineNames("John", "Doe");
            int discount = customer.Discount;

            // Assert
            //ClassicAssert.AreEqual(15, discount);
            Assert.That(discount, Is.InRange(10,25));
        }
    }
}
