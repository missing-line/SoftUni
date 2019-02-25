namespace SpeedRacing
{
    public class Car
    {
        //model, fuel amount, fuel consumption for 1 kilometer 

        private string model;
        private double fuelAmount;
        private double fuelConsumation;
        private int distanceTravel;

        public Car(string model, double fuelAmount, double fuelConsumation)
        {
            this.Model = model;
            this.FuelAmount = fuelAmount;
            this.FuelConsumation = fuelConsumation;
            this.DistanceTravel = 0;
        }

        public string Model { get { return this.model; } set { this.model = value; } }

        public double FuelAmount { get { return this.fuelAmount; } set { this.fuelAmount = value; } }

        public double FuelConsumation { get { return this.fuelConsumation; } set { this.fuelConsumation = value; } }

        public int DistanceTravel { get { return this.distanceTravel; } set { this.distanceTravel = value; } }

        public bool CalculateFuel(int distance)
        {
            if (this.FuelAmount < this.FuelConsumation * distance)
            {               
                return false;
            }
            else
            {
                this.DistanceTravel += distance;
                this.FuelAmount -= (this.FuelConsumation * distance);
            }
            return true;
        }

    }
}
