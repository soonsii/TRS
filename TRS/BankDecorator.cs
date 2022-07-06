using System;
using System.Collections.Generic;
using System.Text;

namespace TRS
{
    // base decorator
    public class BankDecorator : IBank
    {
        private readonly IBank _bank;

        public BankDecorator(IBank bank)
        {
            _bank = bank;
        }

        public virtual void Deposit(double amount)
        {
            _bank.Deposit(amount);
        }

        public virtual double GetBalance()
        {
            return _bank.GetBalance();
        }

        public virtual void Withdraw(double amount)
        {
            _bank.Withdraw(amount);
        }
    }
}
