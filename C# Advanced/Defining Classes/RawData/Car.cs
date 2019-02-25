namespace RawData
{
    using System.Collections.Generic;
    public class Car
    {
        private string model;
        private CarInfo carInfo;
        private CargoInfo cargoInfo;
        private Tyres tyres;


        public Car(string model, CarInfo carInfo, CargoInfo cargoInfo, Tyres tyres)
        {
            this.Model = model;
            this.CarInfo = carInfo;
            this.CargoInfo = cargoInfo;
            this.Tyres = tyres;
        }

        public string Model
        {
            get { return this.model; }
            set { this.model = value; }
        }

        public CarInfo CarInfo { get { return this.carInfo; } set { this.carInfo = value; } }
        public CargoInfo CargoInfo { get { return this.cargoInfo; } set { this.cargoInfo = value; } }
        public Tyres Tyres { get { return this.tyres; } set { this.tyres = value; } }


    }
}