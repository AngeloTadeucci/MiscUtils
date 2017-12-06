using System;
using System.IO;

namespace MiscUtils.IO
{
    public static class PathEx
    {
        public static readonly char[] KnownDirectorySeparators = { '/', '\\' };

        public static string GetRootDirectory(string path)
        {
            path = path.Remove(Path.GetPathRoot(path));
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

        public static string RemoveExtension(string path)
        {
            return Path.ChangeExtension(path, null);
        }
    }
}
