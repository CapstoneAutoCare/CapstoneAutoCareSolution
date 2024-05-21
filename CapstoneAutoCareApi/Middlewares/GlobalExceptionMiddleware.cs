using CapstoneAutoCareApi.Middlewares.Exceptions;
using Newtonsoft.Json;
using Serilog;
using Serilog.Context;
using System.Net;

namespace CapstoneAutoCareApi.Middlewares
{
    public class GlobalExceptionMiddleware : IMiddleware
    {
        private readonly ILogger<GlobalExceptionMiddleware> _logger;

        public GlobalExceptionMiddleware(ILogger<GlobalExceptionMiddleware> logger)
        {
            _logger = logger;
        }

        public async Task InvokeAsync(HttpContext context, RequestDelegate next)
        {
            try
            {
                await next(context);
            }
            catch (Exception exception)
            {
                string errorId = Guid.NewGuid().ToString();
                LogContext.PushProperty("ErrorId", errorId);
                LogContext.PushProperty("StackTrace", exception.StackTrace);

                var errorResult = new ErrorResult
                {
                    StatusCode = (int)HttpStatusCode.InternalServerError,
                    Source = exception.TargetSite?.DeclaringType?.FullName,
                    Exception = exception.Message,
                    ErrorId = errorId,
                    SupportMessage = $"Provide the Error Id: {errorId} to the support team for further analysis."
                };
                errorResult.Messages.Add(exception.Message);

                if (exception is not CustomException && exception.InnerException != null)
                {
                    while (exception.InnerException != null)
                    {
                        exception = exception.InnerException;
                    }
                }
                Log.Error($"{errorResult.Exception} Request failed with Status Code {context.Response.StatusCode} and Error Id {errorId}.");
                var response = context.Response;
                if (!response.HasStarted)
                {
                    response.ContentType = "application/json";
                    response.StatusCode = errorResult.StatusCode;
                    await response.WriteAsync(JsonConvert.SerializeObject(errorResult));
                    //_logger.LogInformation(errorId, exception);
                    //_logger.LogError(exception.Message);
                }

                else
                {
                    Log.Warning("Can't write error response. Response has already started.");
                }
            }

        }
    }
}
