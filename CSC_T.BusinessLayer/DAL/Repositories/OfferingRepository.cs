using CSC_T.BusinessLayer.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace CSC_T.BusinessLayer.DAL.Repositories
{
    class OfferingRepository : IRepository<Offering>
    {
        protected readonly CSCDbContext _dataContext;
        protected readonly DbSet<Offering> _dataSet;

        public OfferingRepository(CSCDbContext dataContext)
        {
            _dataContext = dataContext;
            _dataSet = dataContext.Offerings;
        }

        public void Add(Offering entity)
        {
            _dataSet.Add(entity);
        }

        public void AddRange(IEnumerable<Offering> entities)
        {
            _dataSet.AddRange(entities);
        }

        public IEnumerable<Offering> All()
        {
            return _dataSet.ToList();
        }

        public async Task<IEnumerable<Offering>> AllAsync()
        {
            return await _dataSet.ToListAsync();
        }

        public void Attach(Offering entity)
        {
            _dataContext.Entry(entity).State = EntityState.Modified;
        }

        public void Delete(Offering entity)
        {
            _dataSet.Remove(entity);
        }

        public void DeleteRange(IEnumerable<Offering> entities)
        {
            _dataSet.RemoveRange(entities);
        }

        public Offering Find(Func<Offering, bool> predicate)
        {
            return _dataSet.FirstOrDefault(predicate);
        }

        public IEnumerable<Offering> FindAll(Func<Offering, bool> predicate)
        {
            return _dataSet.ToList();
        }

        public async Task<Offering> FindAsync(Expression<Func<Offering, bool>> predicate)
        {
            return await _dataSet.FirstOrDefaultAsync(predicate);
        }
    }
}
