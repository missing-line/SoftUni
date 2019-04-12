namespace Mankind
{
    using System;
    public class Human
    {
        private string firstName;
        private string lastName;

        public Human(string firstName, string lastName)
        {
            this.FirstName = firstName;
            this.LastName = lastName;
        }

        public virtual string LastName
        {
            get { return this.lastName; }
            protected set
            {
                if (!char.IsUpper(value[0]))
                {
                    throw new ArgumentException("Expected upper case letter! Argument: lastName");
                }
                else if (value.Length <= 2)
                {
                    throw new ArgumentException("Expected length at least 3 symbols! Argument: lastName ");
                }
                this.lastName = value;
            }
        }

        public virtual string FirstName
        {
            get { return this.firstName; }
            protected set
            {
                if (!char.IsUpper(value[0]))
                {
                    throw new ArgumentException("Expected upper case letter! Argument: firstName");
                }
                else if (value.Length <= 3)
                {
                    throw new ArgumentException("Expected length at least 4 symbols! Argument: firstName");
                }
                this.firstName = value;
            }
        }

        public  override  string ToString()
        {
            return $"First Name: {this.FirstName}" + Environment.NewLine +
                    $"Last Name: {this.LastName}";
        }
    }
}
