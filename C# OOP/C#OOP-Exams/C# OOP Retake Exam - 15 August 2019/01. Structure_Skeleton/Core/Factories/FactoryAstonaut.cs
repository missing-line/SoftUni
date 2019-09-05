namespace SpaceStation.Core.Factories
{
    using SpaceStation.Core.Factories.Contracts;
    using SpaceStation.Models.Astronauts.Contracts;
    using System;
    using System.Linq;
    using System.Reflection;

    public class FactoryAstonaut : IFactoryAstonaut
    {
        public IAstronaut Create(string type, string name)
        {
            var typeClass = 
                Assembly
                .GetCallingAssembly()
                .GetTypes()
                .FirstOrDefault(x => x.Name == type);

            if (typeClass == null)
            {
                throw new InvalidOperationException("Astronaut type doesn't exists!");
            }

            var instance = (IAstronaut)Activator.CreateInstance(typeClass, new object[] { name });

            return instance;
        }
    }
}
