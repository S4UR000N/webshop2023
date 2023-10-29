using Associated.Persistence.Extensions.MongoDb;
using Persistence.DatabaseObject.Model.MongoDb.Database;

namespace Persistence.Context
{
    public class DocumentContext : DbClient<DocumentContext>
    {
        public DocumentContext(string conStr) : base(conStr) { }
        public Database<Webshop2023> Webshop2023 { get; set; }
    }
}
