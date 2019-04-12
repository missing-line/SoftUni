using System;
using _03BarracksFactory.Contracts;

namespace P03_BarraksWars.Core.CommandPattern
{
    public class RetireCommand : Command
    {
        public RetireCommand(string[] data, IRepository repository, IUnitFactory unit)
            : base(data, repository, unit)
        {
        }

        public override string Execute()
        {
            
            string unitType = this.Data[1];
            try
            {
                this.Repository.RemoveUnit(unitType);
                return $"{unitType} retired!";
            }
            catch (Exception ex)
            {

                return ex.Message;
            }
            
        }
    }
}
