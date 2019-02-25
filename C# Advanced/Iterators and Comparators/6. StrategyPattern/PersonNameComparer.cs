namespace _6._StrategyPattern
{
    using System.Collections.Generic;
    public class PersonNameComparer : IComparer<Person>
    {
        public int Compare(Person first, Person second)
        {
            int name = first.Name.Length.CompareTo(second.Name.Length);
            if (name == 0)
            {
                return first.Name.ToLower()[0].CompareTo(second.Name.ToLower()[0]);
            }   
            return name;
        }
    }
}
