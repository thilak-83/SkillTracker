using Microsoft.Extensions.Options;
using MongoDB.Driver;
using SkillTracker.Entity;

namespace SkillTracker.Data
{
    public class SkillContext : ISkillContext
    {
        private IMongoDatabase _db { get; set; }
        private MongoClient _mongoClient { get; set; }
        public SkillContext(IOptions<DbSettings> DbSetting)
        {
            _mongoClient = new MongoClient(DbSetting.Value.ConnectionString);
            _db = _mongoClient.GetDatabase(DbSetting.Value.DatabaseName);
         
        }
      
        public IMongoCollection<T> GetCollection<T>(string name)
        {
            return _db.GetCollection<T>(name);
        }
    }
}
