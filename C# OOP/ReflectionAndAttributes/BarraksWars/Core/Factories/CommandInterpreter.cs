namespace P03_BarraksWars.Core.Factories
{
    using _03BarracksFactory.Contracts;
    using System;
    public class CommandInterpreter
    {

        public static string InterpredCommand(string[] data, string commandName, IRepository repository, IUnitFactory unitFactory)
        {
            commandName = commandName[0].ToString().ToUpper() + commandName.Substring(1) + "Command";
            Type type = Type.GetType($"P03_BarraksWars.Core.CommandPattern.{commandName}");

            IExecutable intsance = (IExecutable)Activator
                .CreateInstance(type, new object[] { data, repository, unitFactory });

            return intsance.Execute();
        }
    }
}
