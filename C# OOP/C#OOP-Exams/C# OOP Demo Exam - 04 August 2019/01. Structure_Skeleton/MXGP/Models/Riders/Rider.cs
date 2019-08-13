namespace MXGP.Models.Riders
{
    using MXGP.Models.Motorcycles.Contracts;
    using MXGP.Models.Riders.Contracts;
    using MXGP.Utilities.Messages;
    using System;

    public class Rider : IRider
    {
        private string name;

        public Rider(string name)
        {
            this.Name = name;
            this.CanParticipate = false;
            this.NumberOfWins = 0;
        }
        public string Name
        {
            get => this.name;
            private set
            {
                if (string.IsNullOrWhiteSpace(value) || value.Length < 5)
                {
                    throw new ArgumentException(string.Format(ExceptionMessages.InvalidName, value, 5));
                }
                this.name = value;
            }
        }

        public IMotorcycle Motorcycle { get; private set; }

        public int NumberOfWins { get; private set; }

        public bool CanParticipate { get; private set; }

        public void AddMotorcycle(IMotorcycle motorcycle)
        {
            this.Motorcycle = motorcycle ?? throw new ArgumentNullException(
                    ExceptionMessages.MotorcycleInvalid);

            this.CanParticipate = true;
        }

        public void WinRace()
        {
            this.NumberOfWins++;
        }
    }
}
