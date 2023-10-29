using Associated.Persistence.Enum;
using Microsoft.AspNetCore.Builder;
using Microsoft.EntityFrameworkCore.Design;
using Microsoft.Extensions.DependencyInjection;
using Associated.Persistence.Factory;

namespace Persistence.Context
{
    public class DesignTimeRelationalContextFactory : IDesignTimeDbContextFactory<RelationalContext>
    {
        public RelationalContext CreateDbContext(string[] args) =>
            WebApplication
                .CreateBuilder()
                .CreateDbContext<RelationalContext>(DbType.MySql, "MySql", ServiceLifetime.Singleton)
                .Build()
                .Services
                .GetRequiredService<RelationalContext>();
    }
}
