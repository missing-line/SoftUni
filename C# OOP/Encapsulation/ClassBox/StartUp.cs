namespace ClassBox
{
    using System;
    public class StartUp
    {
        public static void Main(string[] args)
        {
            try
            {
                double l = double.Parse(Console.ReadLine());
                double w = double.Parse(Console.ReadLine());
                double h = double.Parse(Console.ReadLine());

                Box box = new Box(h, w, l);

                Console.WriteLine("Surface Area - {0:F2}", box.GetSurfaceArea());
                Console.WriteLine("Lateral Surface Area - {0:F2}", box.GetLateralSurfaceArea());
                Console.WriteLine("Volume - {0:F2}", box.GetVolume());
            }
            catch (Exception ex)
            {

                Console.WriteLine(ex.Message);
            }
        }
    }
}
