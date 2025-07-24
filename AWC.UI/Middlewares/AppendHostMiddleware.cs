namespace AWC.UI.Middlewares
{
    public class AppendHostMiddleware(RequestDelegate next)
    {
        private readonly RequestDelegate _next = next;

        public async Task InvokeAsync(HttpContext context)
        {
            try
            {
                if (!context.Request.Headers.ContainsKey("Host"))
                    context.Request.Headers.Host = "UNKNOWN-HOST";

                await _next(context);
            }
            catch { }
        }
    }

}
