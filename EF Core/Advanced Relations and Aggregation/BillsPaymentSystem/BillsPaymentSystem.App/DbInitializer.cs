namespace BillsPaymentSystem.App
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using BillsPaymentSystem.Data;
    using BillsPaymentSystem.Models;
    using BillsPaymentSystem.Models.Enum;

    public class DbInitializer
    {
        private static List<User> users = new List<User>();
        private static List<CreditCard> creditCards = new List<CreditCard>();
        private static List<BankAccount> bankAccounts = new List<BankAccount>();
        private static List<PaymentMethod> paymentMethods = new List<PaymentMethod>();
        public static void Seed(BillsPlaymentSystemContext systemContext)
        {
            SeedUser(systemContext);
            SeedCreditCard(systemContext);
            SeedBankAccount(systemContext);
            SeedPaymentMethod(systemContext);
        }

        private static void SeedPaymentMethod(BillsPlaymentSystemContext systemContext)
        {
            for (int i = 0; i < 5; i++)
            {
                var payMethod = new PaymentMethod
                {
                    UserId = new Random().Next(1, 8),                   
                };

                if (i % 2 == 0)
                {
                    payMethod.Type = PaymentType.BankAccount;
                    payMethod.BankAccountId = new Random().Next(1, 5);
                }
                else
                {
                    payMethod.Type = PaymentType.CreditCard;
                    payMethod.CreditCardId = new Random().Next(1, 8);
                }

                paymentMethods.Add(payMethod);
            }

            systemContext.PaymentMethods.AddRange(paymentMethods);
            systemContext.SaveChanges();
        }

        private static void SeedBankAccount(BillsPlaymentSystemContext systemContext)
        {
            string[] bankNames = { "ABC", "EFCore", "ArrayDotLame", "Csharp", "DbCourse" };

            for (int i = 0; i < 5; i++)
            {
                var bankAcc = new BankAccount
                {
                    BankName = bankNames[i],
                    Balance = new Random().Next(-200, 10000),
                    SWIFT = "Swift" + bankNames[i],
                };

                if (!IsValid(bankAcc))
                    continue;

                bankAccounts.Add(bankAcc);
            }

            systemContext.BankAccounts.AddRange(bankAccounts);
            systemContext.SaveChanges();
        }

        private static void SeedCreditCard(BillsPlaymentSystemContext systemContext)
        {
            for (int i = 0; i < 8; i++)
            {
                var creditCard = new CreditCard
                {
                    Limit = new Random().Next(0, 250000),
                    MoneyOwed = new Random().Next(0, 250000),
                    ExpirationDate = DateTime.Now.AddDays(new Random().Next(0, 200)),
                };

                if (!IsValid(creditCard))
                    continue;


                creditCards.Add(creditCard);
            }
            systemContext.CreditCards.AddRange(creditCards);
            systemContext.SaveChanges();
        }

        private static void SeedUser(BillsPlaymentSystemContext systemContext)
        {
            string[] firstName = { "Opa", "EntityFramework", null, "ERROR" };
            string[] lastName = { "Oppa", "Core", null, "ERROR" };
            string[] email = { "email@email.com", "entityframe@mail.com", null, "ERROR" };
            string[] password = { "123456", "hardPassWord", "secretKey", null };

            for (int i = 0; i < firstName.Length; i++)
            {
                var user = new User
                {
                    FirstName = firstName[i],
                    LastName = lastName[i],
                    Email = email[i],
                    Password = password[i],
                };

                if (!IsValid(user))
                    continue;

                users.Add(user);
            }

            systemContext.Users.AddRange(users);
            systemContext.SaveChanges();
        }

        private static bool IsValid(object entity)
        {
            var validationContext = new ValidationContext(entity);
            var validationResults = new List<ValidationResult>();

            bool isValid = Validator
                .TryValidateObject(entity, validationContext, validationResults, true);

            return isValid;
        }
    }
}
