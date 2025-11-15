using System;

namespace CodeSmells
{
    public class AdvancedHandler
    {
        public void HandleHttpRequest(HttpRequest request)
        {
            Console.WriteLine($"Handling HTTP request: {request.Url}");
        }

        public void HandleFileRequest(FileRequest request)
        {
            Console.WriteLine($"Handling file request: {request.FileName}");
        }
    }

    public class HttpRequest
    {
        public string Url { get; set; }
    }

    public class FileRequest
    {
        public string FileName { get; set; }
    }
}
