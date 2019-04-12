namespace DungeonsAndCodeWizards.Models.Interfaces
{
    using DungeonsAndCodeWizards.Models.Bags;
    using DungeonsAndCodeWizards.Models.Characters;
    using DungeonsAndCodeWizards.Models.Enums;

    public interface ICharacter
    {
        string Name { get; }
        double BaseHealth { get; }
        double Health { get; }
        double BaseArmor { get; }
        double Armor { get; }
        double AbilityPoints { get; }
        Bag Bag { get; }   
        Faction Faction { get; }
        bool IsAlive { get; }
        double RestHealMultiplier { get; }   
        void TakeDamage(double hitPoints);
        void Rest();
        void UseItem(Item item);
        void UseItemOn(Item item, Character character);
        void GiveCharacterItem(Item item, Character character);
        void ReceiveItem(Item item);

    }
}

