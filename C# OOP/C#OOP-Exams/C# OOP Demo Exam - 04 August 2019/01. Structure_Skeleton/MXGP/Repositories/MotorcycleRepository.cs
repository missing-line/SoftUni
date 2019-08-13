namespace MXGP.Repositories
{
    using MXGP.Models.Motorcycles.Contracts;
    using System.Linq;

    public class MotorcycleRepository : Repository<IMotorcycle>
    {
        public override IMotorcycle GetByName(string name)
        {
            return this.GetAll().FirstOrDefault(m => m.Model == name);
        }
    }
}
