namespace FestivalManager.Entities.Factories
{
    using Contracts;
    using Entities.Contracts;
    using System;
    using System.Linq;
    using System.Reflection;

    public class InstrumentFactory : IInstrumentFactory
    {
        public IInstrument CreateInstrument(string type)
        {
            Type typeClass =
               Assembly.
               GetCallingAssembly()
               .GetTypes()
               .FirstOrDefault(x => x.Name == type);


            var instance = Activator.CreateInstance(typeClass);

            return (IInstrument)instance;
        }
    }
}