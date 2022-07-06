using System;

namespace TRS
{
    class Program
    {
        static void Main(string[] args)
        {

            IBank bank = new Bank();
            IBank validationDecorator = new ValidationDecorator(bank);
            IBank loggingDecorator = new LoggingDecorator(validationDecorator);

            do
            {
                Console.WriteLine("Enter action followed by amount. e.g. \"withdraw 2000\"");
                string userInput = Console.ReadLine();

                // parse the input
                string[] inputArr = userInput.Trim().Split(' ');
                string action = inputArr[0].ToLower();
                double amount = 0;
                try
                {
                    if (action != "getbalance" && !double.TryParse(inputArr[1], out amount))
                        continue;
                }
                catch 
                {

                    
                }
                    
                
                switch (action)
                {
                    case "withdraw":
                        loggingDecorator.Withdraw(amount);
                        break;
                    case "deposit":
                        loggingDecorator.Deposit(amount);
                        break;
                    case "getbalance":
                        loggingDecorator.GetBalance();
                        break;
                    default:
                        break;
                }
            }
            while (true);
            Console.ReadLine();
        }
    }
}
