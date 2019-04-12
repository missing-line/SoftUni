namespace SoftUniRestaurant.Models.Tables.Factory
{
    using SoftUniRestaurant.Models.Tables.Contracts;
    using System;
    public  class TableFactory
    {
        public ITable CreateTable(string type, int tableNumber, int capacity)
        {
            switch (type)
            {
                case "Inside":
                    return new InsideTable(tableNumber, capacity);
                case "Outside":
                    return new OutsideTable(tableNumber, capacity);
                default:
                    throw new ArgumentException("Invalid type!");
            }
        }
    }
}
