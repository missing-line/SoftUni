namespace RawData
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public class StartUp
    {
        public static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());

            List<Car> cars = new List<Car>();

            for (int i = 0; i < n; i++)
            {
                string[] input = Console.ReadLine().Split().ToArray();

                string model = input[0];
                double speed = double.Parse(input[1]);
                double power = double.Parse(input[2]);
                double cargo = double.Parse(input[3]);
                string type = input[4];

                double tire1Pressure = double.Parse(input[5]);
                double tyre1Age = double.Parse(input[6]);

                double tire2Pressure = double.Parse(input[7]);
                double tyre2Age = double.Parse(input[8]);

                double tire3Pressure = double.Parse(input[9]);
                double tyre3Age = double.Parse(input[10]);

                double tire4Pressure = double.Parse(input[11]);
                double tyre4Age = double.Parse(input[12]);

                Tyres tyres = new Tyres(tire1Pressure, tyre2Age, tire2Pressure, tyre2Age, tire3Pressure, tyre3Age, tire4Pressure, tyre4Age);

                CarInfo carInfo = new CarInfo(speed, power);

                CargoInfo cargoInfo = new CargoInfo(cargo, type);

                cars.Add(new Car(model, carInfo, cargoInfo, tyres));

            }
            string findTypeCargo = Console.ReadLine();
            if (findTypeCargo == "flamable")
            {
                List<Car> car = cars.Where(x => x.CargoInfo.Type == findTypeCargo && x.CarInfo.Power > 250).ToList();

                foreach (var i in car)
                {
                    Console.WriteLine($"{i.Model}");
                }
            }
            else
            {
                List<Car> car = cars.Where(x => x.CargoInfo.Type == "fragile" &&  x.Tyres.Tire1Pressure < 1 ||
                x.Tyres.Tire2Pressure < 1 || x.Tyres.Tire3Pressure < 1 || x.Tyres.Tire4Pressure < 1 ).ToList();
                foreach (var i in car)
                {
                    Console.WriteLine($"{i.Model}");
                }
            }

        }
    }
}
