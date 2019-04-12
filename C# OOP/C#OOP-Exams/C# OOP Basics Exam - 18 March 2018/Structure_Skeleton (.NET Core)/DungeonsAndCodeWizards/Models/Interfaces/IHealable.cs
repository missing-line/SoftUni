namespace DungeonsAndCodeWizards.Models.Interfaces
{
    using DungeonsAndCodeWizards.Models.Characters;
    public interface IHealable
    {
        void Heal(Character character);
    }
}
