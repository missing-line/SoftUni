namespace FestivalManager.Entities.Factories
{
    using Contracts;
    using Entities.Contracts;
    using System;
    using System.Linq;
    using System.Reflection;

    public class SetFactory : ISetFactory
	{
		public ISet CreateSet(string name, string type)
		{
            Type typeClass =
                Assembly.
                GetCallingAssembly()
                .GetTypes()
                .FirstOrDefault(x => x.Name == type);


            var instance = Activator.CreateInstance(typeClass, new object[] { name });

            return (ISet)instance;
		}
	}
}
