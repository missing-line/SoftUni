namespace VehiclesExtension
{
    using System;
    public abstract class Vehicle : IVehicle
    {
        private double fuelQuantity;
        private double fuelConsumption;
        private double tankCapacity;


        public Vehicle(double fuelQuantity, double fuelConsumption, double tankCapacity)
        {
            this.TankCapacity = tankCapacity;

            if (fuelQuantity > this.TankCapacity)
            {
                this.FuelQuantity = 0;
            }
            else
            {
                this.FuelQuantity = fuelQuantity;
            }

            this.FuelConsumption = fuelConsumption;
        }

        public virtual double TankCapacity
        {
            get { return this.tankCapacity; }
            protected set
            {
                this.tankCapacity = value;
            }
        }

        public virtual double FuelConsumption
        {
            get { return this.fuelConsumption; }
            set
            {
                this.fuelConsumption = value;
            }
        }

        public virtual double FuelQuantity
        {
            get { return this.fuelQuantity; }
            protected set
            {
                this.fuelQuantity = value;
            }
        }

        public virtual string Driving(double distance)
        {
            throw new NotImplementedException();
        }

        public virtual void Refuel(double gas)
        {
            throw new NotImplementedException();
        }

        public override string ToString()
        {
            return $"{this.GetType().Name}: {FuelQuantity:F2}";
        }
    }
}
