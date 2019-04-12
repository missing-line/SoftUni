namespace Vehicles
{
    using System;
    public class Vehicle : IVehicle
    {
        private double fuelQuantity;
        private double fuelConsumption;

        public Vehicle(double fuelQuantity, double fuelConsumption)
        {
            this.FuelQuantity = fuelQuantity;
            this.FuelConsumption = fuelConsumption;
        }

        public virtual double FuelConsumption
        {
            get { return this.fuelConsumption; }
            protected set
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

        public virtual bool Driving(double distance)
        {
            throw new NotImplementedException();
        }

        public virtual void Refuel(double gas)
        {
            throw new NotImplementedException();
        }

        public override string ToString()
        {
            return  $"{(this.FuelQuantity):f2}";
        }
    }
}
