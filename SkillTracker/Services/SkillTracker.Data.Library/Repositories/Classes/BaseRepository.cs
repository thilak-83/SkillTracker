using MongoDB.Bson;
using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace SkillTracker.Data
{
    public abstract class BaseRepository<TEntity> : IBaseRepository<TEntity> where TEntity : class
    {
        protected readonly ISkillContext _mongoContext;
        protected IMongoCollection<TEntity> _dbCollection;

        protected BaseRepository(ISkillContext context)
        {
            _mongoContext = context;
            _dbCollection = _mongoContext.GetCollection<TEntity>(typeof(TEntity).Name);
        }

        public async Task Create(TEntity obj)
        {
            if (obj == null)
            {
                throw new ArgumentNullException(typeof(TEntity).Name + " object is null");
            }
            await _dbCollection.InsertOneAsync(obj);
        }

        public async Task<bool> Delete(string id)
        {
            var objectId = new ObjectId(id);
            var deleteResult = await _dbCollection.DeleteOneAsync(Builders<TEntity>.Filter.Eq("_id", objectId));
            return deleteResult.IsAcknowledged && deleteResult.DeletedCount > 0;

        }

        public async Task<TEntity> Get(string id)
        {
            var objectId = new ObjectId(id);
            FilterDefinition<TEntity> filter = Builders<TEntity>.Filter.Eq("_id", objectId);
            return await _dbCollection.FindAsync(filter).Result.FirstOrDefaultAsync();

        }

        public async Task<IEnumerable<TEntity>> Get()
        {
            var all = await _dbCollection.FindAsync(Builders<TEntity>.Filter.Empty);
            return await all.ToListAsync();
        }

        public async Task<bool> Update(TEntity obj, string id)
        {
            var objectId = new ObjectId(id);
            FilterDefinition<TEntity> filter = Builders<TEntity>.Filter.Eq("_id", objectId);
            var updateResult = await _dbCollection.ReplaceOneAsync(filter, replacement: obj);
            return updateResult.IsAcknowledged && updateResult.ModifiedCount > 0;
        }
    }
}
