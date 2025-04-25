using System;
using System.Linq;

namespace MiscUtils.Logging;

public static class SimpleLogger {
    private static readonly int LongestLogModeNameLength = Enum.GetNames(typeof(LogMode)).Max(s => s.Length);
    private static readonly char PaddingChar = ' ';

    public static LogMode LoggingLevel;
    public static Action<string, object[]> Out = Console.WriteLine;

    public static void Debug(string text) {
        Debug(text, null);
    }
    public static void Debug(string text, params object[] args) {
        Write(text, LogMode.Debug, args);
    }
    public static void Verbose(string text) {
        Verbose(text, null);
    }
    public static void Verbose(string text, params object[] args) {
        Write(text, LogMode.Verbose, args);
    }
    public static void Info(string text) {
        Info(text, null);
    }
    public static void Info(string text, params object[] args) {
        Write(text, LogMode.Info, args);
    }
    public static void Warning(string text) {
        Warning(text, null);
    }
    public static void Warning(string text, params object[] args) {
        Write(text, LogMode.Warning, args);
    }
    public static void Error(Exception ex) {
        Error(ex.ToString());
    }
    public static void Error(string text) {
        Error(text, null);
    }
    public static void Error(string text, params object[] args) {
        Write(text, LogMode.Error, args);
    }
    public static void Write(string text, LogMode logMode) {
        Write(text, logMode, null);
    }

    public static void Write(string format, LogMode logMode, params object[] args) {
        if (LoggingLevel <= logMode) {
            Out?.Invoke($"[{logMode.ToString().PadRight(LongestLogModeNameLength, PaddingChar)}] [{DateTime.UtcNow.ToString("O")}] {format}", args);
        }
    }
}
