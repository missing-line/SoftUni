using _03BarracksFactory.Contracts;

namespace P03_BarraksWars.Core.CommandPattern
{
    public class ReportCommand : Command
    {
        public ReportCommand(string[] data, IRepository repository, IUnitFactory unit) 
            : base(data, repository, unit)
        {
        }

        public override string Execute()
        {
            return this.Repository.Statistics;
        }
    }
}
