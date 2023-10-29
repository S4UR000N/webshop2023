using MongoDB.Driver;

namespace Associated.Persistence.Extensions.MongoDb
{
    public class Collection<TEntity>
    {
        private IMongoCollection<TEntity> MongoCollection { get; set; }
        public Collection(IMongoDatabase mongoDatabase)
        {
            this.MongoCollection = mongoDatabase.GetCollection<TEntity>(typeof(TEntity).Name);
        }

        public List<TEntity> GetAll()
        {
            return this.MongoCollection.Find(_ => true).ToList();
        }
    }
}
