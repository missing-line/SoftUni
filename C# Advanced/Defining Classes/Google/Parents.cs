namespace Google
{
    public class Parents
    {
        private string name;
        private string birthDay;

        public Parents(string name, string birthDay)
        {
            this.Name = name;
            this.BirthDay = birthDay;
        }

        public string BirthDay
        {
            get { return birthDay; }
            set { birthDay = value; }
        }

        public string Name
        {
            get { return name; }
            set { name = value; }
        }

        public override string ToString()
        {
            return $"{this.name} {this.birthDay}";
        }
    }
}
