namespace InfernoInfinity.Weapons
{
    using System.Collections.Generic;
    using InfernoInfinity.Interface;
    using InfernoInfinity.Interfaces;
    using InfernoInfinity.Rarety;
    using System.Linq;

    public abstract class Weapon : IRare, IWeapon
    {
        protected Weapon(Rare rare, string name, int minDmg, int maxDmg, int slots)
        {
            this.Rare = (int)rare;
            this.Name = name;
            this.MinDmg = minDmg;
            this.MaxDmg = maxDmg;
            this.Slots = new List<IGem>(slots);

            for (int i = 0; i < slots; i++)
            {
                this.Slots.Add(null);
            }
        }
        public int Rare { get; protected set; }

        public string Name { get; protected set; }

        public int MinDmg { get; protected set; }


        public int MaxDmg { get; protected set; }

        public List<IGem> Slots { get; protected set; }

        public int GetMaxDmg()
        {
            return this.MaxDmg * this.Rare + this.Slots
              .Where(g => g != null)
              .Sum(g => g.Strength * 3 + g.Agility * 4);
        }

        public int GetMinDmg()
        {
            return this.MinDmg * this.Rare + this.Slots
                .Where(g => g != null)
                .Sum(g => g.Strength * 2 + g.Agility);
        }

        public override string ToString()
        {


            return $"{this.Name}: {GetMinDmg()}-{GetMaxDmg()} Damage, " +
                $"+{this.Slots.Where(x => x != null).Sum(x => x.Strength)} Strength, +{this.Slots.Where(x => x != null).Sum(x => x.Agility)} Agility, +{this.Slots.Where(x => x != null).Sum(x => x.Vitality)} Vitality";
        }
    }
}
