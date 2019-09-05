namespace SpaceStation.Repositories
{
    using System.Collections.Generic;
    using System.Linq;
    using SpaceStation.Models.Astronauts.Contracts;
    using SpaceStation.Repositories.Contracts;
    public class AstronautRepository : IRepository<IAstronaut>
    {
        private List<IAstronaut> astrounauts;

        public AstronautRepository()
        {
            this.astrounauts = new List<IAstronaut>();
        }
        public IReadOnlyCollection<IAstronaut> Models
            => this.astrounauts.AsReadOnly();

        public void Add(IAstronaut model)
        {
            this.astrounauts.Add(model);
        }

        public IAstronaut FindByName(string name)
        {
            return this.astrounauts.FirstOrDefault(x => x.Name == name);
        }

        public bool Remove(IAstronaut model)
        {
            if (this.astrounauts.Any(x => x.Name == model.Name))
            {
                this.astrounauts.Remove(model);
                return true;
            }
            return false;
        }
    }
}
