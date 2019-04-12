namespace DungeonsAndCodeWizards.Models.SpecialClass.Factory
{
    using System;
    using System.Collections.Generic;
    using System.Text;
    using DungeonsAndCodeWizards.Models.Characters;
    using DungeonsAndCodeWizards.Models.Interfaces;

    public class AttackFactory : IAttackFactory
    {
        public string AttackCommand(Character attacker, Character receiver, IList<Character> characters)
        {
            StringBuilder sb = new StringBuilder();

            if (!(attacker is IAttackable))
            {
                throw new ArgumentException($"{attacker.Name} cannot attack!");
            }            

            ((IAttackable)attacker).Attack(receiver);

            sb.AppendLine($"{attacker.Name} attacks {receiver.Name} for {attacker.AbilityPoints} hit points! {receiver.Name} has {receiver.Health}/{receiver.BaseHealth} HP and {receiver.Armor}/{receiver.BaseArmor} AP left!");
            if (receiver.IsAlive == false)
            {
                sb.AppendLine($"{receiver.Name} is dead!");
            }

            return sb.ToString().TrimEnd();
        }
    }
}
