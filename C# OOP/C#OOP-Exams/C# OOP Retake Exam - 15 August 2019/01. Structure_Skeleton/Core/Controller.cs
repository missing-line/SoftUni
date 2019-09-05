namespace SpaceStation.Core
{
    using SpaceStation.Core.Contracts;
    using SpaceStation.Core.Factories;
    using SpaceStation.Core.Factories.Contracts;
    using SpaceStation.Models.Astronauts.Contracts;
    using SpaceStation.Models.Mission;
    using SpaceStation.Models.Planets;
    using SpaceStation.Repositories;
    using SpaceStation.Repositories.Contracts;
    using System;
    using System.Linq;
    using System.Text;

    public class Controller : IController
    {
        private IFactoryAstonaut factoryAstonaut;
        private IRepository<IAstronaut> astronauts;
        private IRepository<IPlanet> planets;
        private IMission mission;
        private int exploredPlanetsCount;
        public Controller()
        {
            this.factoryAstonaut = new FactoryAstonaut();
            this.astronauts = new AstronautRepository();
            this.planets = new PlanetRepository();
            this.mission = new Mission();
            this.exploredPlanetsCount = 0;
        }
        public string AddAstronaut(string type, string astronautName)
        {
            var astronaut = this.factoryAstonaut.Create(type, astronautName);

            var find = this.astronauts.FindByName(astronautName);
            if (find == null)
            {
                this.astronauts.Add(astronaut);
                return $"Successfully added {astronaut.GetType().Name}: {astronautName}!";
            }

            return null;
        }

        public string AddPlanet(string planetName, params string[] items)
        {
            if (this.planets.FindByName(planetName) == null)
            {
                var planet = new Planet(planetName);

                for (int i = 0; i < items.Length; i++)
                {
                    planet.Items.Add(items[i]);
                }

                this.planets.Add(planet);
                return $"Successfully added Planet: {planetName}!";
            }

            return null;
        }

        public string ExplorePlanet(string planetName)
        {
            var planet = this.planets.FindByName(planetName);

            if (planet != null)
            {
                var canExplore = this.astronauts.Models
                    .Where(x => x.Oxygen > 60)
                    .ToList();

                if (canExplore.Count > 0)
                {
                    this.mission.Explore(planet, canExplore);

                    var deadAstronauts = canExplore
                        .Where(x => x.CanBreath == false)
                        .ToList();

                    this.exploredPlanetsCount++;

                    return $"Planet: {planetName} was explored! Exploration finished with {deadAstronauts.Count} dead astronauts!";
                }
                else
                {
                    throw new InvalidOperationException("You need at least one astronaut to explore the planet");
                }
            }

            return null;
        }

        public string Report()
        {

            StringBuilder sb = new StringBuilder();

            sb.AppendLine($"{this.exploredPlanetsCount} planets were explored!");
            sb.AppendLine("Astronauts info:");

            foreach (var astronaut in this.astronauts.Models)
            {
                sb.AppendLine($"Name: {astronaut.Name}");
                sb.AppendLine($"Oxygen: {astronaut.Oxygen}");
                if (astronaut.Bag.Items.Count == 0)
                {
                    sb.AppendLine("Bag items: none");
                }
                else
                {
                    sb.AppendLine($"Bag items: {string.Join(", ", astronaut.Bag.Items)}");
                }
            }         

            return sb.ToString().TrimEnd();
        }

        public string RetireAstronaut(string astronautName)
        {
            var astronaut = this.astronauts.FindByName(astronautName);

            if (astronaut == null)
            {
                throw new InvalidOperationException($"Astronaut {astronautName} doesn't exists!");
            }

            this.astronauts.Remove(astronaut);

            return $"Astronaut {astronautName} was retired!";
        }
    }
}
