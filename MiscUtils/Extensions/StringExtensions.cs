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
    }
}
