using System;
using _03BarracksFactory.Contracts;

namespace P03_BarraksWars.Core.CommandPattern
{
    public class FightCommand : Command
    {
        public FightCommand(string[] data, IRepository repository, IUnitFactory unit)
            : base(data, repository, unit)
        {
        }

        public override string Execute()
        {
            Environment.Exit(0);
            return null;
        }
    }
}
