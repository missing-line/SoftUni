using ViceCity.Core.Contracts;
using System;
using System.Collections.Generic;
using System.Text;
using ViceCity.IO.Contracts;
using ViceCity.IO;

namespace ViceCity.Core
{
    public class Engine : IEngine
    {
        private IReader reader;
        private IWriter writer;
        private IController controller;

        public Engine()
        {
            this.reader = new Reader();
            this.writer = new Writer();
            this.controller = new Controller();

        }
        public void Run()
        {
            while (true)
            {
                var input = reader.ReadLine().Split();
                string command = input[0];

                string output = string.Empty;
                try
                {
                    switch (command)
                    {
                        case "AddPlayer":
                            output = this.controller.AddPlayer(input[1]);
                            break;
                        case "AddGun":
                            output = this.controller.AddGun(input[1], input[2]);
                            break;
                        case "AddGunToPlayer":
                            output = this.controller.AddGunToPlayer(input[1]);
                            break;
                        case "Fight":
                            output = this.controller.Fight();
                            break;
                        default: Environment.Exit(0);
                            break;
                    }
                    this.writer.WriteLine(output);         
                }
                catch (Exception ex)
                {
                    writer.WriteLine(ex.Message);
                }
            }
        }
    }
}
