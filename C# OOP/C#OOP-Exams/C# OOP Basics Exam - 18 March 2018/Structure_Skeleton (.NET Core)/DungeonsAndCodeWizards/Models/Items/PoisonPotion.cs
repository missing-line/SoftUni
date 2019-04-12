namespace DungeonsAndCodeWizards.Models.Items
{
    using DungeonsAndCodeWizards.Models.Characters;
    using DungeonsAndCodeWizards.Models.Interfaces;
    using System;
    public class PoisonPotion : Item
    {
        public PoisonPotion() 
            : base(5)
        {
        }

        public override void AffectCharacter(Character character)
        {
            base.AffectCharacter(character);
            character.Health -= 20;
            if (character.Health <= 0)
            {
                character.IsAlive = false;
            }
        }
    }
}
