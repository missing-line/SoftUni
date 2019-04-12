namespace WorkForce
{
    public abstract class Employee : IEmployee
    {
        protected Employee(string name, int workHoursPereek)
        {
            this.Name = name;
            this.WorkHoursPereek = workHoursPereek;
        }

        public  string Name { get; }

        public  int WorkHoursPereek { get; set; }      
    }
}
