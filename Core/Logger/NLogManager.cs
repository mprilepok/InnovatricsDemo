using InnovatricsDemo.Core.Helpers;
using NLog;
using NLog.Extensions.Logging;

namespace InnovatricsDemo.Core.Logger
{
    public static class NLogManager
    {
        public static NLogLoggingConfiguration Configuration => new NLogLoggingConfiguration(ConfigurationHelper.GetConfiguration().GetSection("NLog"));

        public static NLog.Logger GetLogger()
        {
            if (LogManager.Configuration == null)
            {
                LogManager.Configuration = Configuration;
            }

            return LogManager.GetLogger("Logger");
        }

        public static LogFactory GetLogFactory()
        {
            return new LogFactory(Configuration);
        }
    }
}
