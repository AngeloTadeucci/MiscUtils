using System;
using System.Globalization;

namespace MiscUtils;

public static class StringExtensions {
    public static int IndexOfAny(this string s, params char[] anyOf) {
        return s.IndexOfAny(anyOf);
    }

    public static int LastIndexOfAny(this string s, params char[] anyOf) {
        return s.LastIndexOfAny(anyOf);
    }

    public static string Remove(this string s, string toRemove) {
        if (toRemove.Length > 0) {
            return s.Replace(toRemove, string.Empty);
        }
        return s;
    }

    public static byte[] FromHexToBytes(this string s) {
        byte[] result = new byte[s.Length / 2];

        for (int i = 0, j = 0; j < s.Length; i++, j += 2) {
            if (!byte.TryParse(s.Substring(j, 2), NumberStyles.HexNumber, CultureInfo.InvariantCulture.NumberFormat, out byte b)) {
                return null;
            }

            result[i] = b;
        }

        return result;
    }

    public static bool Contains(this string source, string value, StringComparison comparison) {
        return source?.IndexOf(value, comparison) >= 0;
    }
}
