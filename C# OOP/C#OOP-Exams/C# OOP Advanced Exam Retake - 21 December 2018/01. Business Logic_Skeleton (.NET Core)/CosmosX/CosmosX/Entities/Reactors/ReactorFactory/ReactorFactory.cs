using CosmosX.Entities.Containers.Contracts;
using CosmosX.Entities.Reactors.Contracts;
using CosmosX.Entities.Reactors.ReactorFactory.Contracts;
using System;
using System.Linq;
using System.Reflection;

namespace CosmosX.Entities.Reactors.ReactorFactory
{
    public class ReactorFactory : IReactorFactory
    {
        //TODO 
        public IReactor CreateReactor(string reactorTypeName, int id, IContainer moduleContainer, int additionalParameter)
        {
            //string reactorName = $"{reactorTypeName}" + "Reactor";

            Type reactorType =
                Assembly
                    .GetCallingAssembly()
                    .GetTypes()
                    .FirstOrDefault(t => t.Name.Contains(reactorTypeName));

            var instance = Activator
                .CreateInstance(reactorType, new object[] { id, moduleContainer, additionalParameter });

            return (IReactor)instance;
        }
    }
}
