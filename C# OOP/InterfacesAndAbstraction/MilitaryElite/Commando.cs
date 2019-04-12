namespace MilitaryElite
{
    using System;
    using System.Collections.Generic;
    using System.Text;

    public class Commando : SpecialisedSoldier
    {
        private List<Mission> missions;

        public Commando(string id, string firstName, string secondName, decimal salary, string corp) 
            : base(id, firstName, secondName, salary, corp)
        {
            this.missions = new List<Mission>();
        }

        public void AddMission(Mission mission)
        {
            this.missions.Add(mission);
        }

        public override string ToString()
        {
            var builder = new StringBuilder();

            builder.AppendLine($"{base.ToString()}");

            builder.AppendLine("Missions:");

            if (this.missions.Count != 0)
            {
                foreach (var mission in this.missions)
                {
                    builder.AppendLine(mission.ToString());
                }
            }

            return builder.ToString().Trim();
        }
    }
}
