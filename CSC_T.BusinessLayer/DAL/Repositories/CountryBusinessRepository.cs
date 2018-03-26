using CSC_T.BusinessLayer.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace CSC_T.BusinessLayer.DAL.Repositories
{
    class CountryBusinessRepository : IRepository<CountryBusiness>
    {
        protected readonly CSCDbContext _dataContext;
        protected readonly DbSet<CountryBusiness> _dataSet;

        public CountryBusinessRepository(CSCDbContext dataContext)
        {
            _dataContext = dataContext;
            _dataSet = dataContext.CountryBusiness;
        }

        public void Add(CountryBusiness entity)
        {
            _dataSet.Add(entity);
        }

        public void AddRange(IEnumerable<CountryBusiness> entities)
        {
            _dataSet.AddRange(entities);
        }

        public IEnumerable<CountryBusiness> All()
        {
            return _dataSet.ToList();
        }

        public async Task<IEnumerable<CountryBusiness>> AllAsync()
        {
            return await _dataSet.ToListAsync();
        }

        public void Attach(CountryBusiness entity)
        {
            _dataContext.Entry(entity).State = EntityState.Modified;
        }

        public void Delete(CountryBusiness entity)
        {
            _dataSet.Remove(entity);
        }

        public void DeleteRange(IEnumerable<CountryBusiness> entities)
        {
            _dataSet.RemoveRange(entities);
        }

        public CountryBusiness Find(Func<CountryBusiness, bool> predicate)
        {
            return _dataSet.FirstOrDefault(predicate);
        }

        public IEnumerable<CountryBusiness> FindAll(Func<CountryBusiness, bool> predicate)
        {
            return _dataSet.ToList();
        }

        public async Task<CountryBusiness> FindAsync(Expression<Func<CountryBusiness, bool>> predicate)
        {
            return await _dataSet.FirstOrDefaultAsync(predicate);
        }

    }
}
