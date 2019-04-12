namespace DungeonsAndCodeWizards.Models.Interfaces
{
    using DungeonsAndCodeWizards.Models.Characters;
    public interface IAttackable
    {
        void Attack(Character character);
    }
}
