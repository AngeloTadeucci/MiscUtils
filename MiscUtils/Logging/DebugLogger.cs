using System;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using MiscUtils.IO;

namespace MiscUtils.Logging;

public static class DebugLogger {
    private const string Format = "[{0}] - [[{1}] [{2}:{3}]::{4}] {5}";
    public static Action<string, object[]> Out = Console.WriteLine;
    public static string Identifier = nameof(DebugLogger);

    [Conditional("DEBUG")]
    public static void Write(string message, [CallerFilePath] string file = "", [CallerLineNumber] int line = 0, [CallerMemberName] string name = "") {
        Write(Format, DateTime.UtcNow.TimeOfDay,
            Identifier,
            file.Substring(file.LastIndexOfAny(PathEx.KnownDirectorySeparators) + 1),
            line,
            name,
            message);
    }

    [Conditional("DEBUG")]
    public static void Write(string format, params object[] args) {
        Out?.Invoke(format, args);
    }
}
