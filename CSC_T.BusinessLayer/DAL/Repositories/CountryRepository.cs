using CSC_T.BusinessLayer.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace CSC_T.BusinessLayer.DAL.Repositories
{
    public class CountryRepository:IRepository<Country>
    {
        protected readonly CSCDbContext _dataContext;
        protected readonly DbSet<Country> _dataSet;

        public CountryRepository(CSCDbContext dataContext)
        {
            _dataContext = dataContext;
            _dataSet = dataContext.Countries;
        }

        public void Add(Country entity)
        {
            _dataSet.Add(entity);
        }

        public void AddRange(IEnumerable<Country> entities)
        {
            _dataSet.AddRange(entities);
        }

        public IEnumerable<Country> All()
        {
            return _dataSet.ToList();
        }

        public async Task<IEnumerable<Country>> AllAsync()
        {
            return await _dataSet.ToListAsync();
        }

        public void Attach(Country entity)
        {
            _dataContext.Entry(entity).State = EntityState.Modified;
        }

        public void Delete(Country entity)
        {
            _dataSet.Remove(entity);
        }

        public void DeleteRange(IEnumerable<Country> entities)
        {
            _dataSet.RemoveRange(entities);
        }

        public Country Find(Func<Country, bool> predicate)
        {
            return _dataSet.FirstOrDefault(predicate);
        }

        public IEnumerable<Country> FindAll(Func<Country, bool> predicate)
        {
            return _dataSet.ToList();
        }

        public async Task<Country> FindAsync(Expression<Func<Country, bool>> predicate)
        {
            return await _dataSet.FirstOrDefaultAsync(predicate);
        }

    }
}
