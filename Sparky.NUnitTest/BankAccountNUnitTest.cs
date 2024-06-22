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

        [Test]
        [TestCase(500,100)]
        public void BankWithdraw_Withdraw100Witih200Balance_ReturnsTrue(int deposit, int withdraw)
        {
            var logMock = new Mock<ILogBook>();
            logMock.Setup(x => x.LogToDb(It.IsAny<string>())).Returns(true);
            logMock.Setup(x => x.LogBalanceAfterWithdrawal(It.Is<int>(x=>x>0))).Returns(true);

            BankAccount bankAccount = new(logMock.Object);
            bankAccount.Deposit(deposit);
            var result = bankAccount.Withdraw(withdraw);
            Assert.That(result, Is.True);
        }

        [TestCase]
        public void BankWithdraw_Withdraw100Witih50Balance_ReturnsFalse()
        {
            var logMock = new Mock<ILogBook>();
            logMock.Setup(x => x.LogBalanceAfterWithdrawal(It.Is<int>(x => x > 0))).Returns(true);
            //logMock.Setup(x => x.LogBalanceAfterWithdrawal(It.Is<int>(x => x < 0))).Returns(false);
            logMock.Setup(x => x.LogBalanceAfterWithdrawal(It.IsInRange<int>(int.MinValue, -1, Moq.Range.Inclusive))).Returns(false);

            BankAccount bankAccount = new(logMock.Object);
            bankAccount.Deposit(50);
            var result = bankAccount.Withdraw(100);
            Assert.That(result, Is.False);
        }

        [TestCase]
        public void BankLogDummy_LogMockString_ReturnTrue()
        {
            var logMock = new Mock<ILogBook>();
            string desiredOutput = "Hello";
            logMock.Setup(x => x.MessageWithReturnString(It.IsAny<string>())).Returns((string str) => str);

            Assert.That(logMock.Object.MessageWithReturnString("Hello"), Is.EqualTo(desiredOutput));
        }

        [TestCase]
        public void BankLogDummy_LogMockStringOutputStr_ReturnTrue()
        {
            var logMock = new Mock<ILogBook>();
            string desiredOutput = "Hello";
            logMock.Setup(x => x.LogWithOutputResult(It.IsAny<string>(), out desiredOutput)).Returns(true);
            string result = string.Empty;
            Assert.That(logMock.Object.LogWithOutputResult("Ben", out result), Is.True);
            Assert.That(result, Is.EqualTo(desiredOutput));
        }

        [Test]
        public void BankLogDummy_VerifyExample()
        {
            var logMock = new Mock<ILogBook>();
            BankAccount bankAccount = new(logMock.Object);
            bankAccount.Deposit(100);

            Assert.That(bankAccount.GetBalance(), Is.EqualTo(100));

            logMock.Verify(x => x.Message(It.IsAny<string>()), Times.Exactly(2));
            logMock.VerifySet(x => x.LogSeverity = 101, Times.Once);

        }
    }
}
