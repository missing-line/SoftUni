namespace LoggerLibrary.Core.Interface
{
    public interface ICommandInterpreter
    {
        void AddAppender(string[] input);

        void AddMessages(string[] message);

        void PrintInfo();
    }
}
