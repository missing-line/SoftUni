namespace LoggerLibrary.Appenders
{
    using LoggerLibrary.Enum;
    using LoggerLibrary.Layouts.Contracts;
    using LoggerLibrary.Loggers;
    using LoggerLibrary.Loggers.Contracts;
    using System.IO;

    public class FileAppender : Appender
    {
        private const string path = "../../../log.txt";

        private readonly ILogFile logFile;

        public FileAppender(ILayout layout, LogFile file)
            :base(layout)
        {
           
            this.logFile = file;
        }
   
        public override void Append(string dateTime, ReportLevel reportLevel, string msg)
        {
            this.MsgCount++;
            string content = string.Format(this.Layout.Format, dateTime, reportLevel, msg + "\n");
            this.logFile.Write(content);
            File.AppendAllText(path, content);
        }

        public override string ToString()
        {
            return $"Appender type: {this.GetType().Name}" +
                $", Layout type: {this.Layout.GetType().Name}" +
                $", Report level: {this.ReportLevel.ToString().ToUpper()}" +
                $", Messages appended: {this.MsgCount},"+
                $"File size: {this.logFile.Size}";
        }
    }
}
