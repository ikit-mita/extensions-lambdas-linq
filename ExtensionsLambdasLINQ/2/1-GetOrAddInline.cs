
using System.Collections.Generic;

namespace ExtensionsLambdasLINQ.GetOrAddInline
{
    public class Metadata
    {
        public int Count { get; set; }
    }

    public class Processor
    {
        public void Process(Dictionary<string, Metadata> cache)
        {
            var key = "// GetUserId()";
            if (!cache.ContainsKey(key))
            {
                cache.Add(key, new Metadata { Count = 0 });
            }
            var metadata = cache[key];
            metadata.Count++;
            // other logic
        }
    }
}
