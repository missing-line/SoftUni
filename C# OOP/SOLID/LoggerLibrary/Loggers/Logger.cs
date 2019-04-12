namespace LoggerLibrary.Loggers
{
    using LoggerLibrary.Appenders.Contracts;
    using LoggerLibrary.Enum;
    using LoggerLibrary.Loggers.Contracts;
    class Logger : ILogger
    {
        private readonly IAppender consoleAppender;
        private readonly IAppender fileAppender;

        public Logger(IAppender consoleAppender, IAppender fileAppender)
            : this(consoleAppender)
        {
            this.fileAppender = fileAppender;
        }

        public Logger(IAppender consoleAppender)
        {
            this.consoleAppender = consoleAppender;
        }

        public void Error(string dateTime, string errorMsg)
        {
            this.AppendMessage(dateTime, ReportLevel.ERROR, errorMsg);

        }

        public void Info(string dateTime, string infoMsg)
        {
            this.AppendMessage(dateTime, ReportLevel.INFO, infoMsg);          
        }

        public void Fatal(string dateTime, string fatalMsg)
        {
            this.AppendMessage(dateTime, ReportLevel.FATAL, fatalMsg);        
        }

        public void Critical(string dateTime, string criticalMsg)
        {
            this.AppendMessage(dateTime, ReportLevel.CRITICAL, criticalMsg);           
        }
        public void Warning(string dateTime, string warningMsg)
        {
            this.AppendMessage(dateTime, ReportLevel.WARNING, warningMsg);
        }
        private void AppendMessage(string dateTime, ReportLevel reportLevel, string msg)
        {
            this.fileAppender?.Append(dateTime, reportLevel, msg);
            this.consoleAppender?.Append(dateTime, reportLevel, msg);
        }
    }
}
