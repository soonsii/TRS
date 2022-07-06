using System;
using System.Collections.Generic;
using System.Text;

namespace TRS
{
    // base interface
    public interface IBank
    {
        void Withdraw(double amount);
        void Deposit(double amount);
        double GetBalance();
    }
}
