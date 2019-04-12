namespace LoggerLibrary.Layouts
{
    using LoggerLibrary.Layouts.Contracts;
    public class SimpleLayout : ILayout
    {
        public string Format => "{0} - {1} - {2}";
    }
}
