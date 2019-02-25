namespace RawData
{
    public class CarInfo
    {
        private double speed;
        private double power;

        public CarInfo(double speed, double power)
        {
            this.Speed = speed;
            this.Power = power;
        }

        public double Speed { get { return this.speed; } set { this.speed = value; } }

        public double Power { get { return this.power; } set { this.power = value; } }

    }
}
