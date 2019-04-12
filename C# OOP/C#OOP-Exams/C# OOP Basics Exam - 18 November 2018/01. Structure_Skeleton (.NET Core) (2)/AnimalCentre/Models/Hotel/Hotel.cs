namespace AnimalCentre.Models.Hotel
{
    using System;
    using System.Collections.Generic;
    using AnimalCentre.Models.Contracts;
    public class Hotel : IHotel
    {
        private Dictionary<string, IAnimal> animals;
        private  int capacity = 10;
        public Hotel()
        {
            this.animals = new Dictionary<string,IAnimal>();
            this.capacity = 10;
        }
        
        public IReadOnlyDictionary<string, IAnimal> Animals => this.animals;
        
        public void Accommodate(IAnimal animal)
        {
            if (this.capacity <= this.animals.Count) //
            {
                throw new InvalidOperationException("InvalidOperationException: Not enough capacity");
            }
            else if (this.animals.ContainsKey(animal.Name))
            {
                throw new ArgumentException($"ArgumentException: Animal {animal.Name} already exist");
            }
            else
            {
                this.animals.Add(animal.Name, animal);
            }
        }

        public void Adopt(string animalName, string owner) //
        {
            if (!this.animals.ContainsKey(animalName))
            {
                throw new ArgumentException($"ArgumentException: Animal {animalName} does not exist");
            }

            IAnimal animal = this.animals[animalName];
            animal.Owner = owner;
            animal.IsAdopt = true;
            this.animals.Remove(animalName);
        }

        public IAnimal GetAnimal(string name)
        {
            if (!this.animals.ContainsKey(name))
            {
                throw new ArgumentException($"ArgumentException: Animal {name} does not exist" );
            }

            return this.Animals[name];
        }
    }
}
