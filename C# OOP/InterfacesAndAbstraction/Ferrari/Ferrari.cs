namespace Ferrari
{
    public class Ferrari : IFerrari
    {
        public Ferrari(string driverName)
        {
            this.Model = "488-Spider";
            this.DriverName = driverName;
        }

        public string DriverName { get; set; }
        public string Model { get; set; }
        public string PushTheGasPedal()
        {
            return $"Brakes!";
        }

        public string UseBrakes()
        {
            return $"Gas!";
        }

        public override string ToString()
        {
            return $"{this.Model}/{PushTheGasPedal()}/{UseBrakes()}/{this.DriverName}";
        }
    }
}
