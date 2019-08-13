namespace MXGP.Models.Motorcycles.Contracts
{
    using MXGP.Utilities.Messages;
    using System;

    public class SpeedMotorcycle : Motorcycle
    {
        private int horsePower;
        public SpeedMotorcycle(string model, int horsePower) 
            : base(model, horsePower, 125)
        {
        }

        public override int HorsePower
        {
            get => this.horsePower;
            protected set
            {
                if (value < 50 || value > 69)
                {
                    throw new ArgumentException(string.Format(ExceptionMessages.InvalidHorsePower, value));
                }
                this.horsePower = value;
            }
        }
    }
}
