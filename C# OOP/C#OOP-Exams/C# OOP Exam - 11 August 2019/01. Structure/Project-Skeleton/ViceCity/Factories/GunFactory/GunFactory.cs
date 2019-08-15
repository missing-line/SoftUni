namespace ViceCity.Factories.GunFactory
{
    using System;
    using System.Linq;
    using System.Reflection;
    using ViceCity.Models.Guns.Contracts;

    public class GunFactory : IGunFactory
    {
        public IGun CreateGun(string type, string name)
        {
            var typeClass =
                Assembly
                .GetCallingAssembly()
                .GetTypes()
                .Where(x => x.Name == type)
                .FirstOrDefault();

            if (typeClass == null)
            {
                throw new ArgumentException("Invalid gun type!");
            }

            var instance = (IGun)Activator.CreateInstance(typeClass, new object[] { name });

            return instance;
        }
    }
}
