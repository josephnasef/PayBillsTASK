using Microsoft.EntityFrameworkCore;
using PayBills.Domin.Context;
using PayBills.Repository.Abstraction;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PayBills.Repository.Concert
{
    public class Repository<TEtity> : IRepository<TEtity> where TEtity : class
    {
        protected PayBillContext _BloggerContext { get; set; }
        public Repository(PayBillContext BloggerContext)
        {
            this._BloggerContext = BloggerContext;

        }
        public TEtity Add(TEtity entity)
        {
            _BloggerContext.Set<TEtity>().Add(entity);
            return _BloggerContext.SaveChanges() > 0 ? entity : null;
        }
        public async Task<TEtity> AddAsync(TEtity entity)
        {
            var result = await _BloggerContext.Set<TEtity>().AddAsync(entity);
            return await _BloggerContext.SaveChangesAsync() > 0 ? entity : null;
        }
        public TEtity GetBy(params object[] Id)
        {
            var MyObject = _BloggerContext.Set<TEtity>().Find(Id);
            return MyObject;
        }
        public async Task<TEtity> GetByAsync(params object[] Id)
        {
            //var MyObject = await _BloggerContext.Set<TEtity>().FindAsync(Id);
            return await _BloggerContext.Set<TEtity>().FindAsync(Id);
        }
        public List<TEtity> GetAllBind()
        {
            return GetAll().ToList();
        }
        public IEnumerable<TEtity> GetAll()
        {
            return this._BloggerContext.Set<TEtity>().AsNoTracking();
        }
        public async Task<IEnumerable<TEtity>> GetAllAsyn()
        {
            return await this._BloggerContext.Set<TEtity>().ToListAsync(); ;
        }
        public IQueryable<TEtity> GetAllQurAsync()
        {
            return this._BloggerContext.Set<TEtity>();
        }
        public TEtity RemoveById(params object[] Id)
        {
            var entity = GetBy(Id);
            _BloggerContext.Set<TEtity>().Remove(GetBy(Id));

            return _BloggerContext.SaveChanges() > 0 ? entity : null;
        }
        public TEtity Remove(TEtity entity)
        {
            _BloggerContext.Set<TEtity>().Remove(entity);

            return _BloggerContext.SaveChanges() > 0 ? entity : null;
        }
        public async Task<TEtity> RemoveByIdAsync(params object[] Id)
        {
            var entity = await _BloggerContext.Set<TEtity>().FindAsync(Id);
            _BloggerContext.Set<TEtity>().Remove(entity);
            return await _BloggerContext.SaveChangesAsync() > 0 ? entity : null;
        }
        public TEtity Update(TEtity entity)
        {
            _BloggerContext.Set<TEtity>().Update(entity);
            return _BloggerContext.SaveChanges() > 0 ? entity : null;
        }
        public async Task<TEtity> UpdateAsync(TEtity entity)
        {
            _BloggerContext.Set<TEtity>().Update(entity);
            return await _BloggerContext.SaveChangesAsync() > 0 ? entity : null;
        }
        public void Save()
        {
            _BloggerContext.SaveChanges();
        }       
    }
}

