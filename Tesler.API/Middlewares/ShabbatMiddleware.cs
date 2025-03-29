namespace Tesler.API.Middlewares
{
    public class ShabbatMiddleware
    {
        private readonly RequestDelegate _next;
        public ShabbatMiddleware(RequestDelegate next)
        {
            _next = next;
        }
        public async Task InvokeAsync(HttpContext context)
        {
            Console.WriteLine("middleware start");
            if (DateTime.Today.DayOfWeek == DayOfWeek.Saturday)
            {
                context.Response.StatusCode = StatusCodes.Status400BadRequest;
            }
            else
            {
                await _next(context);
            }
            Console.WriteLine("middleware end");
        }
    }
}
