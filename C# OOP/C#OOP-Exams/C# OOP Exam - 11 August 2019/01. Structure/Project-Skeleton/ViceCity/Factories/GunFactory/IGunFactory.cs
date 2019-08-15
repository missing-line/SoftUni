namespace ViceCity.Factories.GunFactory
{
    using ViceCity.Models.Guns.Contracts;
    public interface IGunFactory
    {
        IGun CreateGun(string type, string name);
    }
}
