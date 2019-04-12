namespace InfernoInfinity
{
    using InfernoInfinity.Core;
    using InfernoInfinity.Core.Factories;
    using InfernoInfinity.Data;
    using InfernoInfinity.Gems;
    using InfernoInfinity.Gems.Factory;
    using InfernoInfinity.Interfaces;
    using InfernoInfinity.Weapons.Factory;
    public class StartUp
    {
        public static void Main(string[] args)
        {
            IRepository repository = new Repository();
            ICommandInterpreter commandInterpreter = new CommandInterpreter();
            IWeaponFactory weaponFactory = new WeaponFactory();
            IGemFactory gemFactory = new GemFactory();
            IRun engine = new Engine(repository, commandInterpreter,weaponFactory, gemFactory);
            engine.Run();
        }
    }
}
