namespace SpaceStation.Repositories
{
    using System.Collections.Generic;
    using System.Linq;
    using SpaceStation.Models.Planets;
    using SpaceStation.Repositories.Contracts;

    public class PlanetRepository : IRepository<IPlanet>
    {
        private List<IPlanet> planets;

        public PlanetRepository()
        {
            this.planets = new List<IPlanet>();
        }
        public IReadOnlyCollection<IPlanet> Models
            => this.planets.AsReadOnly();

        public void Add(IPlanet model)
        {
            this.planets.Add(model);
        }

        public IPlanet FindByName(string name)
        {
            return this.planets.FirstOrDefault(x => x.Name == name);
        }

        public bool Remove(IPlanet model)
        {
            if (this.planets.Any(x => x.Name == model.Name))
            {
                this.planets.Remove(model);
                return true;
            }
            return false;
        }
    }
}
