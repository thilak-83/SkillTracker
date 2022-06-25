using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SkillTracker.Data
{
    public interface IBaseRepository<TEntity> where TEntity : class
    {
        Task Create(TEntity obj);
        Task<bool> Update(TEntity obj, string id);
        Task<bool> Delete(string id);
        Task<TEntity> Get(string id);
        Task<IEnumerable<TEntity>> Get();
    }
}
