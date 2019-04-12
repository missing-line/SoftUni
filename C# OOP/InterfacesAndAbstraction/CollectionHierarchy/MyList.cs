namespace CollectionHierarchy
{
    public class MyList : AddRemoveCollection, IUsed
    {
        public MyList()
        {
        }

        public override int Add(string element)
        {
            return base.Add(element);
        }

        public override string Remove()
        {
            string element = this.List[0];
            this.List.RemoveAt(0);
            return element;
        }

        public int Used()
        {
            return this.List.Count;
        }
    }
}
