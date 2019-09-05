namespace SpaceStation.Models.Mission
{
    using System.Collections.Generic;
    using System.Linq;
    using SpaceStation.Models.Astronauts.Contracts;
    using SpaceStation.Models.Planets;
    public class Mission : IMission
    {
        public void Explore(IPlanet planet, ICollection<IAstronaut> astronauts)
        {
            while (astronauts.Any(x => x.CanBreath) && 
                   planet.Items.Count != 0)
            {
                var astronaut = astronauts.FirstOrDefault(x => x.CanBreath);

                while (astronaut.CanBreath && planet.Items.Count != 0)
                {
                    var item = planet.Items.FirstOrDefault();

                    astronaut.Breath();
                    astronaut.Bag.Items.Add(item);
                    planet.Items.Remove(item);
                }
            }
        }
    }
}
