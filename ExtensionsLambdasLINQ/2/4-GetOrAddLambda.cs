using System;
using System.Collections.Generic;

namespace ExtensionsLambdasLINQ.GetOrAddLambda
{
    public class Metadata
    {
        public string Key { get; set; }
        public int Count { get; set; }
    }

    public static class DictionaryExtensions
    {
        public static TValue GetOrAdd<TKey, TValue>(
            this IDictionary<TKey, TValue> dictionary,
            TKey key,
            Func<TValue> defaultValueProvider
        )
        {
            return GetOrAdd(dictionary, key, _ => defaultValueProvider());
        }

        public static TValue GetOrAdd<TKey, TValue>(
            this IDictionary<TKey, TValue> dictionary,
            TKey key,
            Func<TKey, TValue> defaultValueProvider
        )
        {
            if (dictionary.ContainsKey(key))
            {
                return dictionary[key];
            }
            var defaultValue = defaultValueProvider(key);
            dictionary.Add(key, defaultValue);
            return defaultValue;
        }
    }

    public class Processor
    {
        public void Process(Dictionary<string, Metadata> cache)
        {
            var key = "// GetUserId()";
            var metadata = cache.GetOrAdd(key, k => new Metadata { Key = k, Count = 0 });
            metadata.Count++;
            // other logic
        }
    }
}
