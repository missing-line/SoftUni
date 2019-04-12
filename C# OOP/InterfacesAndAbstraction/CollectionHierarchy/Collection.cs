namespace CollectionHierarchy
{
    using System.Collections.Generic;
    public class Collection
    {
        private List<string> list;

        public Collection()
        {
            this.List = new List<string>(); ;
        }

        public List<string> List
        {
            get { return this.list; }
            private set { this.list = value; }
        }
    }
}
