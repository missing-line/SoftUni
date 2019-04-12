namespace LoggerLibrary.Appenders.Factory.Contracts
{
    using LoggerLibrary.Layouts.Contracts;
    public interface ILayoutFactory
    {
        ILayout Create(string type);
    }
}
