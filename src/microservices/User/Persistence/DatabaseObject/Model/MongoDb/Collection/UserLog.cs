using MongoDB.Bson;

namespace Persistence.DatabaseObject.Model.MongoDb.Collection
{
    public class UserLog
    {
        public ObjectId Id { get; set; }
        public string Description { get; set; }
    }
}
