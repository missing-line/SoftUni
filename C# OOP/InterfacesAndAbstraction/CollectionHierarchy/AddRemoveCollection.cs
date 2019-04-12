using System.Collections.Generic;

namespace CollectionHierarchy
{
    public class AddRemoveCollection : Collection, IAdd, IRemote
    {
        public AddRemoveCollection()
        {
        }

        public virtual int Add(string element)
        {
            this.List.Insert(0, element);

            return 0;
        }

        public virtual string Remove()
        {
            string element = this.List[this.List.Count - 1];
            this.List.RemoveAt(this.List.Count - 1);
            return element;
        }
    }
}
