namespace MXGP.Factories.MotocycleFactory
{
    using MXGP.Models.Motorcycles.Contracts;

    public interface IMotorcycleFactory
    {
        IMotorcycle CreateMotorcycle(string type, string model, int power);
    }
}