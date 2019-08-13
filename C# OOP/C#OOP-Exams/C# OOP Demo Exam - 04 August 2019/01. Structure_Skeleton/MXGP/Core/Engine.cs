namespace MXGP.Core
{
    using MXGP.Core.Contracts;
    using MXGP.IO;
    using MXGP.IO.Contracts;
    using System.Linq;
    using System;

    public class Engine : IEngine
    {
        private IReader reader;
        private IWriter writer;
        private IChampionshipController championship;
        public Engine()
        {
            this.reader = new ConsoleReader();
            this.writer = new ConsoleWriter();
            this.championship = new ChampionshipController();
        }

        public void Run()
        {        
            while (true)
            {
                string input = this.reader.ReadLine();

                var tokens = input.Split(' ').ToArray();

                string command = tokens[0];

                string output = string.Empty;
                try
                {

                    switch (command)
                    {
                        case "CreateMotorcycle":
                            output = this.championship.CreateMotorcycle(tokens[1], tokens[2], int.Parse(tokens[3]));
                            break;
                        case "AddMotorcycleToRider":
                            output = this.championship.AddMotorcycleToRider(tokens[1], tokens[2]);
                            break;
                        case "AddRiderToRace":
                            output = this.championship.AddRiderToRace(tokens[1], tokens[2]);
                            break;
                        case "CreateRider":
                            output = this.championship.CreateRider(tokens[1]);
                            break;
                        case "CreateRace":
                            output = this.championship.CreateRace(tokens[1], int.Parse(tokens[2]));
                            break;
                        case "StartRace":
                            output = this.championship.StartRace(tokens[1]);
                            break;
                        default:
                            Environment.Exit(0);
                            break;
                    }

                    this.writer.WriteLine(output);
                }
                catch (Exception e)
                {

                    this.writer.WriteLine(e.Message);
                }              
            }
        }
    }
}
