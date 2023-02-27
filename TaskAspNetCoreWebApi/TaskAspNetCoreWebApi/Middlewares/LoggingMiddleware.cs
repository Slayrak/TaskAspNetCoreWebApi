using Azure.Core;
using System.Text;

namespace TaskAspNetCoreWebApi.Middlewares
{
    public class LoggingMiddleware : IMiddleware
    {
        private readonly ILogger<LoggingMiddleware> _logger;

        public LoggingMiddleware(ILogger<LoggingMiddleware> logger)
        {
            _logger = logger;
        }

        public async Task InvokeAsync(HttpContext context, RequestDelegate next)
        {
            try
            {
                var headers = "";

                foreach(var item in context.Request.Headers) 
                {
                    headers += item.Key + ": " + item.Value + "\n";
                }

                string param = "";

                foreach (var item in context.Request.Query)
                {
                    param += item.Key + ": " + item.Value + "\n";
                }

                context.Request.EnableBuffering();
                var bodyAsText = await new System.IO.StreamReader(context.Request.Body).ReadToEndAsync();
                context.Request.Body.Position = 0;

                _logger.LogInformation($"Method: {context.Request?.Method}\n\nHeaders: \n {headers}\n\nQuery Params:\n {param}\n\nBody:\n {bodyAsText}");
                await next(context);
            }
            finally
            {
                
            }
        }
    }
}
