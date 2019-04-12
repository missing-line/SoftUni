namespace InfernoInfinity.Gems
{
    using InfernoInfinity.Core.Factories;
    using InfernoInfinity.Interfaces;
    public abstract class Gem : IGem
    {
        protected Gem(Manner manner, int strength, int agility, int vitality)
        {
            this.Manner = (int)manner;
            this.Strength = strength + this.Manner;
            this.Agility = agility + this.Manner;
            this.Vitality = vitality + this.Manner;
        }

        public int Manner { get; }

        public int Strength { get; }

        public int Agility { get; }

        public int Vitality { get; }

    }
}
