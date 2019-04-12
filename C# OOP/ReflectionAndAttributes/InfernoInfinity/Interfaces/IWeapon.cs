namespace InfernoInfinity.Interface
{
    using InfernoInfinity.Interfaces;
    using System.Collections.Generic;
    public interface IWeapon
    {
        string Name { get; }
        int MinDmg { get; }
        int MaxDmg { get; }
        List<IGem> Slots { get; }

        int GetMinDmg();
        int GetMaxDmg();
    }
}
