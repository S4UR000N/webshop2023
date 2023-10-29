using MongoDB.Driver;
using System.Reflection;

namespace Associated.Persistence.Extensions.MongoDb
{
    public class DbClient<TContext>
    {
        private MongoClient MongoClient { get; set; }
        public DbClient(string conStr)
        {
            MongoClient = new MongoClient(conStr);

            PropertyInfo[] properties = typeof(TContext).GetProperties();

            if (this is TContext derivedInstance)
            {
                foreach (var prop in properties)
                {
                    if (prop.PropertyType.IsGenericType &&
                        prop.PropertyType.GetGenericTypeDefinition() == typeof(Database<>))
                    {
                        object[] constructorArgs = { MongoClient };
                        var myClassInstance = Activator.CreateInstance(prop.PropertyType, constructorArgs);
                        prop.SetValue(derivedInstance, myClassInstance);
                    }
                }
            }
        }
    }
}
