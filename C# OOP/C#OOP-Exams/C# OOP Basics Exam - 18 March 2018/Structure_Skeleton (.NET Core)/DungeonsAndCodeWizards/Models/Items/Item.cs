namespace DungeonsAndCodeWizards.Models
{
    using DungeonsAndCodeWizards.Models.Characters;
    using DungeonsAndCodeWizards.Models.Interfaces;
    using System;

    public abstract class Item : IItem
    {
        private int weight;        

        protected Item(int weight)
        {
            this.Weight = weight;
        }

        public int Weight
        {
            get => this.weight;
            private set => this.weight = value;
        }

        public virtual void AffectCharacter(Character character)
        {
            if (!character.IsAlive)
            {
                throw new InvalidOperationException("Must be alive to perform this action!");
            }
        }
    }
}
