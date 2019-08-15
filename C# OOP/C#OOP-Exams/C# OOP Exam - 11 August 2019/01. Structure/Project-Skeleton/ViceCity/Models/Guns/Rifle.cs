namespace ViceCity.Models.Guns
{
    public class Rifle : Gun
    {
        public Rifle(string name)
            : base(name, 50, 500)
        {
        }

        public override int Fire()
        {
            this.BulletsPerBarrel -= 5;
            if (this.BulletsPerBarrel == 0)
            {
                this.BulletsPerBarrel = 50;
                this.TotalBullets -= 50;
            }

            return 5;
        }
    }
}
