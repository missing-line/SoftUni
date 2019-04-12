namespace InfernoInfinity.Interfaces
{
    using InfernoInfinity.Interface;
    public interface IRepository
    {
        void AddGem(string name, int index, IGem gem);
        void CreateWeapon(IWeapon weapon);
        void RemoveGem(string name, int index);

        IWeapon GetInstance(string name);
    }
}
