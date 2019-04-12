namespace _03BarracksFactory.Core
{
    using System;
    using Contracts;
    using P03_BarraksWars.Core.Factories;

    class Engine : IRunnable
    {
        private IRepository repository;
        private IUnitFactory unitFactory;

        public Engine(IRepository repository, IUnitFactory unitFactory)
        {
            this.repository = repository;
            this.unitFactory = unitFactory;
        }

        public void Run()
        {
            while (true)
            {
                try
                {
                    string input = Console.ReadLine();
                    string[] data = input.Split();
                    string commandName = data[0];
                    string result = CommandInterpreter.InterpredCommand(data, commandName, this.repository, this.unitFactory);
                    Console.WriteLine(result);
                }
                catch (Exception e)
                {
                    Console.WriteLine(e.Message);
                }
            }
        }

        // TODO: refactor for Problem 4
        //private string InterpredCommand(string[] data, string commandName)
        //{
        //    commandName = commandName[0].ToString().ToUpper() + commandName.Substring(1) + "Command";
        //    Type type = Type.GetType($"P03_BarraksWars.Core.CommandPattern.{commandName}");

        //    IExecutable intsance = (IExecutable)Activator
        //        .CreateInstance(type, new object[] { data, this.repository, this.unitFactory });

        //    return intsance.Execute();

        //    //    string result = string.Empty;
        //    //    switch (commandName)
        //    //    {
        //    //        case "add":
        //    //            result = this.AddUnitCommand(data);
        //    //            break;
        //    //        case "report":
        //    //            result = this.ReportCommand(data);
        //    //            break;
        //    //        case "fight":
        //    //            Environment.Exit(0);
        //    //            break;
        //    //        default:
        //    //            throw new InvalidOperationException("Invalid command!");
        //    //    }
        //    //    return result;
        //    //}


        //    //private string ReportCommand(string[] data)
        //    //{
        //    //    string output = this.repository.Statistics;
        //    //    return output;
        //    //}


        //    //private string AddUnitCommand(string[] data)
        //    //{
        //    //    string unitType = data[1];
        //    //    IUnit unitToAdd = this.unitFactory.CreateUnit(unitType);
        //    //    this.repository.AddUnit(unitToAdd);
        //    //    string output = unitType + " added!";
        //    //    return output;
        //    //}
        //}
    }
}
