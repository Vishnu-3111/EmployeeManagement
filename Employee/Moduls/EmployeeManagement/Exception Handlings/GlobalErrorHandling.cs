//using Newtonsoft.Json;
using Employee.LoggerExtention;
using System.Net;
using System.Text.Json;
using static Employee.Moduls.EmployeeManagement.Exeception_Handlings.InvalidIDException;

namespace Employee.Common.Behaviours
{
    public class GlobalErrorHandling
    {
        private readonly RequestDelegate _requestDelegate;
        private readonly IloggerError _logger;
        public GlobalErrorHandling(RequestDelegate requestDelegate,IloggerError logger)
        {
            _requestDelegate = requestDelegate;
            _logger = logger;
        }
        public async Task Invoke(HttpContext context)
        {
            try
            {
                await _requestDelegate(context);
            }
            catch (Exception ex)
            {
                _logger.Error("SomeThing Went Worng {ex}:");
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
