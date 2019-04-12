namespace DungeonsAndCodeWizards.Models.Interfaces
{
    using DungeonsAndCodeWizards.Models.Characters;
    public interface IItem
    {
        int Weight { get; }
        void AffectCharacter(Character character);
    }
}
