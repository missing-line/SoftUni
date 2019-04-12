namespace AnimalCentre.Models.Hotel.Factory
{
    using AnimalCentre.Models.Contracts;
    public class HotelFactory : IHotelFactory
    {
        public void AddAnimal(IAnimal animal, IHotel hotel)
        {
            hotel.Accommodate(animal);
        }
    }
}
