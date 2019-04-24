namespace PlayersAndMonsters.Core
{
    using PlayersAndMonsters.Core.Contracts;
    using PlayersAndMonsters.IO;
    using PlayersAndMonsters.IO.Contracts;
    using System.Reflection;
    using System.Linq;
    using System;

    public class Engine : IEngine
    {
        private IManagerController managerController;
        private IReader reader;
        private IWriter writer;

        public Engine()
        {
            this.managerController = new ManagerController();
            this.reader = new ReaderController();
            this.writer = new WriterController();
        }

        public void Run()
        {
            string input;

            while ((input = this.reader.ReadLine()) != "Exit")
            {
                string[] tokens = input
                    .Split(' ')
                    .ToArray();

                string command = tokens[0];
                string output = string.Empty;
                try
                {
                    switch (command)
                    {
                        case "Report":
                            output = this.managerController.Report();
                            break;
                        case "Exit":
                            Environment.Exit(0);
                            break;
                        default:
                            var type = typeof(ManagerController);

                            output = (string)type
                               .GetMethod(command, BindingFlags.Public | BindingFlags.Instance)
                               .Invoke(this.managerController, new object[] { tokens[1], tokens[2] });
                            break;
                    }                 
                }
                catch (Exception e)
                {

                    output = e.InnerException.Message;
                }
                this.writer.WriteLine(output);
            }
        }
    }
}
