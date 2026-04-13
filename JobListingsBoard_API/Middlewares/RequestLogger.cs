namespace JobListingsBoard_API.Middlewares
{
    public class RequestLogger
    {
        private readonly RequestDelegate _next;
        private readonly ILogger<RequestLogger> _logger;

        public RequestLogger(RequestDelegate next, ILogger<RequestLogger> logger)
        {
            _next = next;
            _logger = logger;
        }

        public async Task Invoke(HttpContext context)
        {
            var startTime = DateTime.Now;
            var method = context.Request.Method;
            var path = context.Request.Path;
            _logger.LogInformation($"[{startTime:yyyy-MM-dd HH:mm:ss}] {method} {path}");

            await _next(context);

            var endTime = DateTime.Now;
            var duration = (endTime - startTime).TotalMilliseconds;

            var statusCode = context.Response.StatusCode;

            var statusText = GetStatusText(statusCode);

            _logger.LogInformation($"[{endTime:yyyy-MM-dd HH:mm:ss}] {method} {path} → {statusCode} {statusText} (took {duration}ms)");
        }

        private string GetStatusText(int statusCode)
        {
            return statusCode switch
            {
                200 => "OK",
                201 => "Created",
                204 => "No Content",
                400 => "Bad Request",
                401 => "Unauthorized",
                404 => "Not Found",
                500 => "Internal Server Error",
                _ => ""
            };
        }
    }
}
