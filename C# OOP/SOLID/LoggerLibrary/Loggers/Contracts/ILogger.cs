namespace LoggerLibrary.Loggers.Contracts
{
    public interface ILogger
    {
        void Error(string dateTime, string errorMsg);
        void Info(string dateTime, string infoMsg);
        void Fatal(string dateTime, string fatalMsg);
        void Critical(string dateTime, string criticalMsg);
        void Warning(string dateTime, string warningMsg);

    }
}
