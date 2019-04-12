using AnimalCentre.Models.Contracts;
using System.Collections.Generic;

namespace AnimalCentre.Models.Procedures.Factory
{
    public interface IFactoryProcedure
    {
        void AddProcedure(Dictionary<string, List<IProcedure>> procedures, IHotel hotel, string name, int procedureTime,string type);
    }
}
