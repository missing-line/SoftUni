namespace _5.ComparingObjects
{
    using System;
    using System.Collections.Generic;
    using System.Text;
    public class Person : IComparable<Person>
    {
        private string name;
        private int age;
        private string town;

        public Person(string name, int age, string town)
        {
            this.Name = name;
            this.Age = age;
            this.Town = town;
        }

        public string Town
        {
            get { return town; }
            set { town = value; }
        }

        public int Age
        {
            get { return age; }
            set { age = value; }
        }

        public string Name
        {
            get { return name; }
            set { name = value; }
        }

        public int CompareTo(Person other)
        {
            int resultNames = this.Name.CompareTo(other.Name);

            if (resultNames == 0)
            {
                int resultsAge = this.Age.CompareTo(other.Age);

                if (resultsAge == 0)
                {
                   return this.Town.CompareTo(other.Town);
                }
                return resultsAge;
            }

            return resultNames;
        }
    }
}
