using Acme.Ecommerce.Transverse.Common;
using Microsoft.Extensions.Logging;

namespace Acme.Ecommerce.Transverse.Logging
{
    public class LoggerAdapter<T> : IAppLogger<T>
    {
        private readonly ILogger<T> _logger;

        public LoggerAdapter(ILoggerFactory loggerFactory)
        {
            _logger = loggerFactory.CreateLogger<T>();
        }

        public void LogInformation(string message, params object[] args)
        {
            _logger.Log(LogLevel.Information, message, args);
        }

        public void LogWarning(string message, params object[] args)
        {
            _logger.Log(LogLevel.Warning, message, args);
        }

        public void LogError(string message, params object[] args)
        {
            _logger.Log(LogLevel.Error, message, args);
        }
    }
}
