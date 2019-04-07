
using System.Collections.Generic;

namespace ExtensionsLambdasLINQ.ToStringSafe
{
    public class Metadata
    {
        public int Count { get; set; }
    }

    public static class GenericExtensions
    {
        public static string ToStringSafe<T>(this T value)
        {
            if (value == null)
            {
                return string.Empty;
            }
            return value.ToString();
        }
    }

    public class Processor
    {
        public void Process(Dictionary<string, Metadata> cache)
        {
            object value = null;

            // after compilation these 2 are the same
            value.ToStringSafe();
            GenericExtensions.ToStringSafe(value);
        }
    }
}
