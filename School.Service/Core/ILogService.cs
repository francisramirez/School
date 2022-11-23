
using Microsoft.Extensions.Logging;

namespace School.Service.Core
{
    public interface ILogService<TService> where TService : IBaseService
    {
        void LogError(string message);
        void LogInfo(string message);
        void LogWarning(string mesaage);
    }
    public class LogService<TService> : ILogService<TService> where TService : IBaseService
    {
        private readonly ILogger<TService> logger;

        public LogService(ILogger<TService> logger)
        {
            this.logger = logger;
        }
        public void LogError(string message)
        {
            // Su Logica //
            this.logger.LogError(message);
        }

        public void LogInfo(string message)
        {
            // Su Logica //
            this.logger.LogInformation(message);
        }

        public void LogWarning(string mesaage)
        {
            // Su Logica //
            this.logger.LogWarning(mesaage);
        }
    }
}
