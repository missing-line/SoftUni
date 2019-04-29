namespace FightingArena
{
    using System;
    public class Gladiator
    {
        //Name: string
        //Stat: Stat
        //Weapon: Weapon

        private Weapon weapon;
        private Stat stat;
        private string name;

        public Gladiator(string name, Stat stat, Weapon weapon)
        {
            this.Name = name;
            this.Stat = stat;
            this.Weapon = weapon;
        }

        public string Name
        {
            get { return name; }
            private set { name = value; }
        }

        public Stat Stat
        {
            get { return stat; }
            set { stat = value; }
        }

        public Weapon Weapon
        {
            get { return weapon; }
            set { weapon = value; }
        }

        public int GetTotalPower()
        {
            return GetStatPower() + GetWeaponPower();
        }
            
        public int GetWeaponPower()
        {
            return this.Weapon.Sharpness + this.Weapon.Size + this.Weapon.Solidity;
        }

        public int GetStatPower()
        {
            return this.Stat.Agility + this.Stat.Flexibility + this.Stat.Intelligence + this.Stat.Skills+ this.Stat.Strength;
        }


        public override string ToString()
        {
            return $"{this.Name} - {GetTotalPower()}" + Environment.NewLine +
                   $"  Weapon Power:{GetWeaponPower()}" + Environment.NewLine +
                   $"  Stat Power: {GetStatPower()}";

        }
    }
}
