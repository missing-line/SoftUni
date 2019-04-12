namespace MilitaryElite
{
    using System.Collections.Generic;
    public interface IEngineer
    {
        IReadOnlyCollection<IRepairs> Repairs { get; }
    }
}
