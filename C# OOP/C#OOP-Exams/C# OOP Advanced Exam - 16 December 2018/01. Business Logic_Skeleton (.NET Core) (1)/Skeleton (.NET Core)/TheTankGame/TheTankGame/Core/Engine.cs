namespace TheTankGame.Core
{
    using System;
    using System.Linq;
    using Contracts;
    using IO.Contracts;
    using TheTankGame.IO;

    public class Engine : IEngine
    {
        private bool isRunning;
        private readonly IReader reader;
        private readonly IWriter writer;
        private readonly ICommandInterpreter commandInterpreter;

        public Engine(IReader reader, IWriter writer, ICommandInterpreter commandInterpreter)
        {
            this.isRunning = false;
            this.reader = reader;
            this.writer = writer;
            this.commandInterpreter = commandInterpreter;
        }

        public void Run()
        {
            this.isRunning = true;

            while (true)
            {
                string[] input = reader.ReadLine()
                    .Split(' ')
                    .ToArray();

                string output = this.commandInterpreter.ProcessInput(input);

                this.writer.WriteLine(output);

                if (input[0] == "Terminate")
                {
                    this.isRunning = false;
                    break;
                }
            }
        }
    }
}