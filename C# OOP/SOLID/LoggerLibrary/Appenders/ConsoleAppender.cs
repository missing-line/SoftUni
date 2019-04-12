namespace LoggerLibrary.Appenders
{
    using LoggerLibrary.Enum;
    using LoggerLibrary.Layouts.Contracts;
    using System;
    public class ConsoleAppender : Appender
    {

        public ConsoleAppender(ILayout layout)
            : base(layout)
        {
        }

        public override void Append(string dateTime, ReportLevel reportLevel, string msg)
        {
            if (reportLevel >= this.ReportLevel)
            {
                this.MsgCount++;
                Console.WriteLine(string.Format(this.Layout.Format, dateTime, reportLevel, msg));

            }
        }

        public override string ToString()
        {
            return base.ToString();
        }
    }
}
