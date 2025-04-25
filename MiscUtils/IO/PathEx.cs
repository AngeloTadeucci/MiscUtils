using System;
using System.IO;

namespace MiscUtils.IO;

public static class PathEx {
    public static readonly char[] KnownDirectorySeparators = {
        '/',
        '\\',
    };

    public static string GetRootDirectory(string path) {
        path = path.Remove(Path.GetPathRoot(path));
        path = path.Trim(KnownDirectorySeparators);

        int index;
        if ((index = path.IndexOfAny(KnownDirectorySeparators)) != -1) {
            return path.Substring(0, index);
        }
        return string.Empty;
    }

    public static string RemoveExtension(string path) {
        return Path.ChangeExtension(path, null);
    }

    public static string GetSafeFilename(string filename) {
        if (string.IsNullOrWhiteSpace(filename)) {
            return "invalid_filename." + Guid.NewGuid();
        }

        string safeFilename = string.Join("", filename.Split(Path.GetInvalidFileNameChars())).TrimEnd(' ');

        if (string.IsNullOrWhiteSpace(safeFilename)) {
            return "invalid_filename." + Guid.NewGuid();
        }

        return safeFilename;
    }

    public static bool ExtensionEquals(string filename, string extension) {
        return string.Compare(Path.GetExtension(filename), extension, StringComparison.OrdinalIgnoreCase) == 0;
    }
}
