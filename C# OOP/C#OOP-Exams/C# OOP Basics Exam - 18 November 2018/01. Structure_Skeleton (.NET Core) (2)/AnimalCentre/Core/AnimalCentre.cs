using AnimalCentre.Models.Animals.Factory;
using AnimalCentre.Models.Contracts;
using AnimalCentre.Models.Hotel;
using AnimalCentre.Models.Procedures.Factory;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace AnimalCentre.Core
{
    public class AnimalCentre
    {
        private IFactoryCreaterAnimal createAnimal;
        private IHotel hotel;
        private Dictionary<string, List<IProcedure>> procedures;
        private IFactoryProcedure factoryProcedure;
        private Dictionary<string, List<string>> owners;

        public AnimalCentre()
        {
            this.createAnimal = new FactoryCreaterAnimal();
            this.hotel = new Hotel();
            this.procedures = new Dictionary<string, List<IProcedure>>();
            this.factoryProcedure = new FactoryProcedure();
            this.owners = new Dictionary<string, List<string>>();
        }

        internal void RegisterAnimal()
        {
            throw new NotImplementedException();
        }

        public string RegisterAnimal(string type, string name, int energy, int happiness, int procedureTime)
        {
            IAnimal animal = this.createAnimal
                .CreateAnimal(type, name, energy, happiness, procedureTime);

            this.hotel.Accommodate(animal);

            return $"Animal {animal.Name} registered successfully";
        }

        public string Chip(string name, int procedureTime)
        {

            this.factoryProcedure.AddProcedure(this.procedures, this.hotel, name, procedureTime, "Chip");

            return $"{name} had chip procedure";

        }

        public string Vaccinate(string name, int procedureTime)
        {
            this.factoryProcedure.AddProcedure(this.procedures, this.hotel, name, procedureTime, "Vaccinate");

            return $"{name} had vaccination procedure";
        }

        public string Fitness(string name, int procedureTime)
        {
            this.factoryProcedure.AddProcedure(this.procedures, this.hotel, name, procedureTime, "Fitness");

            return $"{name} had fitness procedure";
        }

        public string Play(string name, int procedureTime)
        {
            this.factoryProcedure.AddProcedure(this.procedures, this.hotel, name, procedureTime, "Play");

            return $"{name} was playing for {procedureTime} hours";
        }

        public string DentalCare(string name, int procedureTime)
        {
            this.factoryProcedure.AddProcedure(this.procedures, this.hotel, name, procedureTime, "DentalCare");

            return $"{name} had dental procedure";
        }

        public string NailTrim(string name, int procedureTime)
        {
            this.factoryProcedure.AddProcedure(this.procedures, this.hotel, name, procedureTime, "NailTrim");

            return $"{name} had nail trim procedure";
        }

        public string Adopt(string animalName, string owner)
        {
            IAnimal animal = this.hotel.GetAnimal(animalName);

            this.hotel.Adopt(animal.Name, owner);

            if (!this.owners.ContainsKey(owner))
            {
                this.owners.Add(owner, new List<string>());
            }

            this.owners[owner].Add(animalName);

            if (animal.IsChipped)
            {
                return $"{owner} adopted animal with chip";
            }
            else
            {
                return $"{owner} adopted animal without chip";
            }
        }

        public string History(string type)
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendLine(type);

            foreach (var procedure in this.procedures.Where(x=>x.Key == type))
            {
                foreach (var inner in procedure.Value)
                {
                    sb.AppendLine(inner.History());
                }
            }

            return sb.ToString().TrimEnd();
        }


        public string GetOWners()
        {
            StringBuilder sb = new StringBuilder();
            
            foreach (var owner in this.owners.OrderBy(x=>x.Key))
            {
                sb.AppendLine($"--Owner: {owner.Key}");
                sb.AppendLine($"    - Adopted animals: {string.Join(" ", owner.Value)}");
            }

            return sb.ToString().TrimEnd();
        }
    }
}
