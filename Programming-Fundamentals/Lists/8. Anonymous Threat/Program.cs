namespace _8._Anonymous_Threat
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    public class Program
    {
        public static void Main(string[] args)
        {
            List<string> line = Console.ReadLine()
                .Split()
                .ToList();
            string[] command = Console.ReadLine()
                .Split();

            while (string.Join("", command) != "3:1")
            {
                if (command[0] == "merge")
                {
                    int start = int.Parse(command[1]);
                    int end = int.Parse(command[2]);
                    if (start >= 0 && end < line.Count)
                    {
                        Merge(line, start, end);
                    }
                    else if (start >= 0 && end >= line.Count && start < line.Count)
                    {
                        string merge = "";
                        int count = 0;
                        for (int i = start; i < line.Count; i++)
                        {
                            merge += line[i];
                            count++;
                        }
                        line.RemoveRange(start, count);
                        line.Insert(start, merge);
                    }
                    else if (start < 0 && end < line.Count && end > 0)
                    {
                        string merge = "";
                        int count = 0;
                        for (int i = 0; i <= end; i++)
                        {
                            merge += line[i];
                            count++;
                        }
                        line.RemoveRange(0, count);
                        line.Insert(0, merge);
                    }
                    else if (start < 0 && end >= line.Count)
                    {
                        string merge = "";
                        int count = 0;
                        for (int i = 0; i <= end; i++)
                        {
                            merge += line[i];
                            count++;
                        }
                        line.RemoveRange(0, count);
                        line.Insert(0, merge);
                    }
                }
                else
                {
                    int index = int.Parse(command[1]);
                    int partition = int.Parse(command[2]);
                    string divide = line[index];
                    if (partition > 0 && divide.Length >= partition)
                    {
                        if (divide.Length % partition == 0)
                        {
                            string[] curr = new string[partition];
                            int step = divide.Length / partition;
                            int count = 0;
                            int count1 = 0;
                            for (int i = 0; i < partition; i++) //12 34 56 789
                            {
                                string currDivide = "";
                                for (int j = 0; j < step; j++)
                                {
                                    currDivide += divide[count1].ToString();
                                    count1++;
                                }
                                curr[count] = currDivide;
                                count++;
                            }
                            line.RemoveAt(index);
                            line.InsertRange(index, curr);
                        }
                        else
                        {
                            string[] curr = new string[partition];
                            int step = divide.Length / partition;
                            int count = 0;
                            int count1 = 0;
                            for (int i = 0; i < partition; i++) //1 2 3 4 5 67890
                            {
                                string currDivide = "";
                                for (int j = 0; j < step; j++)
                                {
                                    currDivide += divide[count1].ToString();
                                    count1++;
                                }
                                curr[count] = currDivide;
                                count++;
                            }
                            int indexer = curr.Length;
                            string sub = divide.Substring(count1, divide.Length - count1);
                            curr[curr.Length - 1] += sub;
                            line.RemoveAt(index);
                            line.InsertRange(index, curr);
                        }
                    }

                }
                command = Console.ReadLine()
                .Split();
            }
            Console.WriteLine(string.Join(" ", line));
        }
        public static List<string> Merge(List<string> line, int start, int end)
        {
            string merge = "";
            int count = 0;
            for (int i = start; i <= end; i++)
            {
                merge += line[i];
                count++;
            }
            line.RemoveRange(start, count);
            line.Insert(start, merge);
            return line;
        }
    }
}
