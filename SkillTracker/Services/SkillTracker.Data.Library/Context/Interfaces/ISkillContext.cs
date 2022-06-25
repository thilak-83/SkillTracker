using MongoDB.Driver;
using SkillTracker.Entity;

namespace SkillTracker.Data
{
    public interface ISkillContext
    {
        IMongoCollection<Profiles> GetCollection<Profiles>(string name);
    }
}
 