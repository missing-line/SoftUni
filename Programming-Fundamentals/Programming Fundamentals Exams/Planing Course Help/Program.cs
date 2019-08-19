using System;
using System.Collections.Generic;
using System.Linq;
namespace SoftUniCoursePlanning
{
    class Program
    {
        static void Main(string[] args)
        {
            string separator = ", ";
            List<string> initialList = Console.ReadLine().Split(new[] { separator }, StringSplitOptions.RemoveEmptyEntries).ToList();

            while (true)
            {
                string[] input = Console.ReadLine().Split(':').ToArray();
                string command = input[0];
                if (command == "course start")
                {
                    break;
                }
                else if (command == "Add")
                {
                    string title = input[1];
                    if (initialList.Contains(title) == false)
                    {
                        initialList.Add(title);
                    }
                }
                else if (command == "Insert")
                {
                    int index = int.Parse(input[2]);
                    string title = input[1];
                    if (initialList.Contains(title) == false)
                    {
                        initialList.Insert(index, title);
                    }
                }
                else if (command == "Remove")
                {
                    string title = input[1];
                    if (initialList.Contains(title))
                    {
                        initialList.Remove(title);
                    }
                    if (initialList.Contains(title + "-Exercise"))
                    {
                        initialList.Remove(title + "-Exercise");
                    }
                }
                else if (command == "Swap")
                {
                    string firstTitle = input[1];
                    string secondTitle = input[2];
                    int firstIndex = -1;
                    int secondIndex = -1;
                    for (int i = 0; i < initialList.Count; i++)
                    {
                        if (initialList[i] == firstTitle)
                        {
                            firstIndex = i;
                        }
                        if (initialList[i] == secondTitle)
                        {
                            secondIndex = i;
                        }
                    }
                    if (initialList.Contains(firstTitle) && initialList.Contains(secondTitle))
                    {
                        if (initialList.Contains(firstTitle + "-Execise"))
                        {
                            initialList.Remove(firstTitle);
                            initialList.Remove(firstTitle + "-Exercise");
                            initialList.Remove(secondTitle);
                            initialList.Insert(firstIndex, secondTitle);
                            initialList.Insert(secondIndex, firstTitle);
                            initialList.Insert(firstIndex + 1, firstTitle + "-Exercise");
                        }
                        else if (initialList.Contains(secondTitle + "-Exercise"))
                        {
                            initialList.Remove(firstTitle);
                            initialList.Remove(secondTitle);
                            initialList.Remove(secondTitle + "-Exercise");
                            initialList.Insert(firstIndex, secondTitle);
                            initialList.Insert(secondIndex, firstTitle);
                            initialList.Insert(firstIndex + 1, secondTitle + "-Exercise");
                        }
                        else
                        {
                            initialList.Remove(firstTitle);
                            initialList.Remove(secondTitle);
                            initialList.Insert(firstIndex, secondTitle);
                            initialList.Insert(secondIndex, firstTitle);
                        }
                    }
                }
                else if (command == "Exercise")
                {
                    string title = input[1];
                    if (initialList.Contains(title) && initialList.Contains(title + "-Exercise") == false)
                    {
                        int index = -1;
                        for (int i = 0; i < initialList.Count; i++)
                        {
                            if (initialList[i] == title)
                            {
                                index = i;
                                break;
                            }
                        }
                        initialList.Insert(index + 1, title + "-Exercise");
                    }
                    else if (initialList.Contains(title) == false && initialList.Contains(title + "-Exercise") == false)
                    {
                        initialList.Add(title);
                        initialList.Add(title + "-Exercise");
                    }
                }
            }
            for (int i = 0; i < initialList.Count; i++)
            {
                Console.WriteLine($"{i + 1}.{initialList[i]}");
            }
        }
    }
}