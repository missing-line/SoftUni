namespace BorderControl
{    
    public class City : ICitizen, IRobot
    {
        public City(string name, int age, string id)
        {
            this.Name = name;
            this.Age = age;
            this.Id = id;
        }

        public City(string model, string id)
        {
           this.Model = model;
           this.Id = id;
        }

        public string Name
        {
            get;
            set;
        }
        public int Age
        {
            get;
            set;
        }
        public string Model
        {
            get;
            set;
        }

        public string Id { get; set; }
    }
}
