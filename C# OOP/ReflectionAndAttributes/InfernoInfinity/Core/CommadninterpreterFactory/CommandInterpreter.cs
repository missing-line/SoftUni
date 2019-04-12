namespace InfernoInfinity.Core.Factories
{
    using InfernoInfinity.Gems.Factory;
    using InfernoInfinity.Interfaces;
    using System;

    public class CommandInterpreter : ICommandInterpreter
    {      
        public IExecutable InterpretCommand(string commandName, string[] data,
            IRepository repository, IWeaponFactory weaponFactury, IGemFactory gemFactory)
        {
            Type classType = Type.GetType($"InfernoInfinity.Core.Commands.{commandName}");

            IExecutable instance = (IExecutable)Activator.CreateInstance(classType, new object[] { data, repository, weaponFactury , gemFactory });

            return instance;
        }
    }
}
