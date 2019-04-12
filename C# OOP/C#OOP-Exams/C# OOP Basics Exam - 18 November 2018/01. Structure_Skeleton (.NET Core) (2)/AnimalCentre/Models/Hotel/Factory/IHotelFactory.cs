using AnimalCentre.Models.Contracts;
namespace AnimalCentre.Models.Hotel.Factory
{
    public interface IHotelFactory
    {
        void AddAnimal(IAnimal animal, IHotel hotel);
    }
}
