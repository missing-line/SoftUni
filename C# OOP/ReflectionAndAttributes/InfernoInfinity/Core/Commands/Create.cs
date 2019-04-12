namespace InfernoInfinity.Core.Commands
{
    using InfernoInfinity.Gems.Factory;
    using InfernoInfinity.Interface;
    using InfernoInfinity.Interfaces;
    using System.Linq;

    public class Create : Command
    {
        private static IGemFactory gemFactory;

        public Create(string[] data, IRepository repository, IWeaponFactory weaponFactory,IGemFactory gemFactory) 
            : base(data, repository, weaponFactory, gemFactory)
        {
        }

        public override void Execute()
        {
            string[] token = this.Data[0].Split().ToArray();
            string rare = token[0];
            string type = token[1];
            string name = this.Data[1];

            IWeapon instanceCreateWeapon = this.WeaponFactory.CreateWeapon(rare, type, name);

            this.Repository.CreateWeapon(instanceCreateWeapon);
        }
    }
}
