namespace MilitaryElite
{
    using System;
    public class Spy : Soldier, ISpy
    {
        public Spy(string id, string firstName, string secondName,int codeNumber) 
            : base(id, firstName, secondName)
        {
            this.CodeNumber = codeNumber;
        }

        public int CodeNumber { get ; set; }

        public override string ToString()
        {
            return $"{base.ToString()}"
                    + Environment.NewLine +
                    $"Code Number: {this.CodeNumber}";
        }
    }
}
