using Moq;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sparky.NUnitTest
{
    [TestFixture]
    public class BankAccountNUnitTest
    {
        private BankAccount account;
        [SetUp]
        public void Setup()
        {
        }

        [Test]
        public void BankDeposit_Add100_ReturnsTrue()
        {
            BankAccount bankAccount = new(new LogBook());
            var result = bankAccount.Deposit(100);

            Assert.That(result, Is.True);
            Assert.That(bankAccount.GetBalance(), Is.EqualTo(100));
        }

        [Test]
        public void BankDepositMoq_Add100_ReturnsTrue()
        {
            var logMock = new Mock<ILogBook>();
            logMock.Setup(x => x.Message("Deposit invoked"));

            BankAccount bankAccount = new(logMock.Object);
            var result = bankAccount.Deposit(100);

            Assert.That(result, Is.True);
            Assert.That(bankAccount.GetBalance(), Is.EqualTo(100));
        }
    }
}
