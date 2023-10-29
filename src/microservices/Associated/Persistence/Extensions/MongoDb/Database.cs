using MongoDB.Driver;
using System.Reflection;

namespace Associated.Persistence.Extensions.MongoDb
{
    public class Database<TDatabase> where TDatabase : class, new()
    {
        public TDatabase Get { get; set; }
        private IMongoDatabase MongoDatabase { get; set; }
        public Database(IMongoClient mongoClient)
        {
            this.MongoDatabase = mongoClient.GetDatabase(typeof(TDatabase).Name);

            this.Get = new TDatabase();
            PropertyInfo[] properties = typeof(TDatabase).GetProperties();

            foreach (var prop in properties)
            {
                if (prop.PropertyType.IsGenericType &&
                    prop.PropertyType.GetGenericTypeDefinition() == typeof(Collection<>))
                {
                    object[] constructorArgs = { MongoDatabase };
                    var myClassInstance = Activator.CreateInstance(prop.PropertyType, constructorArgs)!;
                    prop.SetValue(this.Get, myClassInstance);
                }
            }
        }
    }
}
