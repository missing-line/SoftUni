using CosmosX.Entities.Containers.Contracts;

namespace CosmosX.Entities.Reactors
{
    public class HeatReactor : BaseReactor
    {
        public HeatReactor(int id, IContainer moduleContainer, int heatReductionIndex)
            : base(id, moduleContainer) //check ..R
        {
            this.HeatReductionIndex = heatReductionIndex;
        }

        public int HeatReductionIndex { get; private set; }

        public override long TotalEnergyOutput
        {
            get
            {
                if (this.TotalHeatAbsorbing < base.TotalEnergyOutput) 
                {
                    return 0;
                }
                // 0 R
                return base.TotalEnergyOutput;
            }
        }

        public override long TotalHeatAbsorbing
       => base.TotalHeatAbsorbing + this.HeatReductionIndex;
    }
}
