namespace CarSalesman
{
    public class Car
    {
        private string model;
        private Engine engine;
        private string weight;
        private string color;
    
        public Car()
        {
            this.Model = model;
            this.Engine = engine;
            this.Weight = "n/a";
            this.Color = "n/a";
        }
        public string Model
        {
            get { return model; }
            set { model = value; }
        }
        public Engine Engine
        {
            get { return engine; }
            set { engine = value; }
        }

        public string Color
        {
            get { return color; }
            set { color = value; }
        }

        public string Weight
        {
            get { return weight; }
            set { weight = value; }
        }

    }
}
