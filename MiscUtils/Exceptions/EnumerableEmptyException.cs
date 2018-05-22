using System;

namespace MiscUtils
{
    public class EnumerableEmptyException : Exception
    {
        public EnumerableEmptyException() { }

        public EnumerableEmptyException(string message) : base(message) { }

        public EnumerableEmptyException(string message, Exception inner) : base(message, inner) { }
    }
}
