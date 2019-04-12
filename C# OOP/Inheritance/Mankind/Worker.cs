namespace Mankind
{
    using System;
    public class Worker : Human
    {
        private decimal salary;
        private decimal workHourdPerDay;

        public Worker(string firstName, string lastName, decimal salary, decimal workHourdPerDay)
            : base(firstName, lastName)
        {
            this.Salary = salary;
            this.WorkHourdPerDay = workHourdPerDay;
        }

        public decimal WorkHourdPerDay
        {
            get { return this.workHourdPerDay; }
            private set
            {
                if (value > 12 || value < 1)
                {
                    throw new ArgumentException("Expected value mismatch! Argument: workHoursPerDay");
                }
                this.workHourdPerDay = value;
            }
        }

        public decimal Salary
        {
            get { return this.salary; }
            private set
            {
                if (value <= 10)
                {
                    throw new ArgumentException("Expected value mismatch! Argument: weekSalary");
                }
                this.salary = value;
            }
        }

        protected decimal SalaryPerHour()
        {
            return  this.salary / (5 * this.workHourdPerDay);
        }

        public override string ToString()
        {
            return  $"{base.ToString()}" + Environment.NewLine +
                    $"Week Salary: {this.Salary:f2}" + Environment.NewLine +
                    $"Hours per day: {this.WorkHourdPerDay:f2}" + Environment.NewLine +
                    $"Salary per hour: {SalaryPerHour():f2}";
        }
    }
}



