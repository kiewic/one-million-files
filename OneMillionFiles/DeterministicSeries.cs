using System;

namespace OneMillionFiles
{
    class DeterministicSeries
    {
        /// <summary>
        /// Creates N random but deterministic key/value pairs. In this case,
        /// a random string as the key and a date/time as the value.
        /// </summary>
        /// <param name="count">Number or required pairs</param>
        /// <param name="doSomething">Method that receives the key and value on each iteration</param>
        public static void Generate(int count, Action<int, string, string> doSomething)
        {
            // These are the variables that make the output deterministic
            Random random = new Random(27);
            DateTimeOffset firstDate = new DateTimeOffset(1992, 4, 27, 6, 0, 0, new TimeSpan());

            for (int i = 0; i < count; i++)
            {
                DateTimeOffset currentDate;
                var a = random.Next();
                var b = random.Next();
                if (i % 2 == 0)
                {
                    currentDate = firstDate.AddMinutes(a);
                }
                if (i % 3 == 0)
                {
                    currentDate = firstDate.AddSeconds(b);
                }
                else
                {
                    currentDate = firstDate.AddSeconds(a);
                }
                var key = String.Format("r{0}j{1}", a, b);
                var value = currentDate.ToString("s");

                doSomething(i, key, value);
            }
        }
    }
}
