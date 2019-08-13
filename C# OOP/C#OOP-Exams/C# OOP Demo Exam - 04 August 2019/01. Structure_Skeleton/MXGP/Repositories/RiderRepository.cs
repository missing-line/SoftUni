namespace MXGP.Repositories
{
    using MXGP.Models.Riders.Contracts;
    using System.Linq;
    public class RiderRepository : Repository<IRider>
    {
        public override IRider GetByName(string name)
        {
            return this.GetAll().FirstOrDefault(r => r.Name == name);
        }
    }
}
