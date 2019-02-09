namespace Encrypt__Sort_and_Print_Array
{
    using System;
    public class Program
    {
        public static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            int[] names = new int[n];
            
            for (int i = 0; i < n; i++)
            {
                int sum = 0;
                string name = Console.ReadLine();
                for (int i1 = 0; i1 < name.Length; i1++)
                {
                    if (name[i1] == 'a' || name[i1] == 'e' || name[i1] == 'o' ||
                       name[i1] == 'u' || name[i1] == 'i' ||
                       name[i1] == 'A' || name[i1] == 'E' || name[i1] == 'O' ||
                       name[i1] == 'U' || name[i1] == 'I')
                    {
                        int curr = (int)name[i1];
                        sum += curr * name.Length;
                    }
                    else
                    {
                        int curr = (int)name[i1];
                        sum += curr / name.Length;
                    }                                    
                }
                names[i] = sum;
            }
            Array.Sort(names);
            foreach (var values in names)
            {
                Console.WriteLine(values);
            }
        }
    }
}
