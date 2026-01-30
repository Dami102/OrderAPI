using OrderAPI.Core.DTOs;

namespace OrderAPI.Extensions
{
    public static class ErrorMiddleware
    {
        public static void UseErrorHandling(this WebApplication app)
        {
            app.Use(async (context, next) =>
            {
                try
                {
                    await next(); // Call the next middleware / endpoint
                }
                catch (Exception ex)
                {
                    // Log the error if needed
                    Console.WriteLine($"Error: {ex.Message}");

                    // Customize status code
                    int statusCode = ex switch
                    {
                        KeyNotFoundException => 404,
                        InvalidOperationException => 400,
                        _ => 500
                    };

                    // Standardized error response
                    var response = new APIResponse<string>
                    {
                        Message = ex.Message,
                        StatusCode = statusCode,
                        Status = false
                    };

                    context.Response.ContentType = "application/json";
                    context.Response.StatusCode = statusCode;

                    await context.Response.WriteAsJsonAsync(response);
                }
            });
        }
        }
}
