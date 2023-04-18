using System.Net;

namespace Employee.LoggerExtention
{
    public abstract class Loggerextentions
    {
        public abstract void LogError(ILogger logger, string? message, params object?[] args);
    }
}
