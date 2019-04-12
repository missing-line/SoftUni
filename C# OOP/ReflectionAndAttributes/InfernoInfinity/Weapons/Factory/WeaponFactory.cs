namespace InfernoInfinity.Weapons.Factory
{
    using InfernoInfinity.Interface;
    using InfernoInfinity.Interfaces;
    using InfernoInfinity.Rarety;
    using System;

    public class WeaponFactory : IWeaponFactory
    {
        public IWeapon CreateWeapon(string rare, string type, string name)
        {
            var rareType = Enum.Parse<Rare>(rare); 

            Type classType = Type.GetType($"InfernoInfinity.Weapons.{type}");

            IWeapon instance = (IWeapon)Activator.CreateInstance(classType, new object[] { rareType, name });

            return instance;
        }
    }
}
