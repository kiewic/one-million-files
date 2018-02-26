using OneMillionFiles;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SearchInOneMillionFiles
{
    class Program
    {
        static void Main(string[] args)
        {
            Stopwatch stopwatch = new Stopwatch();

            // Add all key/values into a dictionary
            stopwatch.Start();
            const int count = 1000000;
            var dict = new Dictionary<string, List<string>>();
            DeterministicSeries.Generate(count, (int i, string key, string value) =>
            {
                if (!dict.ContainsKey(value))
                {
                    dict[value] = new List<string>();
                }
                dict[value].Add(key);
            });
            Console.WriteLine(stopwatch.Elapsed);

            // Pick some random pairs
            stopwatch.Restart();
            Random random = new Random(10);
            for (int i = 0; i < 10000; i++)
            {
                int index = random.Next(dict.Count);
                string selectedKey = dict.Keys.ElementAt(index);
                Console.WriteLine("{0}, {1}", selectedKey, search(dict, selectedKey));
            }
            Console.WriteLine(stopwatch.Elapsed);
        }

        private static string search(Dictionary<string, List<string>> dict, string selectedKey)
        {
            string result = String.Join(", ", dict[selectedKey].ToArray());
            return result;
        }
    }
}
