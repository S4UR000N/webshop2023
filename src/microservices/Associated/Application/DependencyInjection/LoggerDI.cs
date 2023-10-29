using Confluent.Kafka;
using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;
using Serilog;
using Serilog.Configuration;
using Serilog.Formatting;
using Serilog.Sinks.Kafka;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Common.Application.DependencyInjection
{
    public static class LoggerDI
    {
        public static WebApplicationBuilder AddLogger(this WebApplicationBuilder builder)
        {
            Log.Logger = new LoggerConfiguration()
                .MinimumLevel.Debug()
                .WriteTo.Kafka("localhost:9092")
                .CreateLogger();

            return builder;
        }
    }
}
