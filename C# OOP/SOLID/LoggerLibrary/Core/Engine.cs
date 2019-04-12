namespace LoggerLibrary.Core
{
    using LoggerLibrary.Core.Interface;
    using System;
    using System.Linq;

    public class Engine : IEngine
    {
        private ICommandInterpreter commandInterpreter;

        public Engine(ICommandInterpreter commandInterpreter)
        {
            this.commandInterpreter = commandInterpreter;
        }

        public void Run()
        {

            int n = int.Parse(Console.ReadLine());

            for (int i = 0; i < n; i++)
            {
                string[] input = Console.ReadLine()
                    .Split()
                    .ToArray();
                this.commandInterpreter.AddAppender(input);
            }

            string arr;

            while ((arr = Console.ReadLine()) != "END")
            {
                string[] tokens = arr
                    .Split('|')
                    .ToArray();

                this.commandInterpreter.AddMessages(tokens);

            }
            this.commandInterpreter.PrintInfo();
        }
    }
}
