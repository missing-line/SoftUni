using System.Collections.Generic;

namespace _1.ListyIterator
{
    public class ListyIterator<T>
    {

        private List<T> data;
        private int index;
        public ListyIterator(List<T> data)
        {
            this.data = data;
            this.index = 0;
        }
       

        public bool Move() 
        {
            if (HasNext())
            {
                index++;
                return true;
            }
            return false;
        }

        public bool HasNext()
        {
            return index + 1 < this.data.Count;
        }

        public string Print()
        {
            if (this.data.Count == 0)
            {
                return "Invalid Operation!";
            }
            return this.data[index].ToString();
        }
    }
}
