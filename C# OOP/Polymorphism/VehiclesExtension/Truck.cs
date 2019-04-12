namespace VehiclesExtension
{
    public class Truck : Vehicle
    {
        private double fuelQuantity;
        private double fuelConsumption;
        private double tankCapacity;

        public Truck(double fuelQuantity, double fuelConsumption, double tankCapacity)
            : base(fuelQuantity, fuelConsumption, tankCapacity)
        {         
            this.FuelConsumption = fuelConsumption + 1.6;
        }

        public override double TankCapacity
        {
            get => base.TankCapacity;
            protected set => base.TankCapacity = value;
        }

        public override double FuelConsumption
        {
            get { return base.FuelConsumption; }
             set { base.FuelConsumption = value; }
        }

        public override double FuelQuantity
        {
            get { return base.FuelQuantity; }
            protected set { base.FuelQuantity = value; }
        }

        public override string Driving(double distance)
        {
            if (this.FuelQuantity - (distance * this.FuelConsumption) > 0)
            {
                this.FuelQuantity -= (distance * this.FuelConsumption);
                return $"Truck travelled {distance} km";
            }
            return $"Truck needs refueling";
        }

        public override void Refuel(double gas)
        {
            this.FuelQuantity += gas * 0.95;
        }
    }
}
