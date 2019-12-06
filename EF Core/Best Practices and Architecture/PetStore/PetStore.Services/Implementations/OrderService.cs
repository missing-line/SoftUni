namespace PetStore.Services.Implementations
{
    using PetStore.Data;
    using PetStore.Models.Enums;

    public class OrderService : IOrderService
    {
        private PetStoreDbContext data;

        public OrderService(PetStoreDbContext data)
            => this.data = data;

        public void CompleteOrder(int orderId)
        {
            var order = this.data.Orders.Find(orderId);

            order.Status = Status.Done;

            this.data.SaveChanges();
        }
    }
}
