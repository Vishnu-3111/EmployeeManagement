using NLog;
using Serilog;
using System.Net;

namespace Employee.LoggerExtention
{
    public class LoggerError : IloggerError
    {
        private static NLog.ILogger _logger = LogManager.GetCurrentClassLogger();
        public void Error(string message)
        {
            _logger.Error(message);
        }

        public void LogWarning(string message)
        {
            _logger.Warn(message);
        }
    }
}
