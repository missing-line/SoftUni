namespace BillsPaymentSystem.App.Core
{
    using BillsPaymentSystem.App.Core.Contracts;
    using BillsPaymentSystem.Data;
    using System;
    using System.Linq;
    using System.Reflection;

    public class CommandInterpreter : ICommandInterpreter
    {
        private const string commandSuffix = "Command";
        public string Read(string[] args, BillsPlaymentSystemContext context)
        {
            string command = args[0];
            string[] clearArgs = args.Skip(1).ToArray();

            var typeClass = Assembly
                .GetCallingAssembly()
                .GetTypes()
                .FirstOrDefault(x => x.Name == command + commandSuffix);

            if(typeClass == null)
            {
                throw new ArgumentException("Invalid Command! Please try with\n-> UserInfo\n-> PayBill");
            }

            var instance = (ICommand)Activator
                .CreateInstance(typeClass, new object[] { context });



            return instance.Execute(clearArgs);
        }
    }
}
