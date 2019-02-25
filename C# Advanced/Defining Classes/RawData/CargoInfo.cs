namespace RawData
{
    public class CargoInfo
    {
        private double cargo;
        private string type;

        public CargoInfo(double cargo,string type)
        {
            this.Cargo = cargo;
            this.Type = type;
        }
        public double Cargo
        {
            get { return this.cargo; }
            set { this.cargo = value; }
        }
        public string Type
        {
            get { return this.type; }
            set { this.type = value; }
        }
    }
}
