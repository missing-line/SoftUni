using InfernoInfinity.Gems.Factory;

namespace InfernoInfinity.Interfaces
{
    public interface ICommandInterpreter
    {
        IExecutable InterpretCommand(string commandName, string[] data, IRepository repository, IWeaponFactory weaponFactury, IGemFactory gemFactory);
    }
}
