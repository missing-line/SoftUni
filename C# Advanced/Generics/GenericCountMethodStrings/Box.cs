namespace GenericCountMethodStrings
{
    using System;
    using System.Collections.Generic;
    public class Box<T>
    {
        private List<T> data;

        public Box()
        {
            this.Data = new List<T>();
        }

        public List<T> Data
        {
            get { return this.data; }
            set { this.data = value; }
        }

        public int Cointing<T>(List<T> data, T element)
            where T : IComparable
        {
            int count = 0;
            for (int i = 0; i < data.Count; i++)
            {
                if (data[i].CompareTo(element) == 1)
                {
                    count++;
                }
            }

            return count;
        }
    }
}
