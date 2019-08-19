using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hogswatch
{
    class Program
    {
        static void Main(string[] args)
        {
            int homes = int.Parse(Console.ReadLine());
            int pres = int.Parse(Console.ReadLine());
            int bachHome = 0;
            int currPres = pres;
            int goHome = 0;
            int takeAgain = 0;
            for (int i = 1; i <= homes; i++)
            {
                int currHome = int.Parse(Console.ReadLine());
                if (currPres >= currHome)
                {
                    currPres -= currHome;
                }
                else if (currPres < currHome)
                {
                    goHome++;
                    bachHome = (pres / i) * (homes - i) + (currHome - currPres);
                    takeAgain += bachHome;
                    bachHome -= (currHome - currPres);
                    currPres = bachHome;
                }
            }
            if (goHome == 0 && takeAgain == 0)
            {
                Console.WriteLine(currPres);
            }
            else
            {
                Console.WriteLine(goHome);
                Console.WriteLine(takeAgain);
            }
        }
    }
}
