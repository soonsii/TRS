using System;
using Xunit;
using TRS;

namespace TRSUnitTest
{
    public class BankTest
    {
        private IBank _bankUnitTest = null;

        public BankTest()
        {
            if (_bankUnitTest == null)
            {
                IBank bank = new Bank();
                _bankUnitTest = new ValidationDecorator(bank);
            }
        }


        [Theory(DisplayName = "Normal deposit with balance checking")]
        [InlineData(1000, 6000)]
        [InlineData(5000, 10000)]
        public void Deposit(double amountToDeposit, double expectedBalance)
        {
            //arrange

            //act
            _bankUnitTest.Deposit(amountToDeposit);
            double actualBalance = _bankUnitTest.GetBalance();

            //assert
            Assert.Equal(expectedBalance, actualBalance);
        }



        [Theory(DisplayName = "Deposit with exceptions")]
        [InlineData(100000, typeof(ArgumentException), "Maximum deposit is 50000")]
        [InlineData(200, typeof(ArgumentException), "Minimum deposit is 1000")]
        public void Deposit_WithException(double amountToDeposit, Type exceptionType, string message)
        {
            try
            {
                _bankUnitTest.Deposit(amountToDeposit);
                double actualBalance = _bankUnitTest.GetBalance();
            }
            catch (Exception e)
            {
                Assert.True(e.GetType() == exceptionType);
                Assert.Equal(e.Message, message);
            }
        }


        [Theory(DisplayName = "Normal withdrawal with balance checking")]
        [InlineData(1000, 4000)]
        [InlineData(5000, 0)]
        public void Withdraw(double amountToWithdraw, double expectedBalance)
        {
            //arrange

            //act
            _bankUnitTest.Withdraw(amountToWithdraw);
            double actualBalance = _bankUnitTest.GetBalance();

            //assert
            Assert.Equal(expectedBalance, actualBalance);
        }


        [Theory(DisplayName = "Withdraw with exceptions")]
        [InlineData(28000, typeof(ArgumentException), "Maximum withdrawal amount is 10000")]
        [InlineData(200, typeof(ArgumentException), "Minimum withdrawal is 300")]
        [InlineData(5030, typeof(ArgumentException), "Withdrawal amount should not be more than the current Balance")]
        public void Withdraw_WithException(double amountToWithdraw, Type exceptionType, string message)
        {
            try
            {
                _bankUnitTest.Withdraw(amountToWithdraw);
                double actualBalance = _bankUnitTest.GetBalance();
            }
            catch (Exception e)
            {
                Assert.True(e.GetType() == exceptionType);
                Assert.Equal(e.Message, message);
            }
        }
    }
}
