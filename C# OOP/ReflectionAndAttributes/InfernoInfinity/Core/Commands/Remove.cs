namespace InfernoInfinity.Core.Commands
{
    using InfernoInfinity.Gems.Factory;
    using InfernoInfinity.Interfaces;
    public class Remove : Command
    {
        public Remove(string[] data, IRepository repository, IWeaponFactory weaponFactory, IGemFactory gemFactory) 
            : base(data, repository, weaponFactory, gemFactory)
        {
        }

        public override void Execute()
        {
            string name = this.Data[0];
            int index = int.Parse(this.Data[1]);

            this.Repository.RemoveGem(name, index);
        }
    }
}
