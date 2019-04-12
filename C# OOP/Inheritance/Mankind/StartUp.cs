namespace Mankind
{
    using System;
    using System.Linq;

    public  class StartUp
    {
        public static void Main(string[] args)
        {
            string[] firstLine = Console.ReadLine()
                .Split()
                .ToArray();

            string[] secondLine = Console.ReadLine()
                .Split()
                .ToArray();

            try
            {
                string studentFirstName = firstLine[0];
                string studentSecondName = firstLine[1];
                string facNumber = firstLine[2];

                Student student = new Student(studentFirstName,studentSecondName, facNumber);

                string workerFirstName = secondLine[0];
                string workerSecondName = secondLine[1];
                decimal workerSalary = decimal.Parse(secondLine[2]);
                decimal workerHoursPerDay = decimal.Parse(secondLine[3]);

                Worker worker = new Worker(workerFirstName,workerSecondName,workerSalary, workerHoursPerDay);

                Console.WriteLine(student);
                Console.WriteLine();             
                Console.WriteLine(worker);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }          
        }
    }
}
