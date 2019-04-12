namespace SoftUniRestaurant
{
    using SoftUniRestaurant.Core;
    using System;
    using System.Linq;

    public class StartUp
    {
        public static void Main()
        {
            RestaurantController restaurantController = new RestaurantController();

            string input;

            while ((input = Console.ReadLine()) != "END")
            {
                

                string[] array = input
                    .Split()
                    .ToArray();

                try
                {
                    CommandType(array, restaurantController);
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                }
            }
            Console.WriteLine(restaurantController.GetSummary());
        }
        private static void CommandType(string[] array, RestaurantController restaurantController)
        {

            string commandType = array[0];
            string name = "";
            string type = "";
            int tableNumber = 0;         

            switch (commandType)
            {
                case "AddFood":
                    type = array[1];
                    name = array[2];
                    decimal price = decimal.Parse(array[3]);
                    Console.WriteLine(restaurantController.AddFood(type, name, price));
                    break;
                case "AddDrink":
                    type = array[1];
                    name = array[2];
                    int servingSize = int.Parse(array[3]);
                    string brand = array[4];
                    Console.WriteLine(restaurantController.AddDrink(type, name, servingSize, brand));
                    break;
                case "AddTable":
                    type = array[1];
                    tableNumber = int.Parse(array[2]);
                    int capacity = int.Parse(array[3]);
                    Console.WriteLine(restaurantController.AddTable(type, tableNumber, capacity));
                    break;
                case "ReserveTable":
                    int numberOfPeople = int.Parse(array[1]);
                    Console.WriteLine(restaurantController.ReserveTable(numberOfPeople));
                    break;
                case "OrderFood":
                    tableNumber = int.Parse(array[1]);
                    string foodName = array[2];
                    Console.WriteLine(restaurantController.OrderFood(tableNumber, foodName));
                    break;
                case "OrderDrink":
                    tableNumber = int.Parse(array[1]);
                    string drinkName = array[2];
                    string drinkBrand = array[3];
                    Console.WriteLine(restaurantController.OrderDrink(tableNumber, drinkName, drinkBrand));
                    break;
                case "LeaveTable":
                    tableNumber = int.Parse(array[1]);
                    Console.WriteLine(restaurantController.LeaveTable(tableNumber));
                    break;
                case "GetFreeTablesInfo":
                    Console.WriteLine(restaurantController.GetFreeTablesInfo());
                    break;
                case "GetOccupiedTablesInfo":
                    Console.WriteLine(restaurantController.GetOccupiedTablesInfo());
                    break;
            }
        }
    }
}
