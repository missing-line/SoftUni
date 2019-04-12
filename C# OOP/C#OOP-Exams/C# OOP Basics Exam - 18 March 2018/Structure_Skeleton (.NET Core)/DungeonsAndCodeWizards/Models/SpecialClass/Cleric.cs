namespace DungeonsAndCodeWizards.Models.SpecialClass
{
    using DungeonsAndCodeWizards.Models.Bags;
    using DungeonsAndCodeWizards.Models.Characters;
    using DungeonsAndCodeWizards.Models.Enums;
    using DungeonsAndCodeWizards.Models.Interfaces;
    using System;
    public class Cleric : Character, IHealable
    {
        public Cleric(string name, Faction faction)
             : base(name, 50, 25, 40, new Backpack(), faction)
        {

        }

        public override double RestHealMultiplier => 0.5;

        public void Heal(Character character)
        {
            if (!this.IsAlive || !character.IsAlive)
            {
                throw new InvalidOperationException("Must be alive to perform this action!");
            }
            if (this.Faction != character.Faction)
            {
                throw new InvalidOperationException("Cannot heal enemy character!");
            }

            character.Health += this.AbilityPoints;
        }

        public override string ToString()
        {
            return base.ToString();
        }
    }
}
