namespace Travel.Entities.Factories
{
	using Contracts;
	using Airplanes.Contracts;
    using System;
    using System.Linq;
    using System.Reflection;

    public class AirplaneFactory : IAirplaneFactory
	{
		public IAirplane CreateAirplane(string type)
		{
            Type typeClass =
                Assembly
                .GetCallingAssembly()              
                .GetTypes()
                .FirstOrDefault(x =>x.Name == type);

            var instance = (IAirplane)Activator.CreateInstance(typeClass);

            return instance;
        }
	}
}