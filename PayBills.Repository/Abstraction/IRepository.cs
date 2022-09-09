using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PayBills.Repository.Abstraction
{
    internal interface IRepository<TEntity>
    {
        IEnumerable<TEntity> GetAll();
        IQueryable<TEntity> GetAllQurAsync();
        List<TEntity> GetAllBind();
        TEntity Add(TEntity entity);
      
        TEntity GetBy(params object[] Id);
        Task<TEntity> GetByAsync(params object[] Id);
        Task<TEntity> AddAsync(TEntity entity);
        TEntity Update(TEntity entity);
        TEntity Remove(TEntity entity);
        Task<TEntity> RemoveByIdAsync(params object[] Id);
        Task<TEntity> UpdateAsync(TEntity entity);     
        TEntity RemoveById(params object[] Id);
    }
}