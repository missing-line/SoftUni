namespace LoggerLibrary.Appenders
{
    using LoggerLibrary.Appenders.Contracts;
    using LoggerLibrary.Enum;
    using LoggerLibrary.Layouts.Contracts;
    public abstract class Appender : IAppender
    {
        private readonly ILayout layout;

        protected Appender(ILayout layout)
        {
            this.layout = layout;
        }

        protected ILayout Layout => this.layout;

        public ReportLevel ReportLevel { get; set; }

        public  int MsgCount { get; protected set; }

        public abstract void Append(string dateTime, ReportLevel reportLevel, string msg);


        public override string ToString()
        {
            return $"Appender type: {this.GetType().Name}" +
               $", Layout type: {this.Layout.GetType().Name}" +
               $", Report level: {this.ReportLevel.ToString().ToUpper()}" +
               $", Messages appended: {this.MsgCount}";
        }
    }
}
