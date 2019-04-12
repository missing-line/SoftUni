namespace InfernoInfinity.Core.Commands
{
    using InfernoInfinity.Gems.Factory;
    using InfernoInfinity.Interfaces;

    public abstract class Command : IExecutable
    {       

        private string[] data;
        private IRepository repository;
        private IWeaponFactory weaponFactory;
        private IGemFactory gemFactory;
        protected Command(string[] data,IRepository repository, IWeaponFactory weaponFactory,
            IGemFactory gemFactory)
        {
            this.Data = data;
            this.Repository = repository;
            this.WeaponFactory = weaponFactory;
            this.GemFactory = gemFactory;
        }

        public string[] Data { get; }
        public IRepository Repository { get => repository; set => repository = value; }
        public IWeaponFactory WeaponFactory { get => weaponFactory; set => weaponFactory = value; }
        public string[] Data1 { get => data; set => data = value; }
        public IGemFactory GemFactory { get => gemFactory; set => gemFactory = value; }

        public virtual void Execute()
        {
            
        }
    }
}
