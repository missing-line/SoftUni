using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;

namespace _03._Treasure_Finder
{
    class Program
    {
        static void Main(string[] args)
        {
            List<int> keys = Console.ReadLine().Split().Select(int.Parse).ToList();

            string token = Console.ReadLine();
            List<string> tokens = new List<string>();
            List<string> resultTreasure = new List<string>();
            string patternType = @"(\&([^\&]+)\&)";
            string patternCoordinates = @"(\<([^\>]+)\>)"; //\<([^\>]+)\>
            while (token != "find")
            {
                tokens.Add(token);
                token = Console.ReadLine();
            }
            
            for (int i = 0; i < tokens.Count; i++)
            {
                string curr = tokens[i];               
                string afterDec = "";
                int count = 0;
                for (int j = 0; j < curr.Length; j++)
                {
                    while (true)
                    {
                        if (count >= keys.Count)
                        {
                            count = 0;
                        }                       
                        afterDec += (char)((int)curr[j] - keys[count]);
                        count++;
                        break;
                    }                   
                }              
                Match matchType = Regex.Match(afterDec, patternType);
                Match matchCoordinates = Regex.Match(afterDec, patternCoordinates);
                if (matchType.Success && matchCoordinates.Success)
                {
                    string type = matchType.Value.Trim('&');
                    string coordinates = matchCoordinates.Value.Trim("<>".ToCharArray());
                    string currResult = $"Found {type} at {coordinates}";                  
                    resultTreasure.Add(currResult);
                }
            }
            foreach (var singleTreasure in resultTreasure)
            {
                Console.WriteLine(singleTreasure);
            }
        }
    }
}
