namespace MilitaryElite
{
    public class Private : Soldier, IPrivate
    {
        
        public Private(string id, string firstName, string secondName,decimal salary) 
            : base(id, firstName, secondName)
        {
            this.Salary = salary;
        }

        public decimal Salary { get; set; }

        public override string ToString()
        {
            return $"{base.ToString()} Salary: {this.Salary:f2}";
        }
    }
}
