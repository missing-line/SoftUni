namespace DP_Demo.Prototype
{
    using System.Collections.Generic;

    public class SandwichMenu
    {
        private Dictionary<string, SandwichProtoType> sandwiches;

        public SandwichMenu()
        {
            this.sandwiches = new Dictionary<string, SandwichProtoType>();
        }

        public SandwichProtoType this[string name]
        {
            get { return sandwiches[name]; }
            set { this.sandwiches.Add(name, value); }
        }
    }
}
