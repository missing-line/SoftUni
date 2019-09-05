namespace SpaceStation.Core.Factories.Contracts
{
    using SpaceStation.Models.Astronauts.Contracts;

    public interface IFactoryAstonaut
    {
        IAstronaut Create(string type, string name);
    }
}
