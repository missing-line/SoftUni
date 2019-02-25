namespace Tuple
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public class StartUp
    {
        public static void Main(string[] args)
        {
            List<Tuple<string, string, string>> box = new List<Tuple<string, string, string>>();

            string[] first = Console.ReadLine()
                .Split()
                .ToArray();

            string name = $"{first[0]} {first[1]}";
            string adrees = first[2];
            string city = first[3];

            Tuple<string, string, string> tupleFirst = new Tuple<string, string, string>(name, adrees, city);
            box.Add(tupleFirst);

            string[] second = Console.ReadLine()
                .Split()
                .ToArray();

            Tuple<string, string, string> tupleSecond = new Tuple<string, string, string>(second[0], second[1], second[2] == "drunk" ? "True" : "False");
            box.Add(tupleSecond);

            string[] th = Console.ReadLine()
                .Split()
                .ToArray();

            double value = double.Parse(th[1]);
            string output = $"{value:f1}";

            Tuple<string, string, string> tupleTh = new Tuple<string, string, string>(th[0], output, th[2]);
            box.Add(tupleTh);

            box.ForEach(x => Console.WriteLine(x));
        }
    }
}
