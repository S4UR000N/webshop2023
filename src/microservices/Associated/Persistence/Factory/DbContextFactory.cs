using Associated.Persistence.Enum;
using Associated.Persistence.Extensions.MongoDb;
using Microsoft.AspNetCore.Builder;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace Associated.Persistence.Factory
{
    public static class DbContextFactory
    {
        public static WebApplicationBuilder CreateDbContext<TContext>(this WebApplicationBuilder builder, DbType dbType, string conStrKey = "", ServiceLifetime serviceLifetime = ServiceLifetime.Scoped) where TContext : DbContext
        {
            if (builder is null) throw new ArgumentNullException(nameof(builder));

            var conStr = "";
            conStr = string.IsNullOrEmpty(conStrKey)
                ? builder.Configuration.GetConnectionString(dbType.ToString())
                : builder.Configuration.GetConnectionString(conStrKey);

            if (string.IsNullOrEmpty(conStr)) throw new ArgumentException($"Unfound connection string under they key of {conStrKey}");

            switch (dbType)
            {
                case DbType.MySql:
                    builder.Services.AddDbContext<TContext>(options => options.UseMySql(conStr, ServerVersion.AutoDetect(conStr)), serviceLifetime);
                    break;
                default:
                    // code block
                    break;
            }

            return builder;
        }

        public static WebApplicationBuilder CreateDbClient<TContext>(this WebApplicationBuilder builder, DbType dbType, string conStrKey = "") where TContext : DbClient<TContext>
        {
            if (builder is null) throw new ArgumentNullException(nameof(builder));

            var conStr = string.IsNullOrEmpty(conStrKey)
                ? builder.Configuration.GetConnectionString(dbType.ToString())
                : builder.Configuration.GetConnectionString(conStrKey);

            if (string.IsNullOrEmpty(conStr)) throw new ArgumentException($"Unfound connection string under they key of {conStrKey}");

            builder.Services.AddMongoDbClient<TContext>(conStr);
            // class with static method that instantiates client with access to the root of the server
            // some ioc method of providing access to available databases via DI
            // some way of defining all available databases and their mappings / models / dbsets via some form of MongoDbContext similar to EF

            return builder;
        }
    }
}
