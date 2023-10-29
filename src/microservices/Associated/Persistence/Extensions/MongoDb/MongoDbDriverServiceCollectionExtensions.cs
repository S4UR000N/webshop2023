using Microsoft.Extensions.DependencyInjection;

namespace Associated.Persistence.Extensions.MongoDb
{
    public static class MongoDbDriverServiceCollectionExtensions
    {
        public static IServiceCollection AddMongoDbClient<TClient>(this IServiceCollection serviceCollection, string conStr = "") where TClient : DbClient<TClient>
        {
            if (serviceCollection is null) throw new ArgumentNullException(nameof(serviceCollection));
            if (string.IsNullOrEmpty(conStr)) throw new ArgumentNullException(nameof(conStr));

            object[] constructorArgs = { conStr };
            serviceCollection.AddSingleton(serviceProvider =>  (TClient)Activator.CreateInstance(typeof(TClient), constructorArgs)!);

            return serviceCollection;
        }
    }
}
