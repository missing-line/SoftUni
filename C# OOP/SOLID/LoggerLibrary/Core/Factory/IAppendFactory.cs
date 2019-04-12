namespace LoggerLibrary.Appenders.Factory
{
    using LoggerLibrary.Appenders.Contracts;
    using LoggerLibrary.Layouts.Contracts;

    public interface IAppendFactory
    {
        IAppender Create(string type, ILayout layout);
    }
}
