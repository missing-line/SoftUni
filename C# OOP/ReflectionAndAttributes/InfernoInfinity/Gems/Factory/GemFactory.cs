namespace InfernoInfinity.Gems
{
    using InfernoInfinity.Core.Factories;
    using InfernoInfinity.Gems.Factory;
    using InfernoInfinity.Interfaces;
    using System;

    public class GemFactory : IGemFactory
    {
        public IGem CreateGem(string manner,string type)
        {
            Manner currManner = Enum.Parse<Manner>(manner);

            Type classType = Type.GetType($"InfernoInfinity.Gems.{type}");

            IGem instance = (IGem)Activator.CreateInstance(classType, new object[] { currManner });

            return instance;
        }
    }
}
