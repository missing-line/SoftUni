namespace _8.PetClinic
{
    public class Pet 
    {
        private string name;
        private int age;
        private string type;

        public Pet(string name, int age, string type)
        {
            this.Name = name;
            this.Age = age;
            this.Type = type;
        }

        public string Type
        {
            get { return type; }
            set { type = value; }
        }

        public int Age
        {
            get { return age; }
            set { age = value; }
        }

        public string Name
        {
            get { return name; }
            set { name = value; }
        }

        public override string ToString()
        {
            return $"{this.Name} {this.Age} {this.Type}";
        }
    }
}
