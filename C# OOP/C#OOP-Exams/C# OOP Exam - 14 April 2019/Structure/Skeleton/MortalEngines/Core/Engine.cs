namespace MortalEngines.Core
{
    using MortalEngines.Core.Contracts;
    using MortalEngines.IO;
    using MortalEngines.IO.Contracts;

    using System;

    public class Engine : IEngine
    {
        private IWriter writer;
        private IReader reader;
        private IMachinesManager machinesManager;    

        public Engine()
        {
            this.writer = new WriteController();
            this.reader = new ReadController();
            this.machinesManager = new MachinesManager();
        }

        public void Run()
        {
            while (true)
            {
                string[] input = this.reader
                    .ReadCommands()
                    .Split(' ');

                string commnad = input[0];

                if (commnad == "Quit")
                {
                    Environment.Exit(0);
                }

                string output = string.Empty;
                try
                {
                    switch (commnad)
                    {
                        case "HirePilot":
                            output = this.machinesManager.HirePilot(input[1]);
                            break;
                        case "PilotReport":
                            output = this.machinesManager.PilotReport(input[1]);
                            break;
                        case "MachineReport":
                            output = this.machinesManager.MachineReport(input[1]);
                            break;
                        case "ManufactureTank":
                            output = this.machinesManager.ManufactureTank(input[1], double.Parse(input[2]), double.Parse(input[3]));
                            break;
                        case "ManufactureFighter":
                            output = this.machinesManager.ManufactureFighter(input[1], double.Parse(input[2]), double.Parse(input[3]));
                            break;
                        case "AggressiveMode":
                            output = this.machinesManager.ToggleFighterAggressiveMode(input[1]);
                            break;
                        case "DefenseMode":
                            output = this.machinesManager.ToggleTankDefenseMode(input[1]);
                            break;
                        case "Engage":
                            output = this.machinesManager.EngageMachine(input[1], input[2]);
                            break;
                        case "Attack":
                            output = this.machinesManager.AttackMachines(input[1], input[2]);
                            break;
                        default:
                            break;
                    }

                    this.writer.Write(output);
                }
                catch (Exception e)
                {

                    Console.WriteLine($"Error: {e.Message}");
                }
            }
        }
    }
}
