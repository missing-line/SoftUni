using DungeonsAndCodeWizards.Models.Characters;
namespace DungeonsAndCodeWizards.Models.SpecialClass.Factory
{
    using System.Collections.Generic;
    public interface IHealFactory
    {
        string HealCommand(Character heal, Character receiver, List<Character> characters);
    }
}
