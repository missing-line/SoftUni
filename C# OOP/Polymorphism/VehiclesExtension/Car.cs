namespace VehiclesExtension
{
    public class Car : Vehicle
    {
        private double fuelQuantity;
        private double fuelConsumption;
        private double tankCapacity;

        public Car(double fuelQuantity, double fuelConsumption, double tankCapacity)
            : base(fuelQuantity, fuelConsumption, tankCapacity)
        {
            this.FuelConsumption = fuelConsumption + 0.9;
        }

        public override double TankCapacity
        {
            get => base.TankCapacity;
            protected set => base.TankCapacity = value;
        }

        public override double FuelConsumption

        {
            get => base.FuelConsumption;
            set => base.FuelConsumption = value;
        }

        public override double FuelQuantity
        {
            get => base.FuelQuantity;
            protected set => base.FuelQuantity = value;
        }

        public override string Driving(double distance)
        {
            if (this.FuelQuantity - (distance * this.FuelConsumption) > 0)
            {
                this.FuelQuantity -= (distance * this.FuelConsumption);
                return $"Car travelled {distance} km";
            }
            return $"Car needs refueling";
        }

        public override void Refuel(double gas)
        {
            this.FuelQuantity += gas;
        }
    }
}
