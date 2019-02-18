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

        public static string GetSafeFilename(string filename)
        {
            if (String.IsNullOrWhiteSpace(filename))
            {
                return "invalid_filename." + Guid.NewGuid().ToString();
            }

            string safeFilename = String.Join("", filename.Split(Path.GetInvalidFileNameChars())).TrimEnd(' ');

            if (String.IsNullOrWhiteSpace(safeFilename))
            {
                return "invalid_filename." + Guid.NewGuid().ToString();
            }

            return safeFilename;
        }
    }
}
