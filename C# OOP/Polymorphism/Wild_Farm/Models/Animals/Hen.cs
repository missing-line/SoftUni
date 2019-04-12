namespace Wild_Farm.Models.Animals
{
    using Wild_Farm.Models.Contracts;
    public class Hen : Bird
    {
        private static double Increase = 0.35;
        public Hen(string name, double weight, double wingSize)
            : base(name, weight)
        {
            this.WingSize = wingSize;
        }

        public override void Eating(IFood food)
        {
            this.Weight += food.Quantity * Increase;

            this.FoodEaten += food.Quantity;
        }

        public override string Sound()
        {
            return "Cluck";
        }

        public override string ToString()
        {
            return base.ToString();
        }
    }
}
