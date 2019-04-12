namespace MilitaryElite
{
    using System;
    using System.Collections.Generic;
    using System.Text;

    public class Engineer : SpecialisedSoldier
    {
        private List<Repair> repairs;
        public Engineer(string id, string firstName, string secondName, decimal salary, string corp)
            : base(id, firstName, secondName, salary, corp)
        {
            this.repairs = new List<Repair>();
        }

        public void AddReprair(Repair repair)
        {
            this.repairs.Add(repair);
        }

        public override string ToString()
        {
            return base.ToString() + Environment.NewLine +
                        "Repairs:" + Environment.NewLine +
                        $"{string.Join("\n", this.repairs)}";
        }
    }
}
