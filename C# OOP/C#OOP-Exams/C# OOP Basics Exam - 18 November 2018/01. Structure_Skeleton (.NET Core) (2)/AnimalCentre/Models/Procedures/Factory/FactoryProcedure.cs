namespace AnimalCentre.Models.Procedures.Factory
{
    using System.Collections.Generic;
    using AnimalCentre.Models.Contracts;
    public class FactoryProcedure : IFactoryProcedure
    {
        private static IProcedure procedure;
        public void AddProcedure(Dictionary<string, List<IProcedure>> procedures, IHotel hotel,
            string name, int procedureTime, string type)
        {
            IAnimal animal = hotel.GetAnimal(name);

            switch (type)
            {
                case "Chip":
                    procedure = new Chip();
                    break;
                case "DentalCare":
                    procedure = new DentalCare();
                    break;
                case "Fitness":
                    procedure = new Fitness();
                    break;
                case "NailTrim":
                    procedure = new NailTrim();
                    break;
                case "Play":
                    procedure = new Play();
                    break;
                case "Vaccinate":
                    procedure = new Vaccinate();
                    break;
                default:
                    break;
            }
            procedure.DoService(animal, procedureTime);
            if (!procedures.ContainsKey(procedure.GetType().Name))
            {
                procedures.Add(procedure.GetType().Name, new List<IProcedure>());
            }
            procedures[procedure.GetType().Name].Add(procedure);
        }
    }
}
