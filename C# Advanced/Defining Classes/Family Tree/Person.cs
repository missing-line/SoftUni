namespace Family_Tree
{
    using System.Collections.Generic;
    public class Person
    {
        private string name;
        private string birth;
        private List<Person> parents;
        private List<Person> childrens;


        public Person(string name, string birth)
        {
            this.Name = name;
            this.Birth = birth;
            this.Parents = new List<Person>();
            this.Childrens = new List<Person>();
        }

        public string Birth
        {
            get { return birth; }
            set { birth = value; }
        }


        public List<Person> Childrens
        {
            get { return childrens; }
            set { childrens = value; }
        }

        public List<Person> Parents
        {
            get { return parents; }
            set { parents = value; }
        }

        public string Name
        {
            get { return name; }
            set { name = value; }
        }

        public override string ToString()
        {
            return $"{this.name} {this.birth}";
        }
    }
}
