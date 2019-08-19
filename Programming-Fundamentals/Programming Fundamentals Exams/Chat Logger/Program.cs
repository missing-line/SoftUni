using System;
using System.Collections.Generic;
using System.Linq;

namespace Chat_Logger
{
    class Program
    {
        static void Main(string[] args)
        {
            string command = Console.ReadLine();
            List<string> msg = new List<string>();

            while (command != "end")
            {
                string[] curr = command.Split().ToArray();
                if (curr[0] == "Chat")
                {
                    msg.Add(curr[1]);
                }
                else if (curr[0] == "Delete")
                {
                    if (msg.Contains(curr[1]))
                    {
                        msg.Remove(curr[1]);
                    }
                }
                else if (curr[0] == "Edit")
                {
                    string messageToEdit = curr[1];
                    string editedVersion = curr[2];
                    if (msg.Contains(messageToEdit))
                    {
                        int index = msg.IndexOf(messageToEdit);
                        msg[index] = editedVersion;
                    }
                }
                else if (curr[0] == "Pin")
                {
                    string currMsg = curr[1];
                    if (msg.Contains(currMsg))
                    {
                        msg.Remove(currMsg);
                        msg.Add(currMsg);
                    }
                }
                else if (curr[0] == "Spam")
                {
                    for (int i = 1; i <= curr.Length - 1; i++)
                    {
                        msg.Add(curr[i]);
                    }
                }
                command = Console.ReadLine();
            }
            Console.WriteLine(string.Join("\n", msg));
        }
    }
}
