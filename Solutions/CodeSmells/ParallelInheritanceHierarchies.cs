using System;

namespace CodeSmells
{
    public interface ILogger
    {
        void LogMessage(string message);
    }

    public class FileLogger : ILogger
    {
        public void LogMessage(string message)
        {
            Console.WriteLine($"[File] {message}");
        }
    }

    public class DatabaseLogger : ILogger
    {
        public void LogMessage(string message)
        {
            Console.WriteLine($"[Database] {message}");
        }
    }

    public interface IExporter
    {
        void ExportData(string data);
    }

    public class XmlExporter : IExporter
    {
        public void ExportData(string data)
        {
            Console.WriteLine($"Exporting XML: {data}");
        }
    }

    public class JsonExporter : IExporter
    {
        public void ExportData(string data)
        {
            Console.WriteLine($"Exporting JSON: {data}");
        }
    }
}
