namespace InfernoInfinity.Core.Commands
{
    using InfernoInfinity.Gems.Factory;
    using InfernoInfinity.Interfaces;
    using System.Linq;

    public class Add : Command
    {
        public Add(string[] data, IRepository repository, IWeaponFactory weaponFactory, IGemFactory gemFactory)
            : base(data, repository, weaponFactory, gemFactory)
        {
        }

        public override void Execute()
        {

            string name = this.Data[0];
            int index = int.Parse(this.Data[1]);
            string[] tokens = this.Data[2].Split().ToArray();
            string manner = tokens[0];
            string typeGem = tokens[1];

            IGem createGem = this.GemFactory.CreateGem(manner, typeGem);

            this.Repository.AddGem(name, index, createGem);

        }
    }
}
