namespace LoggerLibrary.Core
{
    using LoggerLibrary.Appenders.Contracts;
    using LoggerLibrary.Appenders.Factory;
    using LoggerLibrary.Appenders.Factory.Contracts;
    using LoggerLibrary.Core.Interface;
    using LoggerLibrary.Enum;
    using LoggerLibrary.Layouts.Contracts;
    using System;
    using System.Collections.Generic;

    public class CommandInterpreter : ICommandInterpreter
    {
        private ICollection<IAppender> appenders;
        private IAppendFactory appenderFactory;
        private ILayoutFactory layoutFactory;
        public CommandInterpreter()
        {
            this.appenders = new List<IAppender>();
            this.appenderFactory = new AppenderFactory();
            this.layoutFactory = new LayoutFactory();
        }
        public void AddAppender(string[] input)
        {
            string appendetType = input[0];
            string layoutType = input[1];

            ReportLevel reportLevel = ReportLevel.INFO;

            if (input.Length == 3)
            {
                reportLevel = Enum.Parse<ReportLevel>(input[2]);
            }
            ILayout layout = this.layoutFactory.Create(layoutType);
            IAppender appender = this.appenderFactory.Create(appendetType, layout);
            appender.ReportLevel = reportLevel;
            this.appenders.Add(appender);
        }

        public void AddMessages(string[] message)
        {
            ReportLevel reportLevel = Enum.Parse<ReportLevel>(message[0]);
            string dateTime = message[1];
            string msg = message[2];

            foreach (var appender in appenders)
            {
                appender.Append(dateTime,reportLevel, msg);
            }
        }

        public void PrintInfo()
        {
            Console.WriteLine("Logger Info:");

            foreach (var app in appenders)
            {
                Console.WriteLine(app);
            }
        }
    }
}
