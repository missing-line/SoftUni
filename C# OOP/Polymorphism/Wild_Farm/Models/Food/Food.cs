namespace Wild_Farm.Models.Food
{
    using Wild_Farm.Models.Contracts;
    public abstract class Food : IFood
    {
        protected Food(int quantity)
        {
            this.Quantity = quantity;
        }

        public int Quantity { get; protected set; }
    }
}
