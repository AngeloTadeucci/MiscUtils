using System;

namespace MiscUtils
{
    public static class StringExtensions
    {
        public static int IndexOfAny(this string s, params char[] anyOf)
        {
            return s.IndexOfAny(anyOf);
        }

        public static int LastIndexOfAny(this string s, params char[] anyOf)
        {
            return s.LastIndexOfAny(anyOf);
        }

        public static string Remove(this string s, string toRemove)
        {
            if (toRemove.Length > 0)
            {
                return s.Replace(toRemove, String.Empty);
            }
            else
            {
                return s;
            }
        }
    }
}
