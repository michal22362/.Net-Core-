using System.Diagnostics;
using System.IO; // Added namespace for file operations
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Logging; // Changed namespace for ILogger

namespace MyMiddleware
{
    public class MyFileMiddleware
    {
        private readonly RequestDelegate next;

        public MyFileMiddleware(RequestDelegate next)
        {
            this.next = next;
        }

        public async Task Invoke(HttpContext c)
        {
            var sw = new Stopwatch();
            sw.Start();
            await next.Invoke(c);
            var message = $"hello michal politanski!!!!!!";
            
            // Writing to a text file
            string path = "./Data/file.txt";
            using (StreamWriter writer = File.AppendText(path))
            {
                await writer.WriteLineAsync(message);
            }
            
        }
    }

    public static partial class MiddlewareExtensions
    {
        public static IApplicationBuilder UseMyFileMiddleware(this IApplicationBuilder builder)
        {
            return builder.UseMiddleware<MyFileMiddleware>();
        }
    }
}
