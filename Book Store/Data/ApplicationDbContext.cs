using Book_Shop.Data;
using Book_Store.Models;
using MongoDB.Driver;

namespace Book_Store.Data
{
    public class ApplicationDbContext
    {
        public ApplicationDbContext(DatabaseSettings setting)
        {
            var client = new MongoClient(setting.ConnectionString);
            var db = client.GetDatabase(setting.DatabaseName);
            Books = db.GetCollection<Book>("books");
        }

        public IMongoCollection<Book> Books { get; set; }
    }
}
