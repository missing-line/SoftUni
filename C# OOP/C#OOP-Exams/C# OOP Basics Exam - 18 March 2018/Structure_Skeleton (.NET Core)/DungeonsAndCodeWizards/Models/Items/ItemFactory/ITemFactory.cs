namespace DungeonsAndCodeWizards.Models.Items.ItemFactory
{
    using System;
    public class ItemFactory : IItemFactory
    {
        public Item CreateItem(string type)
        {
            switch (type)
            {
                case "ArmorRepairKit":
                    Item armorRepairKit = new ArmorRepairKit();
                    return armorRepairKit;
                case "HealthPotion":
                    Item healthPotion = new HealthPotion();
                    return healthPotion;
                case "PoisonPotion":
                    Item poisonPotion = new PoisonPotion();
                    return poisonPotion;
                default:
                    throw new ArgumentException($"Invalid item \"{type}\"!");
            }
        }
    }
}
