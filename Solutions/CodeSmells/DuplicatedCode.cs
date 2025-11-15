using System;

namespace CodeSmells
{
    public static class Logger
    {
        private static string FormatLogMessage(string level, string message, DateTime timestamp)
        {
            string formattedTimestamp = timestamp.ToString("yyyy-MM-dd HH:mm:ss");
            return $"{level}: [{formattedTimestamp}] {message}";
        }

        public static void LogError(string message, DateTime timestamp)
        {
            Console.WriteLine(FormatLogMessage("ERROR", message, timestamp));
        }

        public static void LogWarning(string message, DateTime timestamp)
        {
            Console.WriteLine(FormatLogMessage("WARNING", message, timestamp));
        }
    }
}
