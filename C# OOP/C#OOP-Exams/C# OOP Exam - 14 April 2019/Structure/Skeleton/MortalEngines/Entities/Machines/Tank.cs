namespace MortalEngines.Entities.Machines
{
    using MortalEngines.Entities.Contracts;

    using System;
    using System.Text;

    public class Tank : BaseMachine, ITank
    {
        public Tank(string name, double attack, double defence) 
            : base(name,attack , defence, 100)
        {
            this.DefenseMode = true;
            ToggleDefenseMode();
            this.DefenseMode = true;
        }

        public bool DefenseMode { get; private set; } //

        public void ToggleDefenseMode()
        {
            if (this.DefenseMode)
            {
                this.AttackPoints -= 40;
                this.DefensePoints += 30;
                this.DefenseMode = false;
            }
            else
            {
                this.AttackPoints += 40;
                this.DefensePoints -= 30;
                this.DefenseMode = true;
            }
        }

        public override string ToString()
        {
            var sb = new StringBuilder();

            sb.AppendLine(base.ToString());

            string mode = string.Empty;

            if (this.DefenseMode)
            {
                mode = "ON";
            }
            else
            {
                mode = "OFF";
            }
            sb.AppendLine($" *Defense: {mode}");

            return sb.ToString().TrimEnd();
        }
    }
}
