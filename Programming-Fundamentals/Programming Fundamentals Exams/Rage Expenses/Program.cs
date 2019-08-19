using System;

namespace Rage_Expenses
{
    class Program
    {
        static void Main(string[] args)
        {
            double games = double.Parse(Console.ReadLine());
            double headset = double.Parse(Console.ReadLine());
            double mouse = double.Parse(Console.ReadLine());
            double keyboard = double.Parse(Console.ReadLine());
            double diplay = double.Parse(Console.ReadLine());           
            int countHeadset = 0;
            int countMouse = 0;
            int  countKeyboard = 0;

            double trashHead = 0;
            double trashMouse = 0;
            double trashKeyboard = 0;
            double trashDisplay = 0;
            while (games != 0)
            {
                games--;
                countHeadset++;
                countMouse++;
                if (countHeadset == 2)
                {
                    trashHead++;                    
                }
                if (countMouse == 3)
                {
                    trashMouse++;
                }
                if (countHeadset == 2 && countMouse == 3)
                {
                    trashKeyboard++;
                    countKeyboard++;
                    if (countKeyboard == 2)
                    {
                        trashDisplay++;
                        countKeyboard = 0;
                    }
                }
                if (countHeadset == 2)
                {
                    countHeadset = 0;
                }
                if (countMouse == 3)
                {
                    countMouse = 0;
                }

            }
            double expenses = trashHead * headset + trashMouse * mouse + trashKeyboard * keyboard + trashDisplay * diplay;
            Console.WriteLine($"Rage expenses: {expenses:f2} lv.");
            
        }
    }
}
