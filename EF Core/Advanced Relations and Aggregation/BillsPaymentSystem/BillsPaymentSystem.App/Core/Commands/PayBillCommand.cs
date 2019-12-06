namespace BillsPaymentSystem.App.Core.Commands
{
    using BillsPaymentSystem.App.Core.Contracts;
    using BillsPaymentSystem.Data;
    using BillsPaymentSystem.Models.Enum;
    using Microsoft.EntityFrameworkCore;
    using System;
    using System.Linq;

    public class PayBillCommand : ICommand
    {
        private readonly BillsPlaymentSystemContext context;

        public PayBillCommand(BillsPlaymentSystemContext context)
        {
            this.context = context;
        }

        public object PaymentMethodType { get; private set; }

        public string Execute(string[] args)
        {
            //PayBills(int userId, decimal amount) 

            int id = int.Parse(args[0]);
            decimal amount = decimal.Parse(args[1]);

            var user = this.context
                .Users
                .FirstOrDefault(x => x.UserId == id);

            if (user == null)
            {
                throw new ArgumentNullException($"User with id {id} not found!");
            }


            var accounts = context.PaymentMethods
                        .Include(pm => pm.BankAccount)
                        .Where(pm => pm.UserId == id && pm.Type == PaymentType.BankAccount)
                        .Select(pm => pm.BankAccount)
                        .ToList();

            var cards = context.PaymentMethods
                .Include(pm => pm.CreditCard)
                .Where(pm => pm.UserId == id && pm.Type == PaymentType.CreditCard)
                .Select(pm => pm.CreditCard)
                .ToList();


            decimal moneyAvailable = accounts.Select(ba => ba.Balance).Sum() + cards.Select(cc => cc.LimitLeft).Sum();

            if (moneyAvailable < amount)
            {
                throw new ArgumentException("Insufficient funds!");
            }

            try
            {
                foreach (var account in accounts)
                {
                    if (amount == 0 || account.Balance == 0)
                    {
                        continue;
                    }

                    decimal moneyInAccount = account.Balance;
                    if (moneyInAccount < amount)
                    {
                        account.Withdraw(moneyInAccount);
                        amount -= moneyInAccount;
                    }
                    else
                    {
                        account.Withdraw(amount);
                        amount -= amount;
                    }
                }


                foreach (var creditCard in cards)
                {
                    if (amount == 0 || creditCard.LimitLeft == 0)
                    {
                        continue;
                    }

                    decimal limitLeft = creditCard.LimitLeft;
                    if (limitLeft < amount)
                    {
                        creditCard.Withdraw(limitLeft);
                        amount -= limitLeft;
                    }
                    else
                    {
                        creditCard.Withdraw(amount);
                        amount -= amount;
                    }
                }

                context.SaveChanges();
            }
            catch (Exception e)
            {
                throw new InvalidOperationException(e.InnerException.Message);      
            }
           

            if (amount > 0)
            {
                return "Bill isn't paid";
            }

            return "Succssefully Withdraw Operation!";
        }
    }
}
