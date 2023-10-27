using Microsoft.AspNetCore.Mvc.Filters;
using System.Net;
using System.Runtime.Serialization;

namespace AdaptrisApi
{
    public class CustomExceptionFilter : IExceptionFilter
    {
        public void OnException(ExceptionContext context)
        {
            var exceptionType = context.Exception.GetType();
            string message;
            HttpStatusCode status;

            if (exceptionType == typeof(UnauthorizedAccessException))
            {
                message = "Unauthorized Access";
                status = HttpStatusCode.Unauthorized;
            }
            else if (exceptionType == typeof(NotImplementedException))
            {
                message = "A server error occurred.";
                status = HttpStatusCode.NotImplemented;
            }
            else if (exceptionType == typeof(OrderResponseException))
            {
                message = context.Exception.ToString();
                status = HttpStatusCode.InternalServerError;
            }
            else
            {
                message = context.Exception.Message;
                status = HttpStatusCode.NotFound;
            }
            context.ExceptionHandled = true;

            HttpResponse response = context.HttpContext.Response;
            response.StatusCode = (int)status;
            response.ContentType = "application/xml";
            //var err = message + " " + context.Exception.StackTrace;
            response.WriteAsync(message);
        }
    }


    public class OrderResponseException : Exception
    {
        public OrderResponseException()
        {
        }

        public OrderResponseException(string? message) : base(message)
        {
        }

        public OrderResponseException(string? message, Exception? innerException) : base(message, innerException)
        {
        }

        protected OrderResponseException(SerializationInfo info, StreamingContext context) : base(info, context)
        {
        }

        public void ConfigureServices(IServiceCollection services)
        {
            services.AddMvc(
                config =>
                {
                    config.Filters.Add(typeof(CustomExceptionFilter));
                }
            );
        }
    }
}
