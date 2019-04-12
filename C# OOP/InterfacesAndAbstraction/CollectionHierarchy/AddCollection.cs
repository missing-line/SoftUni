namespace CollectionHierarchy
{
    using System.Collections.Generic;
    public class AddCollection : Collection, IAdd
    {
        public AddCollection()
        {
        }

        public int Add(string element)
        {
            this.List.Add(element);
            return this.List.LastIndexOf(element);            
        }
    }
}
