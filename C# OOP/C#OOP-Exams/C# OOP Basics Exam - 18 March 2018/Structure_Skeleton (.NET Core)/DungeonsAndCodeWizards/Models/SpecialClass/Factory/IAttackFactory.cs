namespace DungeonsAndCodeWizards.Models.SpecialClass.Factory
{
    using DungeonsAndCodeWizards.Models.Characters;
    using System.Collections.Generic;

    public interface IAttackFactory
    {
        string AttackCommand(Character attacker, Character receiver, IList<Character> characters);
    }
}
