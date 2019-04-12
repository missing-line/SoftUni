using InfernoInfinity.Core.Factories;
using InfernoInfinity.Interfaces;

namespace InfernoInfinity.Gems.Factory
{
    public interface IGemFactory
    {
        IGem CreateGem(string manner, string type);
    }
}
