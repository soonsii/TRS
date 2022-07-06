using System;
using System.Collections.Generic;
using System.Text;

namespace TRS
{
    public class LoggingDecorator : BankDecorator
    {
        public LoggingDecorator(IBank bank) : base(bank)
        {
        }

        public override void Deposit(double amount)
        {
            try
            {
                base.Deposit(amount);
                Console.WriteLine($"Deposit {amount}");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"ERROR: {ex.Message}");
            }
        }

        public override double GetBalance()
        {
            double currentBalance = base.GetBalance();
            Console.WriteLine($"Current balance {currentBalance}");
            return currentBalance;
        }

        public override void Withdraw(double amount)
        {
            try
            {
                base.Withdraw(amount);
                Console.WriteLine($"Withdraw {amount}");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"ERROR: {ex.Message}");
            }
        }
    }
}
