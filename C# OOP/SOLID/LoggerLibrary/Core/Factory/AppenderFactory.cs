namespace LoggerLibrary.Appenders.Factory
{
    using System;
    using LoggerLibrary.Appenders.Contracts;
    using LoggerLibrary.Layouts.Contracts;
    using LoggerLibrary.Loggers;

    public class AppenderFactory : IAppendFactory
    {
        public IAppender Create(string type, ILayout layout)
        {
            string typeLowerCase = type.ToLower();

            switch (typeLowerCase)
            {
                case "consoleappender":
                    return new ConsoleAppender(layout);
                    
                case "fileappender":
                    return new FileAppender(layout, new LogFile());                   
                default:
                    throw new ArgumentException("Invalid Appender Type!");
            }
        }     
    }
}
