using System;
using System.IO;

namespace OneMillionFiles
{
    class Program
    {
        static void Main(string[] args)
        {
            const int count = 1000000;
            DirectoryInfo dirInfo = new DirectoryInfo("./temp");
            if (!dirInfo.Exists)
            {
                dirInfo.Create();
            }

            DeterministicSeries.Generate(count, (int i, string key, string value) =>
            {
                var fileContent = value;
                var fileName = String.Format("./temp/{0}.txt", key);
                Console.WriteLine("{0,7} {1} {2}", i, fileContent, fileName);
                FileInfo fileInfo = new FileInfo(fileName);
                if (!fileInfo.Exists)
                {
                    File.WriteAllText(fileName, fileContent);
                }
            });
        }
    }
}
