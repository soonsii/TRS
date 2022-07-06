using System;
using System.Collections.Generic;
using System.Text;

namespace TRS
{

    // concrete implementation - default
    public class Bank : IBank
    {
        private static readonly double _initialBalance = 5000.00;
        private double? _Balance { get; set; }
        double Balance
        {
            get
            {
                if (_Balance == null)
                    _Balance = _initialBalance;

                return Convert.ToDouble(_Balance);
            }
            set
            {
                _Balance = value;
            }
        }
        public void Withdraw(double amount)
        {
            // logic to withdraw
            Balance = Balance - amount;
        }
        public void Deposit(double amount)
        {
            // logic to deposit
            Balance = Balance + amount;
        }
        public double GetBalance()
        {
            // get the Balance
            return Balance;
        }
    }
}
