namespace MilitaryElite
{
    using System;
    using System.Collections.Generic;
    using System.Text;

    public class LieutenantGeneral : Private
    {
        private List<Private> underCommand;
        public LieutenantGeneral(string id, string firstName, string secondName, decimal salary)
            : base(id, firstName, secondName, salary)
        {
            this.underCommand = new List<Private>();
        }

        public void AddPrivate(Private @private)
        {
            underCommand.Add(@private);
        }

        public override string ToString()
        {

            var builder = new StringBuilder();

            builder.AppendLine($"{base.ToString()}");

            builder.AppendLine("Privates:");

            if (this.underCommand.Count != 0)
            {
                foreach (var soldier in this.underCommand)
                {
                    builder.AppendLine(soldier.ToString());
                }
            }

            return builder.ToString().Trim();
        }
    }
}
