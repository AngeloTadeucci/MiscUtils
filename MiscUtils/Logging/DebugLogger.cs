using System;
using System.Diagnostics;
using System.IO;
using System.Runtime.CompilerServices;

namespace MiscUtils.Logging
{
    public static class DebugLogger
    {
        private const string Format = "[{3}] - [[{0}:{1}]::{2}] {4}";
        public static Action<string, object[]> Out = Console.WriteLine;

        [Conditional("DEBUG")]
        public static void Write(string text, [CallerFilePath] string file = "", [CallerLineNumber] int line = 0, [CallerMemberName] string name = "")
        {
            Out?.Invoke(Format, new object[] { Path.GetFileNameWithoutExtension(file), line, name, DateTime.UtcNow, text, });
        }

        [Conditional("DEBUG")]
        public static void Write(string format, params object[] args)
        {
            Out?.Invoke(format, args);
        }
    }
}
