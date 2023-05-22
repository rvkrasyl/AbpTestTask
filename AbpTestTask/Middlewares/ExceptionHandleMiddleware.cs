using System.Net;

namespace AbpWebApi.Meddlewares
{
    public class ExceptionHandleMiddleware
    {
        private readonly RequestDelegate _next;

        public ExceptionHandleMiddleware(RequestDelegate next)
        {
            _next = next;
        }

        public async Task Invoke(HttpContext context)
        {
            try
            {
                await _next(context);
            }
            catch (Exception ex)
            {
                await HandleExceptionAsync(context, ex);
            }
        }

        private Task HandleExceptionAsync(HttpContext context, Exception ex)
        {
            string message = ex.Message;
            Type exceptionType = ex.GetType();

            HttpStatusCode statusCode = exceptionType.Name switch
            {
                _ => HttpStatusCode.InternalServerError,
            };

            context.Response.ContentType = "application/json";
            context.Response.StatusCode = (int)statusCode;

            return context.Response.WriteAsJsonAsync(new { error = message });
        }
    }
}
