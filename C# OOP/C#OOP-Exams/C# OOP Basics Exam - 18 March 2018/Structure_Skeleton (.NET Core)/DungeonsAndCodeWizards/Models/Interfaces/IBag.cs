namespace DungeonsAndCodeWizards.Models.Interfaces
{
    using System.Collections.Generic;
    public interface IBag
    {
        int Capacity { get; }

        double Load { get; }

        IReadOnlyCollection<Item> Items { get; }

        void AddItem(Item item);
        Item GetItem(string name);

    }
}
