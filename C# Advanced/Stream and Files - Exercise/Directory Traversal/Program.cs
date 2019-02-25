namespace Directory_Traversal
{
    using System;
    using System.Collections.Generic;
    using System.IO;
    using System.Linq;

    public class Program
    {
        public static void Main(string[] args)
        {
            string path = Console.ReadLine();

            var files = Directory.GetFiles(path);

            var extFIleInfo = new Dictionary<string, List<FileInfo>>();

            foreach (var file in files)
            {
                FileInfo info = new FileInfo(file);

                if (!extFIleInfo.ContainsKey(info.Extension))
                {
                    extFIleInfo[info.Extension] = new List<FileInfo>();
                }
                extFIleInfo[info.Extension].Add(info);

                string pathDesktop = Environment.GetFolderPath(Environment.SpecialFolder.Desktop) + "/Report1.txt";

                using (var writer = new StreamWriter(pathDesktop))
                {
                    foreach (var kvp in extFIleInfo.OrderByDescending(x => x.Value.Count()).ThenBy(y => y.Key))
                    {

                        writer.WriteLine(kvp.Key);
                        foreach (var inner in kvp.Value.OrderByDescending(x => x.Length))
                        {
                            string name = inner.Name;
                            double size = inner.Length / 1024;
                            writer.WriteLine($"--{name} - {size:f3}kb");
                        }
                    }
                }
            }
        }
    }
}
