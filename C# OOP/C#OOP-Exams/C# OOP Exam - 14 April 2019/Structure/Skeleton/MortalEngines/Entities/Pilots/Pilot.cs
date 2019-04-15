namespace MortalEngines.Entities.Contracts.Pilots
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;

    public class Pilot : IPilot
    {
        private string name;
        private IList<IMachine> machines;

        public Pilot(string name)
        {
            this.Name = name;
            this.machines = new List<IMachine>();
        }

        public string Name
        {
            get => this.name;
            private set
            {
                if (string.IsNullOrEmpty(value) || string.IsNullOrWhiteSpace(value))
                {
                    throw new ArgumentNullException("Pilot name cannot be null or empty string.");
                }
                this.name = value;
            }
        }

        public IReadOnlyCollection<IMachine> Machines
            => this.machines.ToList().AsReadOnly();  //
        public void AddMachine(IMachine machine)
        {
            if (machine == null)
            {
                throw new NullReferenceException("Null machine cannot be added to the pilot.");
            }

            this.machines.Add(machine);
        }

        public string Report()
        {
            var sb = new StringBuilder();
            sb.AppendLine($"{this.Name} - {this.Machines.Count} machines");

            foreach (var machine in this.machines)
            {
                sb.AppendLine($"- {machine.Name}");
                sb.AppendLine($" *Type: {machine.GetType().Name}");
                sb.AppendLine($" *Health: {machine.HealthPoints}");
                sb.AppendLine($" *Attack: {machine.AttackPoints}");
                sb.AppendLine($" *Defense: {machine.DefensePoints}");
                if (machine.Targets.Count == 0)
                {
                    sb.AppendLine($" *Targets: None");
                }
                else
                {
                    sb.AppendLine($" *Targets: {string.Join(",", machine.Targets)}");
                }

            }
            return sb.ToString().TrimEnd();
        }
    }
}
