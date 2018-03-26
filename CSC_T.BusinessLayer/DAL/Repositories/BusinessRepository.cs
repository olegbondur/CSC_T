using CSC_T.BusinessLayer.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace CSC_T.BusinessLayer.DAL.Repositories
{
    public class BusinessRepository : IRepository<Business>
    {
        protected readonly CSCDbContext _dataContext;
        protected readonly DbSet<Business> _dataSet;

        public BusinessRepository(CSCDbContext dataContext)
        {
            _dataContext = dataContext;
            _dataSet = dataContext.Businesses;
        }

        public void Add(Business entity)
        {
            _dataSet.Add(entity);
        }

        public void AddRange(IEnumerable<Business> entities)
        {
            _dataSet.AddRange(entities);
        }

        public IEnumerable<Business> All()
        {
            return _dataSet.ToList();
        }

        public async Task<IEnumerable<Business>> AllAsync()
        {
            return await _dataSet.ToListAsync();
        }

        public void Attach(Business entity)
        {
            _dataContext.Entry(entity).State = EntityState.Modified;
        }

        public void Delete(Business entity)
        {
            _dataSet.Remove(entity);
        }

        public void DeleteRange(IEnumerable<Business> entities)
        {
            _dataSet.RemoveRange(entities);
        }

        public Business Find(Func<Business, bool> predicate)
        {
            return _dataSet.FirstOrDefault(predicate);
        }

        public IEnumerable<Business> FindAll(Func<Business, bool> predicate)
        {
            return _dataSet.ToList();
        }

        public async Task<Business> FindAsync(Expression<Func<Business, bool>> predicate)
        {
            return await _dataSet.FirstOrDefaultAsync(predicate);
        }
    }
}
