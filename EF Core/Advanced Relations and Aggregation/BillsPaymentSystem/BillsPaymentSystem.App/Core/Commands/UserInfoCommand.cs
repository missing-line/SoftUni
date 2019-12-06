namespace BillsPaymentSystem.App.Core.Commands
{
    using BillsPaymentSystem.App.Core.Contracts;
    using BillsPaymentSystem.Data;
    using BillsPaymentSystem.Models.Enum;
    using Microsoft.EntityFrameworkCore;
    using System;
    using System.Linq;
    using System.Text;

    public class UserInfoCommand : ICommand
    {
        private readonly BillsPlaymentSystemContext context;


        public UserInfoCommand(BillsPlaymentSystemContext context)
        {
            this.context = context;
        }
        public string Execute(string[] args)
        {
            var sb = new StringBuilder();

            int id = int.Parse(args[0]);

            var user = this.context
                .Users
                .FirstOrDefault(x => x.UserId == id);

            if (user == null)
            {
                throw new ArgumentNullException($"User with id {id} not found!"); 
            }            


            sb.AppendLine($"{user.FirstName} {user.LastName}");
            sb.AppendLine("Bank Accounts:");

            this.context.PaymentMethods
               .Include(x => x.BankAccount)
               .Where(x => x.UserId == id && x.Type == PaymentType.BankAccount)
               .Select(x => x.BankAccount)
               .ToList()
               .ForEach(x => sb.AppendLine(
                $"--ID: {x.BankAccountId}" + Environment.NewLine +
                $"--- Balance: {x.Balance:f2}" + Environment.NewLine +
                $"--- Bank: {x.BankName}" + Environment.NewLine +
                $"--- SWIFT: {x.SWIFT}" + Environment.NewLine));


            sb.AppendLine("Credit Card:");

            this.context.PaymentMethods
               .Include(x => x.CreditCard)
               .Where(x => x.UserId == id && x.Type == PaymentType.CreditCard)
               .Select(x => x.CreditCard)
               .ToList()
            .ForEach(x => sb.AppendLine($"--ID: {x.CreditCardId}" + Environment.NewLine +
                                        $"--- Limit: {x.Limit:f2}" + Environment.NewLine +
                                        $"--- Money Owed: {x.MoneyOwed:f2}" + Environment.NewLine +
                                        $"--- Limit Left:: {x.LimitLeft:f2}" + Environment.NewLine +
                                        $"--- Expiration Date: {x.ExpirationDate}"));


            return sb.ToString().TrimEnd();
        }
    }
}
