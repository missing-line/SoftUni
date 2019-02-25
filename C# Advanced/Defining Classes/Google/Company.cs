namespace Google
{
    using System;
    using System.Collections.Generic;
    using System.Text;
    public class Company
    {
        private string name;
        private string department;
        private double salary;

        public Company(string name, string department, double salary)
        {
            this.Name = name;
            this.Department = department;
            this.Salary = salary;
        }

        public double Salary
        {
            get { return salary; }
            set { this.salary = value; }
        }

        public string Department
        {
            get { return department; }
            set { department = value; }
        }

        public string Name
        {
            get { return name; }
            set { name = value; }
        }

        public override string ToString()
        {
            return $"{this.name} {this.department} {this.salary:f2}";
        }
    }
}
