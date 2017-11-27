using System;

namespace MiscUtils.IO
{
    public static class PathEx
    {
        public static string GetRootDirectory(string path)
        {
            path = path.Trim('/', '\\');

            int index;
            if ((index = path.IndexOfAny('/', '\\')) != -1)
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
