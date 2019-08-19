using System;

namespace Thea_the_Photographer
{
    class Program
    {
        static void Main(string[] args)
        {
            double n = double.Parse(Console.ReadLine());
            double ft = double.Parse(Console.ReadLine());
            double ff = double.Parse(Console.ReadLine());
            double ut = double.Parse(Console.ReadLine());

            var filtered = Math.Ceiling(n * (ff / 100));
            var nTF = n * ft;
            var upload = filtered * ut;
            var sum = nTF + upload;
          
            TimeSpan time = TimeSpan.FromSeconds(sum);

            string str = time.ToString(@"d\:hh\:mm\:ss");

            Console.WriteLine(str);
        }
    }
}
