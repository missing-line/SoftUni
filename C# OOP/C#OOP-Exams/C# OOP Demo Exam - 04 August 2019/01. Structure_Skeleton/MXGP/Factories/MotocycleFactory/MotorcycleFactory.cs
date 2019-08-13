namespace MXGP.Factories.MotocycleFactory
{
    using MXGP.Models.Motorcycles.Contracts;
    using System.Linq;
    using System;
    using System.Reflection;

    public class MotorcycleFactory : IMotorcycleFactory
    {
        public IMotorcycle CreateMotorcycle(string type, string model, int power)
        {
            var typeClass =
                Assembly
                .GetCallingAssembly()
                .GetTypes()
                .Where(x => x.Name.StartsWith(type) && !x.IsAbstract)
                .FirstOrDefault();

            if (typeClass == null)
            {
                throw new ArgumentException("Invalid Motorcycle Type!");
            }

            IMotorcycle instance = null;

            try
            {
                 instance = (IMotorcycle)Activator
                            .CreateInstance(typeClass, new object[] { model, power });
            }
            catch (Exception e)
            {

                throw new ArgumentException(e.InnerException.Message);
            }

            
            return instance;
        }
    }
}
