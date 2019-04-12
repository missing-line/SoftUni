using System;
using System.Collections.Generic;
using System.Text;

namespace Vehicles
{
    public class Truck : Vehicle
    {
        private double fuelQuantity;
        private double fuelConsumption;

        public Truck(double fuelQuantity, double fuelConsumption)
            : base(fuelQuantity, fuelConsumption)
        {
            this.FuelQuantity = fuelQuantity;
            this.FuelConsumption = fuelConsumption + 1.6;
        }

        public override double FuelConsumption
        {
            get { return base.FuelConsumption; }
            protected set { base.FuelConsumption = value; }
        }

        public override double FuelQuantity
        {
            get { return base.FuelQuantity; }
            protected set { base.FuelQuantity = value; }
        }

        public override bool Driving(double distance)
        {
            if (this.FuelQuantity - (distance * this.FuelConsumption) > 0)
            {
                this.FuelQuantity -= (distance * this.FuelConsumption);
                return true;
            }
            return false;
        }

        public override void Refuel(double gas)
        {
            this.FuelQuantity += gas * 0.95;
        }
    }
}
