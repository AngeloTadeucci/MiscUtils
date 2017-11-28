using System;

namespace MiscUtils.IO
{
    public static class PathEx
    {
        public static readonly char[] KnownDirectorySeparators = { '/', '\\' };

        public static string GetRootDirectory(string path)
        {
            path = path.Trim(KnownDirectorySeparators);

            int index;
            if ((index = path.IndexOfAny(KnownDirectorySeparators)) != -1)
            {
                return path.Substring(0, index);
            }
            else
            {
                return String.Empty;
            }
        }
    }
}
