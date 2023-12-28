using Microsoft.AspNetCore.Builder;
using Serilog;
using Serilog.Events;
using Serilog.Sinks.Kafka;

namespace Common.Application.DependencyInjection
{
    public static class LoggerDI
    {
        public static WebApplicationBuilder AddLogger(this WebApplicationBuilder builder)
        {
            Log.Logger = new LoggerConfiguration()
                .MinimumLevel.Information()
                .WriteTo.Kafka("localhost:9092", topic: "test123")
                .WriteTo.Debug(LogEventLevel.Information)
                .CreateLogger();

            return builder;
        }
    }
}
