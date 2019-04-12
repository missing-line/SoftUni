namespace SoftUniRestaurant.Models.Tables.Contracts
{
    using SoftUniRestaurant.Models.Drinks.Contracts;
    using SoftUniRestaurant.Models.Foods.Contracts;
    public interface ITable
    {
        
        int TableNumber { get; }

        int Capacity { get; }
        int NumberOfPeople { get; }

        decimal PricePerPerson { get; }

        bool IsReserved { get; }

        decimal Price { get; }

        string GetOccupiedTableInfo();

        string GetFreeTableInfo();

        void Clear();

        decimal GetBill();

        void OrderFood(IFood food);

        void OrderDrink(IDrink drink);

        void Reserve(int numberOfPeople);

    }
}
