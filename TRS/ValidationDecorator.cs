using System;
using System.Collections.Generic;
using System.Text;

namespace TRS
{
    public class ValidationDecorator : BankDecorator
    {
        public ValidationDecorator(IBank bank) : base(bank)
        {
        }

        public override void Deposit(double amount)
        {
            // Minimum deposit is 1000.
            if (amount < 1000)
            {
                throw new ArgumentException("Minimum deposit is 1000");
            }

            // Maximum deposit is 50000.
            if (amount > 50000)
            {
                throw new ArgumentException("Maximum deposit is 50000");
            }
            base.Deposit(amount);
        }

        public override double GetBalance()
        {
            double currentBalance = base.GetBalance();
            return currentBalance;
        }

        public override void Withdraw(double amount)
        {
            // Minimum withdrawal is 300.
            if (amount < 300)
            {
                throw new ArgumentException("Minimum withdrawal is 300");
            }

            // Maximum withdrawal amount is 10000
            if (amount > 10000)
            {
                throw new ArgumentException("Maximum withdrawal amount is 10000");
            }

            // Withdrawal amount should not be more than the current Balance
            double currentBalance = GetBalance();
            if (amount > currentBalance)
            {
                throw new ArgumentException("Withdrawal amount should not be more than the current Balance");
            }
            base.Withdraw(amount);
        }
    }
}
