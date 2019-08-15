namespace ViceCity.Models.Guns
{
    using System;
    public class Pistol : Gun
    {
        public Pistol(string name) 
            : base(name, 10, 100)
        {
        }

        public override int Fire()
        {
            this.BulletsPerBarrel--;
            if (this.BulletsPerBarrel == 0)
            {
                this.BulletsPerBarrel = 10;
                this.TotalBullets -= 10;
            }

            return 1;
        }
    }
}
