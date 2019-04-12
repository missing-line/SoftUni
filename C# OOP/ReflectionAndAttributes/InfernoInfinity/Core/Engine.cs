namespace InfernoInfinity.Core
{
    using InfernoInfinity.Gems.Factory;
    using InfernoInfinity.Interfaces;
    using System;
    using System.Linq;

    public class Engine : IRun
    {

        private IRepository repository;
        private ICommandInterpreter commandInterpreter;
        private IWeaponFactory weaponFactory;
        private IGemFactory gemFactory;

        public Engine(IRepository repository, ICommandInterpreter commandInterpreter, IWeaponFactory weaponFactory, IGemFactory gemFactory)
        {
            this.repository = repository;
            this.commandInterpreter = commandInterpreter;
            this.weaponFactory = weaponFactory;
            this.gemFactory = gemFactory;
        }
        public void Run()
        {
            string input;

            while ((input = Console.ReadLine()) != "END")
            {
                string[] data = input
                    .Split(';')
                    .ToArray();

                string commandName = data[0];

                string[] dataTokens = data.Skip(1)                   
                    .ToArray();

                IExecutable executable = this.commandInterpreter.InterpretCommand(commandName,
                    dataTokens,this.repository,this.weaponFactory,this.gemFactory);              

                executable.Execute();
                

            }
        }
    }
}
