namespace Travel.Entities.Airplanes
{
    using System;
    using System.Collections.Generic;
    using System.Collections.Immutable;
    using System.Linq;
    using Entities.Contracts;
    using Travel.Entities.Airplanes.Contracts;


    public abstract class Airplane : IAirplane
    {
        private int seats;
        private int baggageCompartments;
        private List<IBag> baggageCompartment;
        private List<IPassenger> passengers;

        protected Airplane(int seats, int baggageCompartments)
        {
            this.Seats = seats;
            this.BaggageCompartments = baggageCompartments;
            this.baggageCompartment = new List<IBag>();
            this.passengers = new List<IPassenger>();

        }
        public int Seats //
        {
            get => this.seats;
            private set => this.seats = value;
        }
        public int BaggageCompartments //
        {
            get => this.baggageCompartments;
            private set => this.baggageCompartments = value;
        }
        public IReadOnlyCollection<IBag> BaggageCompartment => this.baggageCompartment.AsReadOnly();//
        public IReadOnlyCollection<IPassenger> Passengers => this.passengers.AsReadOnly();//
        public bool IsOverbooked => this.passengers.Count > this.seats;
        public void AddPassenger(IPassenger passenger)
        {

            this.passengers.Add(passenger);

        }
        public IPassenger RemovePassenger(int seatIndex)
        {
            IPassenger passenger = this.passengers[seatIndex];

            this.passengers.RemoveAt(seatIndex);

            return passenger;
        }

        public IEnumerable<IBag> EjectPassengerBags(IPassenger passenger)// to do
        {
            IList<IBag> passengerBags = this.baggageCompartment
                .Where(x => x.Owner == passenger).ToList();


            foreach (var bag in passengerBags)
            {
                this.baggageCompartment.Remove(bag);
            }

            return passengerBags;
        }

        public void LoadBag(IBag bag)
        {
            bool isBaggageCompartmentFull = this.BaggageCompartment.Count >= this.baggageCompartments;
            if (isBaggageCompartmentFull)
            {
                throw new InvalidOperationException($"No more bag room in {this.GetType().ToString()}!");
            }

            this.baggageCompartment.Add(bag);
        }
    }
}