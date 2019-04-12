namespace LoggerLibrary.Loggers.Contracts
{
    public interface ILogFile
    {
        void Write(string msg);
        int Size { get; }
    }
}
