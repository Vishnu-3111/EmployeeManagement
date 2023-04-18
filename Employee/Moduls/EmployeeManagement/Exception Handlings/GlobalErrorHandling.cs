//using Newtonsoft.Json;
using System.Net;
using System.Text.Json;
using static Employee.Moduls.EmployeeManagement.Exeception_Handlings.InvalidIDException;

namespace Employee.Common.Behaviours
{
    public class GlobalErrorHandling
    {
        private readonly RequestDelegate _requestDelegate;
        public GlobalErrorHandling(RequestDelegate requestDelegate)
        {
            _requestDelegate = requestDelegate;
        }
        public async Task Invoke(HttpContext context)
        {
            try
            {
                await _requestDelegate(context);
            }
            catch (Exception ex)
            {
                await HandleExceptionAsync(context, ex);
            }

        }

        private static Task HandleExceptionAsync(HttpContext context, Exception exception)
        {
            HttpStatusCode status;
            string message;
            //var stackTrace=string.Empty;
            var exceptionType=exception.GetType();
            if (exceptionType == typeof(InvalidIDExceptions))
            {
                message = exception.Message;
                status = HttpStatusCode.NotFound;
            }
            else if(exceptionType == typeof(BadRequest))
            {
                    message = exception.Message;
                    status = HttpStatusCode.BadRequest;
            }
                else
                {
                status= HttpStatusCode.InternalServerError;
                message= exception.Message;
                 }
            var exceptionResult = JsonSerializer.Serialize(new { ErrorMessage = message });
            context.Response.ContentType = "application/json";
            context.Response.StatusCode = (int)status;
            return context.Response.WriteAsync(exceptionResult);
        }
    }
}
