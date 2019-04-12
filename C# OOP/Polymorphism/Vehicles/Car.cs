using System;
using System.Collections.Generic;
using System.Text;

namespace Vehicles
{
    public class Car : Vehicle
    {
        private double fuelQuantity;
        private double fuelConsumption;

        public Car(double fuelQuantity, double fuelConsumption)
            : base(fuelQuantity, fuelConsumption)
        {
            this.FuelQuantity = fuelQuantity;
            this.FuelConsumption = fuelConsumption + 0.9;
        }

        public override double FuelQuantity
        { get => base.FuelQuantity; protected set => base.FuelQuantity = value; }
        public override double FuelConsumption
        { get => base.FuelConsumption; protected set => base.FuelConsumption = value; }

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
            this.FuelQuantity += gas;
        }       
    }
}
