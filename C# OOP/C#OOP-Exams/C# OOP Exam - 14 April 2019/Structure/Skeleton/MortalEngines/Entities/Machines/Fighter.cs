namespace MortalEngines.Entities.Machines
{
    using MortalEngines.Entities.Contracts;
    using System.Text;

    public class Fighter : BaseMachine , IFighter
    {
        public Fighter(string name,double attack, double defence)
           : base(name, attack, defence, 200)
        {
            this.AggressiveMode = true;
            ToggleAggressiveMode();
            this.AggressiveMode = true;
        }

        public bool AggressiveMode  { get; private set; } //

        public void ToggleAggressiveMode()
        {
            if (this.AggressiveMode)
            {
                this.AttackPoints += 50;
                this.DefensePoints -= 25;
                this.AggressiveMode = false;
            }
            else
            {
                this.AttackPoints -= 50;
                this.DefensePoints += 25;
                this.AggressiveMode = true;
            }
       
        }

        public override string ToString()
        {
            var sb = new StringBuilder();

            sb.AppendLine(base.ToString());

            string mode = string.Empty;

            if (this.AggressiveMode)
            {
                mode = "ON";
            }
            else
            {
                mode = "OFF";
            }
            sb.AppendLine($" *Aggressive: {mode}");

            return sb.ToString().TrimEnd();
        }
    }
}
