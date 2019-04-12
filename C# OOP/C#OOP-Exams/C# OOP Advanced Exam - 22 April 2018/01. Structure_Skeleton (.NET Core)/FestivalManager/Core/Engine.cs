namespace FestivalManager.Core
{
    using System.Reflection;
    using Contracts;
    using Controllers;
    using Controllers.Contracts;
    using IO.Contracts;

    using System;
    using System.Linq;

    class Engine : IEngine
    {
        private readonly IReader reader;
        private readonly IWriter writer;

        private readonly IFestivalController festivalCоntroller;
        private readonly ISetController setCоntroller;

        public Engine(IFestivalController festivalController, ISetController setController)
        {
            this.reader = new ReadController();
            this.writer = new WriteController();
            this.festivalCоntroller = festivalController;
            this.setCоntroller = setController;
        }

        public void Run()
        {
            while (true)
            {
                var input = this.reader.ReadLine();

                if (input == "END")
                    break;

                try
                {
                    var result = ProcessCommand(input);
                    this.writer.Write(result);
                }
                catch (Exception ex)
                {
                    this.writer.Write("ERROR: " + ex.Message);
                }
            }

            string end = this.festivalCоntroller.ProduceReport();

            this.writer.Write("Results:");
            this.writer.Write(end);
        }

        public string ProcessCommand(string input)
        {
            string[] data = input.Split(' ');

            string command = data[0];

            string[] tokens = data.Skip(1).ToArray();

            if (command == "LetsRock")
            {
                string setovete = this.setCоntroller.PerformSets();
                return setovete;
            }

            MethodInfo commandMethod = this.festivalCоntroller.GetType()
                .GetMethods()
                .FirstOrDefault(mi => mi.Name == command);

            string output = string.Empty;
            try
            {
                output = (string)commandMethod
                    .Invoke(this.festivalCоntroller, new object[] { tokens });
            }
            catch (TargetInvocationException ex)
            {
                throw ex.InnerException;
            }

            return output;
        }
    }
}