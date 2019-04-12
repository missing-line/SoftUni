namespace InfernoInfinity.Interfaces
{
    using InfernoInfinity.Interface;

    public interface IWeaponFactory
    {
        IWeapon CreateWeapon(string rare, string type, string name);
    }
}
