namespace LoggerLibrary.Appenders.Factory
{
    using LoggerLibrary.Appenders.Factory.Contracts;
    using LoggerLibrary.Layouts;
    using LoggerLibrary.Layouts.Contracts;
    using System;
    public class LayoutFactory : ILayoutFactory
    {
        public ILayout Create(string type)
        {
            string typeCaseLower = type.ToLower();

            switch (typeCaseLower)
            {
                case "simplelayout":
                    return new SimpleLayout();

                case "xmllayout":
                    return new XmlLayout();
                default:
                    throw new ArgumentException("Invalid layout type!");
            }
        }
    }
}
