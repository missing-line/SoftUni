namespace CarSalesman
{
    public class Engine
    {
        private string model;
        private int power;
        private string displacement;
        private string efficiency;

        public Engine()
        {
            this.Model = model;
            this.Power = power;
            this.Displacement = "n/a";
            this.Efficiency = "n/a";
        }

        public string Efficiency
        {
            get { return efficiency; }
            set { efficiency = value; }
        }

        public string Displacement
        {
            get { return displacement; }
            set { displacement = value; }
        }

        public int Power
        {
            get { return power; }
            set { power = value; }
        }

        public string Model
        {
            get { return model; }
            set { model = value; }
        }        
    }
}
