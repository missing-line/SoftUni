namespace Travel.Entities.Factories
{
	using Contracts;
	using Items;
	using Items.Contracts;
    using System;
    using System.Linq;
    using System.Reflection;

    public class ItemFactory : IItemFactory
	{
		public IItem CreateItem(string type)
		{
            Type typeClass =
                Assembly
                .GetCallingAssembly()
                .GetTypes()
                .FirstOrDefault(x => x.Name == type);

            var instance = (IItem)Activator.CreateInstance(typeClass);

            return instance;
        }
	}
}
