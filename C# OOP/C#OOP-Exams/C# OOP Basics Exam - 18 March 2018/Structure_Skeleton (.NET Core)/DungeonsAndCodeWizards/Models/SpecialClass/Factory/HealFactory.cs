namespace DungeonsAndCodeWizards.Models.SpecialClass.Factory
{
    using System;
    using System.Collections.Generic;
    using System.Text;
    using DungeonsAndCodeWizards.Models.Characters;
    using DungeonsAndCodeWizards.Models.Interfaces;
    public class HealFactory : IHealFactory
    {
        public string HealCommand(Character healer, Character ch, List<Character> characters)
        {
            StringBuilder sb = new StringBuilder();

            if (!(healer is IHealable))
            {
                throw new ArgumentException($"{healer.Name} cannot heal!");
            }

            ((IHealable)healer).Heal(ch);

            sb.AppendLine($"{healer.Name} heals {ch.Name} for {healer.AbilityPoints}! {ch.Name} has {ch.Health} health now!");

            return sb.ToString().TrimEnd();
        }
    }
}
