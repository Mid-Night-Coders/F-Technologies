using System.Text.Json;
using ValidationException = FTech.Domain.Exceptions.ValidationException;

namespace FTech.Presentation.Middlewares
{
    public class GlobalExceptionHandlerMiddleware
    {
        private readonly RequestDelegate _requestDelegate;

        public GlobalExceptionHandlerMiddleware(RequestDelegate requestDelegate)
        {
            _requestDelegate = requestDelegate;
        }

        public async Task Invoke(HttpContext context)
        {
            try
            {
                await _requestDelegate(context);
            }
            catch (ValidationException validationException)
            {
                context.Response.StatusCode = (int)StatusCodes.Status400BadRequest;

                await HandleException(validationException.Message, context);
            }
            catch (Exception ex)
            {
                await HandleException(ex.Message, context);
            }
        }

        private async ValueTask HandleException(string message, HttpContext context)
        {
            context.Response.ContentType = "application/json";
            await context.Response.WriteAsync(JsonSerializer.Serialize(new { error = message }));
            return;
        }
    }
}
