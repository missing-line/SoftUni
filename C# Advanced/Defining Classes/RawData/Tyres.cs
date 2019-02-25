namespace RawData
{
    public class Tyres
    {
        private double tire1Pressure;
        private double tire1Age;
        private double tire2Pressure;
        private double tire2Age;
        private double tire3Pressure;
        private double tire3Age;
        private double tire4Pressure;
        private double tire4Age;

        public Tyres(double tire1Pressure, double tire1Age, double tire2Pressure, double tire2Age, double tire3Pressure,  double tire3Age, double tire4Pressure, double tire4Age)
        {
            this.Tire1Pressure = tire1Pressure;
            this.Tire1Age = tire1Age;
            this.Tire2Pressure = tire2Pressure;
            this.Tire2Age = tire2Age;
            this.Tire3Pressure = tire3Pressure;
            this.Tire3Age = tire3Age;
            this.Tire4Pressure = tire4Pressure;
            this.Tire4Age = tire4Age;
            
        }
        public double Tire1Pressure { get { return this.tire1Pressure; } set { this.tire1Pressure = value; } }
        public double Tire1Age { get { return this.tire1Age; } set { this.tire1Age = value; } }
        public double Tire2Pressure { get { return this.tire2Pressure; } set { this.tire2Pressure = value; } }
        public double Tire2Age { get { return this.tire2Age; } set { this.tire2Age = value; } }
        public double Tire3Pressure { get { return this.tire3Pressure; } set { this.tire3Pressure = value; } }
        public double Tire3Age { get { return this.tire3Age; } set { this.tire3Age = value; } }
        public double Tire4Pressure { get { return this.tire4Pressure; } set { this.tire4Pressure = value; } }
        public double Tire4Age { get { return this.tire4Age; } set { this.tire4Age = value; } }
    }
}
