using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;

namespace Anonymous_Threat_2
{
    class Program
    {
        static void Main(string[] args)
        {
            List<string> line = Console.ReadLine().Split().ToList();
            string[] command = Console.ReadLine().Split();


            while (string.Join("", command) != "3:1")
            {
                if (command[0] == "merge")
                {
                    int start = int.Parse(command[1]);
                    int end = int.Parse(command[2]);
                    if (start >= 0)
                    {
                        if (end < line.Count)
                        {
                            string curr = "";
                            int count = 0;
                            for (int i = start; i <= line.Count - (line.Count - end); i++)
                            {
                                curr += line[i];
                                count++;
                            }
                            line.RemoveRange(start, count);
                            line.Insert(start, curr);
                        }
                        else if (end >= line.Count & start < line.Count)
                        {
                            string curr = "";
                            int count = 0;
                            for (int i = start; i < line.Count; i++)
                            {
                                curr += line[i];
                                count++;
                            }
                            line.RemoveRange(start, count);
                            line.Add(curr);
                        }
                    }
                    else //   0
                    {
                        if (end > 0 && end < line.Count)
                        {
                            string curr = "";
                            int count = 0;
                            for (int i = 0; i <= line.Count - (line.Count - end); i++)
                            {
                                curr += line[i];
                                count++;
                            }
                            line.RemoveRange(0, count);
                            line.Insert(0, curr);
                        }
                        else if (end >= line.Count) //  защото в тази граница влиза нашия line.Count!!!
                        {
                            string curr = "";
                            for (int i = 0; i < line.Count; i++)
                            {
                                curr += line[i];
                            }
                            line.Clear();
                            line.Add(curr);
                        }
                    }
                }// new command
                else if (command[0] == "divide")
                {
                    int index = int.Parse(command[1]);
                    int partitions = int.Parse(command[2]);
                    string curr = line[index];                 
                    if (curr.Length % partitions == 0)
                    {
                        int onePart = curr.Length / partitions;
                        line.Remove(curr);
                        string last = "";
                        int counter = 0;
                        int indexLast = 0;
                        while (counter != partitions)
                        {
                            last = curr.Substring(indexLast, onePart);
                            indexLast += onePart;
                            line.Insert(index, last);
                            index++;
                            counter++;
                        }
                    }
                    else
                    {
                        int onePart = curr.Length / partitions;
                        line.Remove(curr);
                        string last = "";
                        int counter = 0;
                        int indexLast = 0;
                        while (true)
                        {
                            counter++;
                            if (counter == partitions)
                            {
                                last = curr.Substring(indexLast, curr.Length - indexLast);
                                line.Insert(index, last);
                                break;
                            }
                            last = curr.Substring(indexLast, onePart);
                            indexLast += onePart;
                            line.Insert(index, last);
                            index++;
                        }

                    }
                }
                command = Console.ReadLine().Split();
            }
            Console.WriteLine(string.Join(" ", line));
        }

    }
}
