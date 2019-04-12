namespace TheTankGame.Core
{
    using System.Collections.Generic;
    using System.Linq;
    using System.Reflection;
    using Contracts;

    public class CommandInterpreter : ICommandInterpreter
    {
        private readonly IManager tankManager;

        public CommandInterpreter(IManager tankManager)
        {
            this.tankManager = tankManager;
        }

        public string ProcessInput(IList<string> inputParameters)
        {
            string command = inputParameters[0];
            List<string> data = inputParameters.Skip(1).ToList();

            string result = (string)this.tankManager
                .GetType()
                .GetMethods()
                .FirstOrDefault(m => m.Name.Contains(command))
                .Invoke(this.tankManager, new object[] { data });


            //switch (command)
            //{
            //    case "Vehicle":
            //        result = this.tankManager.AddVehicle(data);
            //        break;
            //    case "Part":
            //        result = this.tankManager.AddVehicle(data);
            //        break;
            //    case "Inspect":
            //        result = this.tankManager.Inspect(data);
            //        break;
            //    case "Battle":
            //        result = this.tankManager.Battle(data);
            //        break;
            //    case "Terminate":
            //        result = this.tankManager.Terminate(data);
            //        break;
            //}

            return result;
        }
    }
}