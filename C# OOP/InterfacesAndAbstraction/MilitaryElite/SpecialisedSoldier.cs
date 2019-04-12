namespace MilitaryElite
{
    using System;
    public class SpecialisedSoldier : Private, ISpecialisedSoldier
    {
        public SpecialisedSoldier(string id, string firstName, string secondName, decimal salary, string corp)
            : base(id, firstName, secondName, salary)
        {
            this.Corp = corp;
        }

        public string Corp { get; set; }

        public override string ToString()
        {
            return base.ToString() + Environment.NewLine +
                   $"Corps: {this.Corp}";
        }
    }
}
