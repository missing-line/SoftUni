using CosmosX.Core.Contracts;
using CosmosX.IO.Contracts;
using System;
using System.Linq;

namespace CosmosX.Core
{
    public class Engine : IEngine
    {
        private IReader reader;
        private IWriter writer;
        private ICommandParser commandParser;
        private bool isRunning;

        public Engine(IReader reader, IWriter writer, ICommandParser commandParser)
        {
            this.reader = reader;
            this.writer = writer;
            this.commandParser = commandParser;
            this.isRunning = false;
        }

        public void Run()
        {
            isRunning = true;            

            while (isRunning)
            {
                string[] input = reader.ReadLine()
                    .Split(' ')
                    .ToArray();

                if (input[0] == "Exit")
                {
                    string result = this.commandParser.Parse(input);
                    writer.WriteLine(result);
                    isRunning = false;
                    break;
                }

                try
                {
                    string result = this.commandParser.Parse(input);
                    writer.WriteLine(result);
                }
                catch (Exception ex)
                {

                    Console.WriteLine(ex.InnerException.Message);
                }
            }
        }
    }
}