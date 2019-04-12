namespace InfernoInfinity.Core.Commands
{
    using InfernoInfinity.Gems.Factory;
    using InfernoInfinity.Interface;
    using InfernoInfinity.Interfaces;
    using System;

    public class Print : Command
    {
        private static IGemFactory gemFactory;

        public Print(string[] data, IRepository repository, IWeaponFactory weaponFactory, IGemFactory gemFactory) 
            : base(data, repository, weaponFactory, gemFactory)
        {
        }

        public override void Execute()
        {
            string nameWeapon = this.Data[0];

            IWeapon weapon = this.Repository.GetInstance(nameWeapon);

            Console.WriteLine(weapon.ToString());
        }
    }
}
