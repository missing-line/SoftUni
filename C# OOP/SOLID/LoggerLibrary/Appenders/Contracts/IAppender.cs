namespace LoggerLibrary.Appenders.Contracts
{
    using LoggerLibrary.Enum;
    public interface IAppender
    {
        void Append(string dateTime, ReportLevel reportLevel, string msg);
        ReportLevel ReportLevel { get; set; }

        int MsgCount { get; }
    }
}
