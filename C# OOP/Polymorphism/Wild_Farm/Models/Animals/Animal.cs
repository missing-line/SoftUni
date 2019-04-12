namespace Wild_Farm.Models.Animals
{
    using Wild_Farm.Models.Contracts;
    public abstract class Animal : IAnimal
    {
        private string name;
        private double weight;
        private int foodEaten;

        protected Animal(string name, double weight)
        {
            this.Name = name;
            this.Weight = weight;
            this.FoodEaten = 0;
        }

        public string Name { get => name; protected set => name = value; }

        public double Weight { get => weight; protected set => weight = value; }

        public int FoodEaten { get => foodEaten; protected set => foodEaten = value; }

        public virtual void Eating(IFood food)
        {
            throw new System.NotImplementedException();
        }

        public virtual string Sound()
        {
            throw new System.NotImplementedException();
        }
    }
}
