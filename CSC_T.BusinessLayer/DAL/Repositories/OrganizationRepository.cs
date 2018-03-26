using CSC_T.BusinessLayer.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace CSC_T.BusinessLayer.DAL.Repositories
{
    public class OrganizationRepository:IRepository<Organization>
    {
        protected readonly CSCDbContext _dataContext;
        protected readonly DbSet<Organization> _dataSet;

        public OrganizationRepository(CSCDbContext dataContext)
        {
            _dataContext = dataContext;
            _dataSet = dataContext.Organizations;
        }

        public void Add(Organization entity)
        {
            _dataSet.Add(entity);
        }

        public void AddRange(IEnumerable<Organization> entities)
        {
            _dataSet.AddRange(entities);
        }

        public IEnumerable<Organization> All()
        {
            return _dataSet.ToList();
        }

        public async Task<IEnumerable<Organization>> AllAsync()
        {
            return await _dataSet.ToListAsync();
        }

        public void Attach(Organization entity)
        {
            _dataContext.Entry(entity).State = EntityState.Modified;
        }

        public void Delete(Organization entity)
        {
            _dataSet.Remove(entity);
        }

        public void DeleteRange(IEnumerable<Organization> entities)
        {
            _dataSet.RemoveRange(entities);
        }

        public Organization Find(Func<Organization, bool> predicate)
        {
            return _dataSet.FirstOrDefault(predicate);
        }

        public IEnumerable<Organization> FindAll(Func<Organization, bool> predicate)
        {
            return _dataSet.ToList();
        }

        public async Task<Organization> FindAsync(Expression<Func<Organization, bool>> predicate)
        {
            return await _dataSet.FirstOrDefaultAsync(predicate);
        }

    }
}
