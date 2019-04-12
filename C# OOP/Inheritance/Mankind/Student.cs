namespace Mankind
{
    using System;
    using System.Linq;
    using System.Text.RegularExpressions;

    public class Student : Human
    {
        private string firstName;
        private string lastName;
        private string facultyNumber;

        public Student(string firstName, string lastaName, string facultyNumber)
            : base(firstName, lastaName)
        {
            this.FacultyNumber = facultyNumber;
        }

        public override string FirstName
        {
            get { return base.FirstName; }
            protected set { base.FirstName = value; }
        }

        public override string LastName
        {
            get { return base.LastName; }
            protected set { base.LastName = value; }
        }

        public string FacultyNumber
        {
            get { return this.facultyNumber; }
            private set
            {
                string pattern = @"^[a-zA-Z0-9]{5,10}$";

                if (!Regex.IsMatch(value, pattern))
                {
                    throw new ArgumentException("Invalid faculty number!");
                }
                this.facultyNumber = value;
            }
        }

        public override string ToString()
        {
            return $"{base.ToString()}" + Environment.NewLine +
                    $"Faculty number: {this.FacultyNumber}";
        }
    }
}
