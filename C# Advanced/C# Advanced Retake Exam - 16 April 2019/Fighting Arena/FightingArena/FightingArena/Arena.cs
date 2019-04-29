namespace FightingArena
{
    using System.Collections.Generic;
    using System.Linq;

    public class Arena
    {
        private string name;
        private List<Gladiator> gladiators;

        public Arena(string name)
        {
            this.Name = name;
            this.gladiators = new List<Gladiator>();
        }

        public string Name
        {
            get { return name; }
            private set { name = value; }
        }

        public void Add(Gladiator gladiator)
        {
            if (this.gladiators.All(x => x.Name != gladiator.Name))
            {
                this.gladiators.Add(gladiator);
            }
        }

        public int Count => this.gladiators.Count;

        public void Remove(string name)
        {
            if (this.gladiators.Any(x => x.Name == name))
            {
                Gladiator gladiator = this.gladiators.FirstOrDefault(x => x.Name == name);

                this.gladiators.Remove(gladiator);
            }
        }

        public Gladiator GetGladitorWithHighestStatPower()
        {
            int max = this.gladiators.Max(x => x.GetStatPower());
            return this.gladiators.FirstOrDefault(x => x.GetStatPower() == max);
        }

        public Gladiator GetGladitorWithHighestWeaponPower()
        {
            int max = this.gladiators.Max(x => x.GetWeaponPower());
            return this.gladiators.FirstOrDefault(x => x.GetWeaponPower() == max);
        }

        public Gladiator GetGladitorWithHighestTotalPower()
        {
            int max = this.gladiators.Max(x => x.GetTotalPower());
            return this.gladiators.FirstOrDefault(x => x.GetTotalPower() == max);
        }

        public override string ToString()
        {
            return $"{this.Name} - {this.Count} gladiators are participating.";
        }
    }
}
