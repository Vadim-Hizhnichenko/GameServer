using Serilog;
using System;

namespace GameServer.Configure
{
    public static class Logging
    {
        public static void ConfigureLogging()
        {
            Log.Logger = new LoggerConfiguration()
                .WriteTo.File("log.txt", rollingInterval: RollingInterval.Day)
                .CreateLogger();
        }

        public static void LogEvent(string message)
        {
            Log.Information(message);
        }
    }
}
