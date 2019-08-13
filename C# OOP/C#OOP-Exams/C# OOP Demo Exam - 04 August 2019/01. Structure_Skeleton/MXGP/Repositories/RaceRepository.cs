namespace MXGP.Repositories
{
    using MXGP.Models.Races.Contracts;
    using System.Linq;

    public class RaceRepository : Repository<IRace>
    {
        public override IRace GetByName(string name)
        {
            return this.GetAll().FirstOrDefault(r => r.Name == name);
        }
    }
}
