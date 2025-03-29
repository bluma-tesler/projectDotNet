using NLog;

namespace Tesler.API.Middlewares
{
    public class LogMiddleware
    {
        private static readonly Logger logger = LogManager.GetCurrentClassLogger();
        private readonly RequestDelegate _next;

        public LogMiddleware(RequestDelegate next)
        {
            _next = next;
        }

        public async Task Invoke(HttpContext context)
           
        { 
            Console.WriteLine("jhkhjkh");
            logger.Info($"The Request {context.Request.Method} is starting");
            try
            {
                await _next(context);
            }
            catch (Exception ex)
            {
                logger.Error(ex, $"its failed! {ex.Message}");
            }

            logger.Info($"The status is: {context.Response.StatusCode}");
        }
    }
}
