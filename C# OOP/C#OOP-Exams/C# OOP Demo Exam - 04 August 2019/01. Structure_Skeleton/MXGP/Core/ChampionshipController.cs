namespace MXGP.Core
{
    using MXGP.Core.Contracts;
    using MXGP.Factories.MotocycleFactory;
    using MXGP.Models.Races;
    using MXGP.Models.Riders;
    using MXGP.Repositories;
    using MXGP.Utilities.Messages;
    using System;
    using System.Linq;

    public class ChampionshipController : IChampionshipController
    {
        private IMotorcycleFactory motorcycle;
        private MotorcycleRepository motors;
        private RaceRepository races;
        private RiderRepository riders;

        public ChampionshipController()
        {
            this.motorcycle = new MotorcycleFactory();
            this.motors = new MotorcycleRepository();
            this.races = new RaceRepository();
            this.riders = new RiderRepository();
        }
        public string AddMotorcycleToRider(string riderName, string motorcycleModel)
        {
            var rider = this.riders.GetByName(riderName);

            if (rider == null)
            {
                throw new InvalidOperationException(
                   string.Format(
                       ExceptionMessages.RiderNotFound,
                       riderName));
            }

            var motor = this.motors.GetByName(motorcycleModel);

            if (motor == null)
            {
                throw new InvalidOperationException(
                    string.Format(
                        ExceptionMessages.MotorcycleNotFound,
                        motorcycleModel));
            }

            rider.AddMotorcycle(motor);

            return string.Format(
                OutputMessages.MotorcycleAdded,
                riderName,
                motorcycleModel);
        }

        public string AddRiderToRace(string raceName, string riderName)
        {
            var race = this.races.GetByName(raceName);

            if (race == null)
            {
                throw new InvalidOperationException(
                    string.Format(
                        ExceptionMessages.RaceNotFound,
                        raceName));
            }

            var rider = this.riders.GetByName(riderName);

            if (rider == null)
            {
                throw new InvalidOperationException(
                    string.Format(
                        ExceptionMessages.RiderNotFound,
                        riderName));
            }

            race.AddRider(rider);

            return string.Format(
                OutputMessages.RiderAdded,
                riderName,
                raceName);
        }

        public string CreateMotorcycle(string type, string model, int horsePower)
        {

            if (this.motors.GetAll().Any(x => x.Model == model))
            {
                throw new ArgumentException(
                    string.Format(ExceptionMessages.MotorcycleExists, model)
                    );
            }
            var motor = this.motorcycle.CreateMotorcycle(type, model, horsePower);
            this.motors.Add(motor);

            return string.Format(OutputMessages.MotorcycleCreated, motor.GetType().Name, model);
        }

        public string CreateRace(string name, int laps)
        {
            if (this.races.GetAll().Any(x => x.Name == name))
            {
                throw new InvalidOperationException(
                    string.Format(
                        ExceptionMessages.RaceExists,
                        name));
            }

            var race = new Race(name, laps);
            this.races.Add(race);

            return string.Format(
                OutputMessages.RaceCreated,
                name);
        }

        public string CreateRider(string riderName)
        {
            if (this.riders.GetAll().Any(x => x.Name == riderName))
            {
                throw new ArgumentException(
                   string.Format(
                       ExceptionMessages.RiderExists,
                       riderName));
            }

            this.riders.Add(new Rider(riderName));

            return string.Format(
                OutputMessages.RiderCreated,
                riderName);
        }

        public string StartRace(string raceName)
        {
            var race = this.races.GetByName(raceName);

            if (race == null)
            {
                throw new InvalidOperationException(
                    string.Format(
                        ExceptionMessages.RaceNotFound,
                        raceName));
            }

            var winners = race
                .Riders
                .OrderByDescending(x => x.Motorcycle.CalculateRacePoints(race.Laps))
                .ToList();


            if (winners.Count < 3)
            {
                throw new InvalidOperationException(
                    string.Format(
                        ExceptionMessages.RaceInvalid,
                        raceName,
                        3));
            }


            winners[0].WinRace();

            this.races.Remove(race);

            return $"Rider {winners[0].Name} wins {race.Name} race." + Environment.NewLine +
                    $"Rider {winners[1].Name} is second in {race.Name} race." + Environment.NewLine +
                    $"Rider {winners[2].Name} is third in {race.Name} race.";
        }
    }
}

