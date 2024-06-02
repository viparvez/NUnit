using Moq;
using NUnit.Framework;

namespace Sparky.NUnitTest
{
    [TestFixture]
    public class ProductNUnitTest
    {
        [Test]
        public void GetPrice_IsPlatinum_ReturnsDiscountedPrice()
        {
            var product = new Product { Price = 50 };
            var customer = new Customer { IsPlatinum = true };

            double price = product.GetPrice(customer);

            Assert.That(price, Is.EqualTo(40));
        }

        [Test]
        public void GetPriceMOQAbuse_IsPlatinum_ReturnsDiscountedPrice()
        {
            var customer = new Mock<ICustomer>();
            customer.Setup(x => x.IsPlatinum).Returns(true);
            var product = new Product { Price = 50 };

            var result = product.GetPrice(customer.Object);
            Assert.That(result, Is.EqualTo(40));
        }
    }
}
