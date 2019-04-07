using System.Collections.Generic;
using System.Linq;

namespace ExtensionsLambdasLINQ.EnumerableRange
{
    public class Processor
    {
        public void Process()
        {
            var intRange = Range(4, 9, 2);
            foreach (var i in intRange.Aggregate)
            {
                System.Console.WriteLine(i); // 4 6 8
            }
        }

        public IEnumerable<int> Range(int from, int to, int step = 1)
        {
            for (int i = from; i <= to; i += step)
            {
                yield return i;
            }
        }
    }
}
