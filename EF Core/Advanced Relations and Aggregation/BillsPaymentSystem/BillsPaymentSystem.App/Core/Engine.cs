namespace BillsPaymentSystem.App.Core
{
    using BillsPaymentSystem.App.Core.Contracts;
    using BillsPaymentSystem.Data;
    using System;

    public class Engine : IEngine
    {
        private readonly ICommandInterpreter commandInterpreter;

        public Engine()
        {
            this.commandInterpreter = new CommandInterpreter();
        }
        public void Run()
        {
            while (true)
            {
                string[] input = Console.ReadLine()
               .Split();

                if (input[0] == "End")
                {
                    Environment.Exit(0);
                }

                try
                {
                    using (var contex = new BillsPlaymentSystemContext())
                    {
                        string output = this.commandInterpreter.Read(input, contex);
                        Console.WriteLine(output);
                    }
                }
                catch (Exception e)
                {

                    Console.WriteLine(e.Message);
                }
                                            
            }
        }
    }
}
