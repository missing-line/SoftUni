namespace _7.EqualityLogic
{
    using System;
    public class Person : IComparable<Person>
    {
        private string name;
        private int age;
        public Person(string name, int age)
        {
            this.name = name;
            this.age = age;
        }

        public int CompareTo(Person other)
        {
            int p = this.name.CompareTo(other.name);
            if (p == 0)
            {
                return this.age.CompareTo(other.age);
            }
            return p;
        }

        public override bool Equals(object obj)
        {
            if (obj is Person person)
            {
                return this.name == person.name && this.age == person.age;
            }
            return false;
            //return Equals(obj as Person);
        }

        //public bool Equals(Person other)
        //{
        //    return other != null &&
        //           name == other.name &&
        //           age == other.age;
        //}

        public override int GetHashCode()
        {
             //return this.name.GetHashCode() + this.age.GetHashCode();
            return HashCode.Combine(name, age);
        }
    }
}
