namespace InfernoInfinity.Interfaces
{
    using InfernoInfinity.Core.Factories;
    public interface IGem
    {
        int Manner { get; }
        int Strength { get; }
        int Agility { get; }
        int Vitality { get; }
    }
}
