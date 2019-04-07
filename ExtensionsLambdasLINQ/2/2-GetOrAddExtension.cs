
using System.Collections.Generic;

namespace ExtensionsLambdasLINQ.GetOrAddExtension
{
    public class Metadata
    {
        public int Count { get; set; }
    }

    public static class DictionaryExtensions
    {
        public static TValue GetOrAdd<TKey, TValue>(
            this IDictionary<TKey, TValue> dictionary,
            TKey key,
            TValue defaultValue
        )
        {
            if (dictionary.ContainsKey(key))
            {
                return dictionary[key];
            }
            dictionary.Add(key, defaultValue);
            return defaultValue;
        }
    }

    public class Processor
    {
        public void Process(Dictionary<string, Metadata> cache)
        {
            var key = "// GetUserId()";
            var metadata = cache.GetOrAdd(key, new Metadata { Count = 0 });
            metadata.Count++;
            // other logic
        }
    }
}
