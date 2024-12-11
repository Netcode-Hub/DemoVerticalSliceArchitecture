using Microsoft.AspNetCore.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using System.Net;

namespace DemoVerticalSliceArchitecture.Exceptions
{
    public class GlobalExceptionHandler : IExceptionHandler
    {
        public async ValueTask<bool> TryHandleAsync(HttpContext httpContext, 
            Exception exception, CancellationToken cancellationToken)
        {
            httpContext.Response.ContentType = "application/json";
            httpContext.Response.StatusCode = (int)HttpStatusCode.InternalServerError;
            var problemDetails = new ProblemDetails
            {
                Detail = $"Internal Error {exception.Message}",
                Instance = httpContext.Request.Path,
                Status = 500,
                Title = "Error",
                Type = "Internal Error"
            };
            await httpContext.Response.WriteAsJsonAsync(problemDetails, cancellationToken);
            return true;
        }
    }
}
