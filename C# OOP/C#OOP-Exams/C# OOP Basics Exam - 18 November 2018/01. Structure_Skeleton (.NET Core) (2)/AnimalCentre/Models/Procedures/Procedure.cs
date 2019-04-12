namespace AnimalCentre.Models
{
    using System;
    using System.Collections.Generic;
    using System.Text;
    using AnimalCentre.Models.Contracts;
    public abstract class Procedure : IProcedure
    {
        protected List<IAnimal> procedureHistory;

        protected Procedure()
        {
            this.procedureHistory = new List<IAnimal>();
        }

        public abstract void DoService(IAnimal animal, int procedureTime);
        
        public string History()
        {
            StringBuilder sb = new StringBuilder();

            //sb.AppendLine(this.GetType().Name);

            foreach (var animalProcedure in procedureHistory)
            {
                sb.AppendLine(animalProcedure.ToString());
            }

            return sb.ToString().TrimEnd();
        }

        protected void CheckTime(IAnimal animal , int time)
        {
            if (animal.ProcedureTime >= time)
            {
                animal.ProcedureTime -= time;
            }
            else
            {
                throw new ArgumentException("ArgumentException: Animal doesn't have enough procedure time");
            }
        }
    }
}
