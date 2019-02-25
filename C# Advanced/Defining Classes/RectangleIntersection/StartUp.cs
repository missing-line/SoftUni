namespace RectangleIntersection
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public class StartUp
    {
        public static void Main(string[] args)
        {
            int[] arr = Console.ReadLine()
                .Split()
                .Select(int.Parse)
                .ToArray();

            List<Rectangle> rectangles = new List<Rectangle>();

            for (int i = 0; i < arr[0]; i++)
            {
                string[] rectangle = Console.ReadLine().Split().ToArray();

                string id = rectangle[0];
                double wight = double.Parse(rectangle[1]);
                double height = double.Parse(rectangle[2]);
                double x = double.Parse(rectangle[3]);
                double y = double.Parse(rectangle[4]);

                rectangles.Add(new Rectangle(id, wight, height, x, y));
            }

            for (int i = 0; i < arr[1]; i++)
            {
                var tokens = Console.ReadLine().Split();

                Rectangle rectangle1 = rectangles.First(r => r.Id == tokens[0]);
                Rectangle rectangle2 = rectangles.First(r => r.Id == tokens[1]);

                if (rectangle1.Intersects(rectangle2))
                {
                    Console.WriteLine("true");
                }
                else
                {
                    Console.WriteLine("false");
                }
            }
        }
    }
}
