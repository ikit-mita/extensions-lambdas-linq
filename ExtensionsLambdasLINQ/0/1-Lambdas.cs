using System;

namespace ExtensionsLambdasLINQ.Lambdas
{
    public class Processor
    {
        public void Process()
        {
            var avg = CallOperation(1, 2, (i1, i2) => (i1 + i2) / 2);
            var conc = CallOperation("hello", "world", (s1, s2) => s1 + " " + s2);
        }

        public T CallOperation<T>(T arg1, T arg2, Func<T, T, T> op)
        {
            return op(arg1, arg2);
        }
    }
}
