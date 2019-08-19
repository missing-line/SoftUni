using System;

namespace Padawan_Equipment
{
    class Program
    {
        static void Main(string[] args)
        {
            double money = double.Parse(Console.ReadLine());
            double studnets = double.Parse(Console.ReadLine());
            double sabre = double.Parse(Console.ReadLine());
            double robe = double.Parse(Console.ReadLine());
            double belt = double.Parse(Console.ReadLine());
            double student = studnets;
            double percent = Math.Ceiling(studnets + (studnets * 0.1));
            int count = 0;
            int free = 0;
            while (studnets != 0)
            {
                count++;
                if (count == 6)
                {
                    free++;
                    count = 0;
                }
                studnets--;
            }
            
            double result = sabre * percent + robe * student + belt*(student - free);
            if (result <= money)
            {
                Console.WriteLine($"The money is enough - it would cost {result:f2}lv.");
            }
            else
            {
                Console.WriteLine($"Ivan Cho will need {Math.Abs(money - result):f2}lv more.");
            }
        }
    }
}
